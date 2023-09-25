using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using System.Data.SqlClient;
using System.Data;
using HRBussinessLayer;
using HRBussinessLayer.System_Setup_Class;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;

namespace eMAS
{
    class AppUtils
    {
        public  DateTimePicker oDateTimePicker;
        private  DataGridView gridV;

        private static DALHelper dalCommand;

        private static List<DateTime> publicHolidays;

        public  void GridDatePicker(DataGridView gridView, int rowIndex, int columnIndex)
        {
            this.gridV = gridView;
            //Initialized a new DateTimePicker Control  
            oDateTimePicker = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            gridV.Controls.Add(oDateTimePicker);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker.Format = DateTimePickerFormat.Short;

            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = gridV.GetCellDisplayRectangle(columnIndex, rowIndex, true);

            //Setting area for DateTimePicker Control  
            oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

            // Setting Location  
            oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

            // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
            
            // An event attached to dateTimePicker Control which is fired when any date is selected  
            oDateTimePicker.ValueChanged += new EventHandler(dateTimePicker_OnTextChange);

         

            // Now make it visible  
            oDateTimePicker.Visible = true;
        }


        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            
            gridV.CurrentCell.Value = oDateTimePicker.Value.Date.ToShortDateString();
        }


        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        //String Manipulations
        public static string TrimStart(string inputText, string value)
            {
                StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase;
                if (!string.IsNullOrEmpty(value))
                { 
                    while (!string.IsNullOrEmpty(inputText) && inputText.StartsWith(value, comparisonType))
                    {
                        inputText = inputText.Substring(value.Length - 1);
                    }
                }

                return inputText;
            }


        public static string TrimEnd(string inputText, string value)
        {
           StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase;
            if (!string.IsNullOrEmpty(value))
            {
                while (!string.IsNullOrEmpty(inputText) && inputText.EndsWith(value, comparisonType))
                {
                    inputText = inputText.Substring(0, (inputText.Length - value.Length));
                }
            }

            return inputText;
        }
            public static string Trim(string inputText, string value)
            {
                //StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase;
                return TrimStart(TrimEnd(inputText, value), value);
            }


            //Calculate Actual working days
           public static List<DateTime> getPublicHolidays()
            {
                if (publicHolidays == null)
                {
                    publicHolidays = new List<DateTime>();
                    dalCommand = new DALHelper();


                    var dtHolidays = new DataTable();

                    dtHolidays = dalCommand.ExecuteReader("select Date as HolidayDate from Holidays2 order by Date asc");

                    foreach (DataRow dataRow in dtHolidays.Rows)
                    {
                        publicHolidays.Add(DateTime.Parse(dataRow["HolidayDate"].ToString()));
                    }
                }
                return publicHolidays;
            }
           public static bool IsPublicHoliday(DateTime date)
           {
               var pubHolidays = getPublicHolidays();

               foreach (DateTime d in publicHolidays)
               {
                   if (d.Date == date.Date)
                       return true;
               }
               return false;
           }
           public static bool IsHolidayOrWeekEnd(DateTime date)
           {
               if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday||IsPublicHoliday(date))
                   return true;
               else return false;
           }
           public static DateTime moveToNextWorkingDay(DateTime date)
           {
               DateTime d = date;
               while (IsHolidayOrWeekEnd(d))
               {
                   d = d.AddDays(1);
               }
               return d;
           }
           public static DateTime moveToNextWorkingDay(DateTime date,int numOfDays)
           {
               DateTime d = date;
               int ctr=1;
               while (IsHolidayOrWeekEnd(d) && ctr<=numOfDays)
               {
                   d = d.AddDays(1);
                   ctr++;
               }
               return d;
           }
           public static int DaysDiff(DateTime d2,DateTime d1)
           {
               int diff =(int) (d2 - d1).TotalDays;
               return diff;
           }
        public static DateTime[] getNonePublicHolidaysOWeekends(DateTime dateFrom,int days,bool IncludeHoliday,bool IncludeWeekend){

            List<DateTime> datelist = new List<DateTime>();
            int i = 0;
            while (datelist.Count < days)
            {
                DateTime d = dateFrom.AddDays(i++);

                if (IncludeWeekend == false && (d.DayOfWeek == DayOfWeek.Sunday || d.DayOfWeek == DayOfWeek.Saturday))
                {
                   
                    continue;
                }

                else if (IncludeHoliday == false && IsPublicHoliday(d))
                {
                  
                    continue;
                }

                datelist.Add(d);
            }

            return datelist.ToArray();
        }
        public static DateTime[] getNonePublicHolidaysOWeekends(int days,DateTime dateTo, bool IncludeHoliday, bool IncludeWeekend)
        {

            List<DateTime> datelist = new List<DateTime>();
            int i = 0;
            while (datelist.Count < days)
            {
                DateTime d = dateTo.AddDays(i--);

                if (IncludeWeekend == false && (d.DayOfWeek == DayOfWeek.Sunday || d.DayOfWeek == DayOfWeek.Saturday))
                {

                    continue;
                }

                else if (IncludeHoliday == false && IsPublicHoliday(d))
                {

                    continue;
                }

                datelist.Add(d);
            }

            return datelist.ToArray();
        }

        public static String ArrayToStringInput(String[] array)
        {
            for (int i = 0; i < array.Length;i++ )
            {
                array[i] = "'" + array[i] + "'";
            }
           return string.Join(",", array);
        }


        //Read File as Byte array

        public static byte[] FileGetBytes(String filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            br.Close();

            fs.Close();
            return bytes;
        }

        #region ErrorMessage

        public static void ErrorMessageBox()
        {
            MessageBox.Show("Something unexpected happend.\nContact the Administrator", "Error");
        }

        #endregion

        #region ErrorMessage

        public static void SuccessMessageBox(string savedItem)
        {
            MessageBox.Show(savedItem + " was saved successfully.", "Saved Successfully");
        }

        #endregion

        public static void downloadFile(byte[] data,String fileName)
        {
            try
            {
                string directory = Path.GetPathRoot(Environment.SystemDirectory) +"\\EmasDocs\\";
                String path = directory+fileName;
                bool exists = System.IO.Directory.Exists(directory);
                
                if(!exists)
                    System.IO.Directory.CreateDirectory(directory);

                File.WriteAllBytes(path, data);
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception exii) { Logger.LogError(exii); }
         
        }
        //For Image Resizing
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            try
            {

           
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
            }
            catch (Exception ei)
            {
                return null;
            }
        }
        public static bool isValidEmail(string emailAddress){
           

                try {
                    var addr = new System.Net.Mail.MailAddress(emailAddress);
                    return addr.Address == emailAddress;
                }
                catch {
                    return false;
                }

        }
        //public static DataTable AddFacilityVitalsIFEMPTYROWS(DataTable dt,CompanyDataMapper companyMapper)
        //{
        //   // dt = new DataTable(dt.TableName);
          
        //     DataColumn column;
        //   DataRow row;

        //   byte[] Logo=null;
        //   string Name=string.Empty, Motto=string.Empty;

        //   DALHelper dalHelper = new DALHelper();
        //  var dtCompany= dalHelper.ExecuteReader("select top 1 * from CompanyInfo");
        //  if (dtCompany.Rows.Count > 0)
        //  {
        //      Logo = (byte[])dtCompany.Rows[0]["Logo"];
        //      Name=dtCompany.Rows[0]["Name"].ToString();
        //           Motto=dtCompany.Rows[0]["Motto"].ToString();
        //  }
          

        //   try
        //   {
        //       row = dt.NewRow();
        //       row["Name"] = Name;
        //       row["Motto"] = Motto;
        //       row["Logo"] = Logo;
        //       // row["id"] = 0;

        //       dt.Rows.Add(row);
        //   }
        //   catch (Exception xi) { }
          

           
        //    return dt;
        //}
    }


  
   
}
