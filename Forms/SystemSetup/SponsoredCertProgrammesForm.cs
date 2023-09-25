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
    public partial class SponsoredCertProgrammesForm : Form
    {
        private IList<SponsoredCertProgramme> lstSponsoredProgrammes;
        private DALHelper dalHelper;
        private SponsoredCertProgrammeDataMapper sponsoredProgrammesMapper;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public SponsoredCertProgrammesForm()
        {
            InitializeComponent();
            lstSponsoredProgrammes = new List<SponsoredCertProgramme>();
            dalHelper = new DALHelper();
            sponsoredProgrammesMapper=new SponsoredCertProgrammeDataMapper();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void populate()
        {
            try
            {
                grid.Rows.Clear();
                lstSponsoredProgrammes = sponsoredProgrammesMapper.getData();
                int ctr = 0;
                foreach (SponsoredCertProgramme Row in lstSponsoredProgrammes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = Row.Id;
                    grid.Rows[ctr].Cells["gridProgramme"].Value = Row.Description;
                    grid.Rows[ctr].Cells["gridComparator"].Value = Row.Comparator;
                    grid.Rows[ctr].Cells["gridProgrammeDuration"].Value = Row.ProgrammeDuration;
                    grid.Rows[ctr].Cells["gridBondedDuration"].Value = Row.BondedDuration;
                    grid.Rows[ctr].Cells["gridActive"].Value = Row.Active;
                    grid.Rows[ctr].Cells["gridArchived"].Value = Row.Archived;
                    ctr++;
                }
            }
            catch (Exception ex1)
            {
                Logger.LogError(ex1);
            }
            
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SponsoredCertProgrammesForm_Load(object sender, EventArgs e)
        {
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ctr=0;
            foreach (DataGridViewRow dRow in grid.Rows)
            {
                if(dRow.Cells["gridProgramme"].Value!=null)
                  ctr=  InsertUpdate(dRow);
            }

            if(ctr>0)
                MessageBox.Show("Record(s) Saved Successfully!");
            else
                MessageBox.Show("No Changes To Saved!");
        }

        private int InsertUpdate(DataGridViewRow dRow)
        {
            try{
                 dalHelper.ClearParameters();
            string sql=string.Empty;
            if(Information.IsNumeric(dRow.Cells["gridID"].Value) && Convert.ToInt32(dRow.Cells["gridID"].Value)>0){
                sql="update SponsoredCertProgrammesGroup set programme=@programme,comparator=@comparator,programme_duration=@programme_duration,bonded_duration=@bonded_duration,active=@active,archived=@archived where id=@id";
                dalHelper.CreateParameter("@id", Convert.ToInt32( dRow.Cells["gridID"].Value),DbType.Int32);
            }
            else
            sql="insert into SponsoredCertProgrammesGroup (programme,comparator,programme_duration,bonded_duration,active,archived) values(@programme,@comparator,@programme_duration,@bonded_duration,@active,@archived)";
            dalHelper.CreateParameter("@programme",dRow.Cells["gridProgramme"].Value.ToString(),DbType.String);
            dalHelper.CreateParameter("@comparator",dRow.Cells["gridComparator"].Value,DbType.String);
            dalHelper.CreateParameter("@programme_duration",Convert.ToInt32( dRow.Cells["gridProgrammeDuration"].Value),DbType.Int32);
            dalHelper.CreateParameter("@bonded_duration",dRow.Cells["gridBondedDuration"].Value,DbType.Int32);
            dalHelper.CreateParameter("@active",Convert.ToBoolean( dRow.Cells["gridActive"].Value),DbType.Boolean);
            dalHelper.CreateParameter("@archived",Convert.ToBoolean( dRow.Cells["gridArchived"].Value),DbType.Boolean);

            dalHelper.ExecuteNonQuery(sql);
            return 1;
            }
            catch(Exception exception){
                return 0;
            }
           
          }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dalHelper.BeginTransaction();
            try{
                 foreach(DataGridViewRow dRow in grid.SelectedRows){
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@id",Convert.ToInt32(dRow.Cells["gridID"].Value),DbType.Int32);
                dalHelper.ExecuteNonQuery("delete SponsoredCertProgrammesGroup where id=@id");
               
              }
                dalHelper.CommitTransaction();
                MessageBox.Show("Record(s) Saved Successfully!");
            }
            catch(Exception exception){
                dalHelper.RollBackTransaction();
                MessageBox.Show("No Record(s) Deleted!");
            }
           
          }
        }
    }

