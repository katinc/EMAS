using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using Session_Framework;

namespace eMAS.Forms.SystemSetup
{
    public partial class AppraisalFactorsForm : Form
    {
      private   AppraisalTypesDataMapper appraisalTypeMapper;
        private DALHelper dalHelper;
        private IList<AppraisalType> lstAppraisalTypes;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        
        public AppraisalFactorsForm()
        {
            InitializeComponent();
            appraisalTypeMapper=new AppraisalTypesDataMapper();
            dalHelper=new DALHelper();
            lstAppraisalTypes = new List<AppraisalType>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //grid.Rows.Clear();
                foreach (DataGridViewRow dRow in grid.Rows)
                {
                    InsertOrUpdate(dRow);
                }
            }
            catch (Exception xi) { }
            loadGrid();
        }
        private void loadGrid()
        {
            try
            {
                lstAppraisalTypes.Clear();
                lstAppraisalTypes = appraisalTypeMapper.getAppraisalTypes(true, false);
                grid.Rows.Clear();
                int ctr = 0;
                foreach (AppraisalType appraisalType in lstAppraisalTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = appraisalType.ID;
                    grid.Rows[ctr].Cells["gridAppraisalFactor"].Value = appraisalType.Description;

                    ctr++;
                }
                grid.ClearSelection();
            }
            catch (Exception xi) { }
            
        }
        private void InsertOrUpdate(DataGridViewRow dRow){

            try
            {
                dalHelper.ClearParameters();
                var AppraisalType = dRow.Cells["gridID"].Value!=null ? appraisalTypeMapper.getAppraisalTypeById(Convert.ToInt32(dRow.Cells["gridID"].Value)) : new AppraisalType();

                AppraisalType.Description = dRow.Cells["gridAppraisalFactor"].Value.ToString();
               // AppraisalType.Active =Convert.ToBoolean(((DataGridViewCheckBoxCell)dRow.Cells["gridActive"]).Value);

                dalHelper.CreateParameter("@Description", AppraisalType.Description, DbType.String);
                dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);

                if (AppraisalType.ID > 0)
                {
                    dalHelper.CreateParameter("@DateModified", DateTime.Now.Date, DbType.Date);
                    dalHelper.CreateParameter("@Id", AppraisalType.ID, DbType.Int32);
                    dalHelper.ExecuteNonQuery("update AppraisalTypes set Description=@Description,DateModified=@DateModified,UserID=@UserID,Active=@Active where id=@Id");
                }
                else
                {
                    dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                    dalHelper.ExecuteNonQuery("insert into AppraisalTypes (Description,UserID,Active,Archived) values(@Description,@UserID,@Active,@Archived)");
                }
            }
            catch (Exception xi)
            {
                //Logger.LogError(xi);
            }
           

            
        }

        private void AppraisalFactorsForm_Load(object sender, EventArgs e)
        {
            loadGrid();

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@Id", Convert.ToInt32(grid.CurrentRow.Cells["gridID"].Value), DbType.Int32);
                    dalHelper.ExecuteNonQuery("delete AppraisalTypes where id=@Id");
                    grid.Rows.Remove(grid.CurrentRow);
                }
                else
                    MessageBox.Show("Sorry No Record Was Selected!");
            }
            catch (Exception xi) { }
            
        }
    }
}
