using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace HRDataAccessLayer 
{
    public static class Global
    {

        public enum Months
        {
            None,
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        #region ImageToArray
        public static byte[] ImageToArray(Image img)
        {
            byte[] photoArray;
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            photoArray = ms.ToArray();
            return photoArray;
        }
        #endregion

        #region ArrayToImage
        public static Image ArrayToImage(byte[] photoArray)
        {
            MemoryStream ms = new MemoryStream(photoArray);
            Image img = Image.FromStream(ms);
            return img;
        }
        #endregion

        public static int GetMonth(string newMonth)
        {
            int temp = 0;
            try
            {
                if (newMonth != string.Empty && newMonth.Trim().ToUpper() != "ALL")
                {
                    Months month = (Months)Enum.Parse(typeof(Months), newMonth);
                    switch (month)
                    {
                        case Months.January:
                            temp = 1;
                            break;
                        case Months.February:
                            temp = 2;
                            break;
                        case Months.March:
                            temp = 3;
                            break;
                        case Months.April:
                            temp = 4;
                            break;
                        case Months.May:
                            temp = 5;
                            break;
                        case Months.June:
                            temp = 6;
                            break;
                        case Months.July:
                            temp = 7;
                            break;
                        case Months.August:
                            temp = 8;
                            break;
                        case Months.September:
                            temp = 9;
                            break;
                        case Months.October:
                            temp = 10;
                            break;
                        case Months.November:
                            temp = 11;
                            break;
                        case Months.December:
                            temp = 12;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //LogError(ex);
                throw ex;
            }
            return temp;
        }

        #region System Changes
        public static void RecordSystemChange()
        {

        }
        
        #endregion

    }
}
