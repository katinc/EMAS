using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using HRBussinessLayer.System_Setup_Class;
using System.Data.SqlClient;
using System.Configuration;

namespace eMAS.Forms.SystemSetup
{
    public partial class PublicHolidaysForm : Form
    {
        bool found = false;
        AppUtils appUtils;
        IDAL idal;
        IList<PublicHoliday> publicHolidays;
        string connectionString;
        
        public PublicHolidaysForm()
        {
            InitializeComponent();
            appUtils = new AppUtils();
            idal = new DAL();
            publicHolidays = new List<PublicHoliday>();
        }

        private void PublicHolidays_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            /*if (GlobalData.User.UserCategory.Description == "Basic")
            {
                found = true;
            }

            if (found == true)
            {
                GetData();
            }*/
            GetData();
        }

        private void GetData()
        {
            try
            {
                int ctr = 0;

                SqlDataAdapter adapta = new SqlDataAdapter("select * from publicholidays where archived='false'", new SqlConnection(connectionString));

                var dtPubHolidays = new DataTable();

                adapta.Fill(dtPubHolidays);
                
                
                foreach (DataRow pub in dtPubHolidays.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = pub["ID"];
                    grid.Rows[ctr].Cells["gridHolidayName"].Value = pub["HolidayName"];
                    grid.Rows[ctr].Cells["gridHolidayDate"].Value = pub["HolidayDate"];
                    grid.Rows[ctr].Cells["gridActive"].Value = pub["Active"];
                    grid.Rows[ctr].Cells["gridArchived"].Value = pub["Archived"];
                    grid.Rows[ctr].Cells["gridUserID"].Value = pub["UserID"];
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.Columns[e.ColumnIndex].Name == "gridHolidayDate")
                {
                    appUtils = new AppUtils();
                    appUtils.GridDatePicker(grid, e.RowIndex, e.ColumnIndex);


                    var currCell = grid.CurrentCell.Value;

                    if (currCell != null)
                    {
                        appUtils.oDateTimePicker.Value = DateTime.Parse(currCell.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                idal.BeginTransaction();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        PublicHoliday publicHoliday = new PublicHoliday()
                        {
                            UserID = GlobalData.User.ID,
                            Active =(row.Cells["gridActive"].Value!=null)? (bool)row.Cells["gridActive"].Value:false,
                            Archived =(row.Cells["gridArchived"].Value!=null)? (bool)row.Cells["gridArchived"].Value:false,
                            HolidayDate = DateTime.Parse(row.Cells["gridHolidayDate"].Value.ToString()),
                            HolidayName =(row.Cells["gridHolidayName"].Value!=null)? row.Cells["gridHolidayName"].Value.ToString():string.Empty,

                        };

                        if (row.Cells["gridID"].Value == null)
                            idal.Save(publicHoliday);
                        else
                        {
                            publicHoliday.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                            idal.Update(publicHoliday);
                        }
                    }
                }
                idal.CommitTransaction();
            }
            catch (Exception ex)
            {
                idal.RollBackTransaction();
                Logger.LogError(ex);
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridHolidayName"].Value.ToString() + "'s Holiday?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var Row = grid.Rows[grid.CurrentCell.RowIndex];

                    var pub = new PublicHoliday()
                    {
                        ID =int.Parse(Row.Cells["gridID"].Value.ToString())
                    };
                    idal.Delete(pub);
                    grid.Rows.Remove(Row);
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
