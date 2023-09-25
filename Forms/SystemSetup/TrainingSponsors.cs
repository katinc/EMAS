using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Data_Control;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;

namespace eMAS.Forms.SystemSetup
{
    public partial class TrainingSponsors : Form
    {
        private TrainingSponsorDataMapper trainingSponsorMapper;
         private DALHelper dalHelper;
         private List<TrainingSponsor> lstTrainingSponsor;
         private bool CanEdit;
         private bool CanAdd;
         private bool CanDelete;
         private bool CanPrint;
         private bool CanView;

         public TrainingSponsors()
        {
            InitializeComponent();
            this.trainingSponsorMapper = new TrainingSponsorDataMapper();
            this.lstTrainingSponsor = new List<TrainingSponsor>();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dRow in grid.Rows)
                {
                    InsertUpdate(dRow);
                }
                MessageBox.Show("Record Save Successfully!");
            }
            catch (Exception e1) {
                MessageBox.Show("Unable To Save Record!");
            }
            LoadGrid();
        }

        void InsertUpdate(DataGridViewRow dRow)
        {
            string sql = string.Empty;
            try
            {
                if (dRow.Cells["gridDescription"].Value != null)
                {
                    
                    dalHelper = new DALHelper();
                   dalHelper.ClearParameters();
                    if (Information.IsNumeric(dRow.Cells["gridID"].Value) && Convert.ToInt32(dRow.Cells["gridID"].Value) > 0)
                    {
                        dalHelper.CreateParameter("@Id", Convert.ToInt32(dRow.Cells["gridID"].Value), DbType.Int32);
                        sql = "update TrainingSponsors set Code=@Code,Description=@Description,Active=@Active,Archived=@Archived where id=@Id";
                    }
                    else
                        sql = "insert TrainingSponsors (Code,Description,Active,Archived) values(@Code,@Description,@Active,@Archived)";
                    dalHelper.CreateParameter("@Description", dRow.Cells["gridDescription"].Value.ToString(), DbType.String);
                    if (dRow.Cells["gridCode"].Value == null)
                    {
                        dalHelper.CreateParameter("@Code", "", DbType.String);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@Code", dRow.Cells["gridCode"].Value.ToString(), DbType.String);
                    }
                    dalHelper.CreateParameter("@Active", Convert.ToBoolean(dRow.Cells["gridActive"].Value), DbType.Boolean);
                    dalHelper.CreateParameter("@Archived", Convert.ToBoolean(dRow.Cells["gridArchived"].Value), DbType.Boolean);

                    dalHelper.ExecuteNonQuery(sql);

                }
            }
            catch (Exception e1)
            {

            }
           
            
           
        }

        void LoadGrid()
        {
            try
            {
                grid.Rows.Clear();
                int ctr = 0;
                lstTrainingSponsor = trainingSponsorMapper.getAll(true);
                foreach (TrainingSponsor trainingsponsor in lstTrainingSponsor)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = trainingsponsor.Id;
                    grid.Rows[ctr].Cells["gridCode"].Value = trainingsponsor.Code;
                    grid.Rows[ctr].Cells["gridDescription"].Value = trainingsponsor.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = trainingsponsor.Active;
                    grid.Rows[ctr].Cells["gridArchived"].Value = trainingsponsor.Archived;
                    ctr++;
                }
                grid.ClearSelection();
            }
            catch (Exception e1) { }
            
        }

        private void TrainingOrganizers_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow!=null)
                {
                    TrainingSponsor trainingSponsor = lstTrainingSponsor[grid.CurrentRow.Index];
                    dalHelper = new DALHelper();
                    dalHelper.CreateParameter("@Id", trainingSponsor.Id, DbType.Int32);
                    dalHelper.ExecuteNonQuery("delete trainingSponsors where id=@Id");
                    lstTrainingSponsor.Remove(trainingSponsor);
                    grid.Rows.Remove(grid.CurrentRow);
                }
                
                else
                    MessageBox.Show("Sorry You Must Select A Row");
            }
            catch (Exception e1) { }
            
        }

        private void TrainingSponsors_Load(object sender, EventArgs e)
        {
            LoadGrid();

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

       
    }
}
