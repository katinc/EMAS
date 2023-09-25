using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;

namespace eMAS.Forms.SystemSetup
{
    public partial class AttendedSchools : Form
    {
        private IList<AttendedSchool> lstAttendedSchools;
        private AttendedSchoolDataMapper attendedSchoolMapper;
        private DALHelper dalHelper;
        private IList<Country> lstCountries;
        private CountryDataMapper countryDataMapper;
        private DataTable countryTable;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public AttendedSchools()
        {
            InitializeComponent();
            dalHelper = new DALHelper();
            lstAttendedSchools = new List<AttendedSchool>();
            attendedSchoolMapper = new AttendedSchoolDataMapper();
            lstCountries = new List<Country>();
            countryDataMapper = new CountryDataMapper();
            countryTable = new DataTable();
            grid.CellClick += new DataGridViewCellEventHandler(gridCountryId_CellClick);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populate();
        }
      
        void populate()
        {
            grid.Rows.Clear();
            int ctr=0;
            lstAttendedSchools = attendedSchoolMapper.getData();
            
            foreach (AttendedSchool attnSchool in lstAttendedSchools)
            {
                grid.Rows.Add(1);
                grid.Rows[ctr].Cells["gridID"].Value = attnSchool.Id;
                grid.Rows[ctr].Cells["gridDescription"].Value = attnSchool.Description;
                grid.Rows[ctr].Cells["gridLocation"].Value = attnSchool.Location;
                grid.Rows[ctr].Cells["gridWebsite"].Value = attnSchool.Website;
                grid.Rows[ctr].Cells["gridActive"].Value = attnSchool.Active;
                grid.Rows[ctr].Cells["gridArchived"].Value = attnSchool.Archived;
                grid.Rows[ctr].Cells["gridCountryId"].Value = attnSchool.SchoolCountry.Description;
                ctr++;
            }
           
        }

        private void getCountries()
        {
            try
            {
                //if (grid.CurrentRow != null)
                //{
                //    if (grid.CurrentCell.ColumnIndex == gridCountryId.Index)
                //    {
                //        dalHelper.OpenConnection();
                //        countryTable = dalHelper.ExecuteReader("select ID,Description From CountryView Where Archived ='False' order by Description ASC");
                //        gridCountryId.Items.Clear();
                //        foreach (DataRow row in countryTable.Rows)
                //        {
                //            gridCountryId.Items.Add(row["Description"].ToString());
                //        }
                //    }
                //}

                gridCountryId.DataSource = null;

                var countries = GlobalData._context.Countries.ToList();

                if (countries.Count() > 0)
                {
                    gridCountryId.DataSource = countries;
                    gridCountryId.ValueMember = "ID";
                    gridCountryId.DisplayMember = "Description";
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void gridCountryId_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                getCountries();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void AttendedSchools_Load(object sender, EventArgs e)
        {
            try
            {

            getCountries();
            populate();

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnSave.Enabled = getPermissions.CanAdd;
                btnDelete.Enabled = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        int getID(string countryName)
        {
            if (Information.IsNumeric(countryName))
                return Convert.ToInt32(countryName);
            else
            {
                foreach (Country country in lstCountries)
                {
                    if (countryName == country.Description)
                        return country.ID;

                }

                return 0;
            }
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int ctr=0;
            foreach (DataGridViewRow dRow in grid.Rows)
            {
                if (dRow.Cells["gridDescription"].Value != null)
                {
                  ctr+=  InsertUpdate(dRow);
                }
               
            }
            if (ctr > 0)
                MessageBox.Show("Record(s) Saved successfully!");
            else
                MessageBox.Show("No Record Was Saved!");
        }
        int InsertUpdate(DataGridViewRow dRow)
        {
            int ctr = 0;
            try
            {
            string sql = string.Empty;
            dalHelper.ClearParameters();
            if (Information.IsNumeric(dRow.Cells["gridID"].Value) && Convert.ToInt32(dRow.Cells["gridID"].Value) > 0)
            {
                dalHelper.CreateParameter("@id", Convert.ToInt32(dRow.Cells["gridID"].Value), DbType.Int32);
                sql = "update AttendedSchools set description=@description,countryId=@countryId,website=@website,active=@active,archived=@archived,location=@location where id=@id";
            }
            else
            {
                sql = "insert into AttendedSchools (description,countryId,website,active,archived,location) values (@description,@countryId,@website,@active,@archived,@location)";

            }
            dalHelper.CreateParameter("@description", Convert.ToString(dRow.Cells["gridDescription"].Value), DbType.String);

            //DataGridViewComboBoxColumn countryColumn = Convert.Data dRow.Cells["gridCountryId"];

            dalHelper.CreateParameter("@description", Convert.ToString(dRow.Cells["gridDescription"].Value), DbType.String);
            dalHelper.CreateParameter("@countryId", getID(dRow.Cells["gridCountryId"].Value.ToString()), DbType.Int32);
            dalHelper.CreateParameter("@location",dRow.Cells["gridLocation"].Value!=null? dRow.Cells["gridLocation"].Value.ToString():string.Empty, DbType.String);
            dalHelper.CreateParameter("@website", Convert.ToString(dRow.Cells["gridWebsite"].Value), DbType.String);
            dalHelper.CreateParameter("@active", Convert.ToBoolean(dRow.Cells["gridActive"].Value), DbType.Boolean);
            dalHelper.CreateParameter("@archived", Convert.ToBoolean(dRow.Cells["gridArchived"].Value), DbType.Boolean);

            dalHelper.ExecuteNonQuery(sql);
            ctr++;
            }
            catch (Exception exception) { }
            return ctr;
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dalHelper.BeginTransaction();
            try
            {
                foreach (DataGridViewRow dRow in grid.SelectedRows)
                {
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@id", Convert.ToInt32(dRow.Cells["gridID"].Value), DbType.Int32);

                    dalHelper.ExecuteNonQuery("delete AttendedSchools where id=@id");

                }
                dalHelper.CommitTransaction();
                MessageBox.Show("Record(s) Deleted Successfully!");
            }
            catch (Exception ex)
            {
                dalHelper.RollBackTransaction();
                MessageBox.Show("Unable To Delete Record(s)!");
            }
            btnRefresh_Click(sender, e);
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (grid.Rows[e.RowIndex].Cells["gridDescription"].Value== null)
            {
                grid.Rows[e.RowIndex].Cells["gridActive"].Value = false;
                grid.Rows[e.RowIndex].Cells["gridArchived"].Value = false;
            }
        }

        private void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (grid.Rows[e.RowIndex].IsNewRow == true)
            {
               
                    grid.Rows[e.RowIndex].Cells["gridActive"].Value = true;
                    grid.Rows[e.RowIndex].Cells["gridArchived"].Value = false;
               
            }
        }
    }
}
