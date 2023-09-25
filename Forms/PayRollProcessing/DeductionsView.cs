using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class DeductionsView : Form
    {
        private IDAL dal;
        private DeductionsNew  newForm;
        private StaffDeduction staffDeduction;
        private IList<StaffDeduction> staffDeductions;

        public DeductionsView()
        {
            try
            {
                InitializeComponent();
                this.newForm = new DeductionsNew();
                this.dal = new DAL();
                this.staffDeduction = new StaffDeduction();
                this.staffDeductions = new List<StaffDeduction>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public DeductionsView(DeductionsNew newForm)
        {
            try
            {
                InitializeComponent();
                this.newForm = newForm;
                this.dal = new DAL();
                this.staffDeduction = new StaffDeduction();
                this.staffDeductions = new List<StaffDeduction>();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void DeductionsView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GetAll();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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
                staffDeductions = dal.GetAll<StaffDeduction>();
                grid.DataSource = staffDeductions;
                if (grid.ColumnCount > 0)
                {
                    grid.Columns["ID"].Visible = false;
                    grid.Columns["TypeID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {
                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                staffDeduction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffDeduction.InUse = false;
                                staffDeduction.Archived = true;
                                dal.Delete(staffDeduction);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffDeduction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffDeduction.InUse = false;
                                staffDeduction.Archived = true;
                                dal.Delete(staffDeduction);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
