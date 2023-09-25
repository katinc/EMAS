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

namespace eMAS.Forms.SystemSetup
{
    public partial class StaffIdentificationTypes : Form
    {
        private IList<StaffIdentificationType> lststaffIdentificationTypes;
        private StaffIdentificationTypesDataMapper identityDataMapper;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;
        DataGridView oldDT;

        public StaffIdentificationTypes()
        {
            InitializeComponent();
            this.lststaffIdentificationTypes = new List<StaffIdentificationType>();
            this.identityDataMapper = new StaffIdentificationTypesDataMapper();

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    var identity = new StaffIdentificationType();
                    identity.ID = Convert.ToInt32(row.Cells["gridID"].Value ?? 0);
                    identity.CardName = Convert.ToString(row.Cells["gridCardName"].Value ?? string.Empty);
                    identity.Active = Convert.ToBoolean(row.Cells["gridActive"].Value ?? true);

                    if (identity.ID == 0)
                        identityDataMapper.Save(identity);
                    else
                        continue;
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }

        private void loadGrid()
        {
            try
            {
                grid.Rows.Clear();
                lststaffIdentificationTypes = identityDataMapper.getData();

                int ctr=0;
                foreach (var identity in lststaffIdentificationTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = identity.ID;
                    grid.Rows[ctr].Cells["gridCardName"].Value = identity.CardName;
                    grid.Rows[ctr].Cells["gridActive"].Value = identity.Active;

                    ctr++;
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.SelectedRows.Count > 0)
                {
                    var id = Convert.ToInt32(grid.SelectedRows[0].Cells["gridID"].Value ?? 0);

                    identityDataMapper.Delete(id);

                    grid.Rows.Remove(grid.SelectedRows[0]);

                    MessageBox.Show("Record Deleted successfully!");
                }
                else
                    MessageBox.Show("No Record was selected!");
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }

        }

        private void StaffIdentificationTypes_Load(object sender, EventArgs e)
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
            oldDT = new DataGridView();
            oldDT = GlobalData.CopyDataGridView(grid);
        }
        

    }
}
