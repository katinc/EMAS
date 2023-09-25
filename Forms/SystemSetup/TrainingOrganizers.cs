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
    public partial class TrainingOrganizers : Form
    {
         private TrainingOrganizersDataMapper trainingOrganizerMapper;
         private DALHelper dalHelper;
         private List<TrainingOrganizer> lstTrainingOrganizers;
        public TrainingOrganizers()
        {
            InitializeComponent();
            this.trainingOrganizerMapper = new TrainingOrganizersDataMapper();
            this.lstTrainingOrganizers = new List<TrainingOrganizer>();
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
            if (dRow.Cells["gridDescription"].Value != null)
            {
                
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                if (Information.IsNumeric(dRow.Cells["gridID"].Value) && Convert.ToInt32(dRow.Cells["gridID"].Value) > 0)
                {
                    dalHelper.CreateParameter("@Id", Convert.ToInt32(dRow.Cells["gridID"].Value), DbType.Int32);
                    sql = "update TrainingOrganizers set Code=@Code, Description=@Description,Active=@Active,Archived=@Archived where id=@Id";
                }
                else
                    sql = "insert TrainingOrganizers (Code,Description,Active,Archived) values(@Code,@Description,@Active,@Archived)";
                dalHelper.CreateParameter("@Description", dRow.Cells["gridDescription"].Value, DbType.String);

                if (dRow.Cells["gridCode"].Value == null)
                {
                    dalHelper.CreateParameter("Code", "", DbType.String);
                }
                else
                {
                    dalHelper.CreateParameter("Code", dRow.Cells["gridCode"].Value.ToString(), DbType.String);
                }

                dalHelper.CreateParameter("@Active", Convert.ToBoolean(dRow.Cells["gridActive"].Value), DbType.Boolean);
                dalHelper.CreateParameter("@Archived", Convert.ToBoolean(dRow.Cells["gridArchived"].Value), DbType.Boolean);

                dalHelper.ExecuteNonQuery(sql);
                
            }
           
        }

        void LoadGrid()
        {
            try
            {
                grid.Rows.Clear();
                int ctr = 0;
                lstTrainingOrganizers = trainingOrganizerMapper.getAll(true);
                foreach (TrainingOrganizer trainingOrganizer in lstTrainingOrganizers)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = trainingOrganizer.Id;
                    grid.Rows[ctr].Cells["gridCode"].Value = trainingOrganizer.Code;
                    grid.Rows[ctr].Cells["gridDescription"].Value = trainingOrganizer.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = trainingOrganizer.Active;
                    grid.Rows[ctr].Cells["gridArchived"].Value = trainingOrganizer.Archived;
                    ctr++;
                }
            }
            catch (Exception e1) { }
            
        }

        private void TrainingOrganizers_Load(object sender, EventArgs e)
        {
            var permissions = GlobalData.CheckPermissions(3);
            btnSave.Enabled = permissions.CanAdd;
            btnDelete.Enabled = permissions.CanDelete;

            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    TrainingOrganizer trainingOrganizer = lstTrainingOrganizers[grid.CurrentRow.Index];
                    dalHelper = new DALHelper();
                    dalHelper.CreateParameter("@Id", trainingOrganizer.Id, DbType.Int32);
                    dalHelper.ExecuteNonQuery("delete trainingOrganizers where id=@Id");
                    lstTrainingOrganizers.Remove(trainingOrganizer);
                    grid.Rows.Remove(grid.CurrentRow);
                }
                else
                    MessageBox.Show("You Must Select A Row");
            }
            catch (Exception e1) { }
            
        }
        
    }
}
