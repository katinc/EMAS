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
    public partial class TrainingAttendanceModes : Form
    {
        private TrainingAttendanceModeMapper attendanceMapper;
        private IList<TrainingAttendanceMode> lstAttendanceModes;
        private DALHelper dalHeper;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public TrainingAttendanceModes()
        {
            InitializeComponent();
            attendanceMapper = new TrainingAttendanceModeMapper();
            lstAttendanceModes = new List<TrainingAttendanceMode>();
            dalHeper = new DALHelper();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TrainingAttendanceModes_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Populate();
        }
        void Populate()
        {
          lstAttendanceModes=  attendanceMapper.GetData();
          grid.Rows.Clear();
          int ctr=0;
          foreach (TrainingAttendanceMode attendanceMode in lstAttendanceModes)
          {
              grid.Rows.Add(1);
              grid.Rows[ctr].Cells["gridID"].Value = attendanceMode.Id;
              grid.Rows[ctr].Cells["gridDescription"].Value = attendanceMode.Description;
              grid.Rows[ctr].Cells["gridActive"].Value = attendanceMode.Active;
              grid.Rows[ctr].Cells["gridArchived"].Value = attendanceMode.Archived;
              ctr++;
          }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           // dalHeper.BeginTransaction();
            try
            {
                foreach (DataGridViewRow dRow in grid.Rows)
                {
                    if(dRow.Cells["gridDescription"].Value!=null)
                    InsertUpdate(dRow);
                }

                //dalHeper.CommitTransaction();
            }
            catch (Exception ei)
            {
                Logger.LogError(ei);
            }
            
        }
        private void InsertUpdate(DataGridViewRow dRow)
        {
            try
            {
                dalHeper.ClearParameters();
                var sql = string.Empty;
                if (Information.IsNumeric(dRow.Cells["gridID"].Value) && Convert.ToInt32(dRow.Cells["gridID"].Value) > 0)
                {

                    dalHeper.CreateParameter("@id", Convert.ToInt32(dRow.Cells["gridID"].Value), DbType.Int32);
                    sql = "update TrainingAttendanceModes set description=@description,active=@active,archived=@archived where id=@id";
                }
                else
                    sql = "insert into TrainingAttendanceModes (description,active,archived) values (@description,@active,@archived)";

                dalHeper.CreateParameter("@description", Convert.ToString(dRow.Cells["gridDescription"].Value), DbType.String);
                dalHeper.CreateParameter("@active", Convert.ToBoolean(dRow.Cells["gridActive"].Value), DbType.Boolean);
                dalHeper.CreateParameter("@archived", Convert.ToBoolean(dRow.Cells["gridArchived"].Value), DbType.Boolean);

                dalHeper.ExecuteNonQuery(sql);
            }
            catch (Exception e1)
            {

            }
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (grid.SelectedRows.Count > 0)
            {
                dalHeper.BeginTransaction();
                try
                {
                    foreach (DataGridViewRow dRow in grid.SelectedRows)
                    {
                        dalHeper.ClearParameters();
                        dalHeper.CreateParameter("@id", Convert.ToInt32(dRow.Cells["gridID"].Value), DbType.Int32);
                        dalHeper.ExecuteNonQuery("delete TrainingAttendanceModes where id=@id");
                    }
                    dalHeper.CommitTransaction();
                }
                catch (Exception ei)
                {
                    dalHeper.RollBackTransaction();
                    Logger.LogError(ei);
                }
                btnRefresh_Click(sender, e);

            }
            else
                MessageBox.Show("No Record Was Selected!");
        }
    }
}
