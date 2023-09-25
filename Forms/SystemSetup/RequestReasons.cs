using HRBussinessLayer.ErrorLogging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.SystemSetup
{
    public partial class RequestReasons : Form
    {
        public RequestReasons()
        {
            InitializeComponent();
        }

        private void RequestReasons_Load(object sender, EventArgs e)
        {
            try
            {
                GetAll();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetAll()
        {
            try
            {
                var Reasons = GlobalData._context.StaffChangesRequestReasons.Where(u => u.Archived == false).ToList();

                int ctr = 0;
                grid.Rows.Clear();

                foreach (var row in Reasons)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = row.Descripion;
                    grid.Rows[ctr].Cells["gridUserID"].Value = row.UserID;
                    grid.Rows[ctr].Cells["gridActive"].Value = row.Active;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridID"].Value != null)
                        {
                            //editmode
                            var ID = row.Cells["gridID"].Value.ToString();
                            var editReason = GlobalData._context.StaffChangesRequestReasons.SingleOrDefault(u => u.ID.ToString() == ID);
                            editReason.Descripion = row.Cells["gridDescription"].Value.ToString();
                            editReason.Active = row.Cells["gridActive"].Value.ToString().ToLower() == "true" ? true : false; 
                            editReason.UserID = GlobalData.User.ID;
                        }
                        else
                        {
                            var reason = new DataReference.StaffChangesRequestReason
                            {
                                Descripion = row.Cells["gridDescription"].Value.ToString(),
                                Active = (row.Cells["gridActive"].Value != null) ? bool.Parse(row.Cells["gridActive"].Value.ToString()) : false,
                                Archived = false,
                                UserID = GlobalData.User.ID
                            };
                            GlobalData._context.StaffChangesRequestReasons.InsertOnSubmit(reason);
                        }
                        
                    }
                }
                GlobalData._context.SubmitChanges();
                AppUtils.SuccessMessageBox("Reasons");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null && grid.CurrentRow.Cells["gridID"].Value != null)
                {
                    var ID = grid.CurrentRow.Cells["gridID"].Value.ToString();
                    var editReason = GlobalData._context.StaffChangesRequestReasons.SingleOrDefault(u => u.ID.ToString() == ID);
                    editReason.Archived = true;
                    GlobalData._context.SubmitChanges();
                }
                if (grid.CurrentRow.Cells["gridDescription"].Value != null)
                {
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}
