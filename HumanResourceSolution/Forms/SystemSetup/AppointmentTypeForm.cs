using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.SystemSetup
{
    public partial class AppointmentTypeForm : Form
    {
        private IDAL dal;
        private AppointmentType appointmentType;
        private IList<AppointmentType> appointmentTypes;
        private IList<AppointmentType> foundAppointmentTypes;
        private int ctr; 

        public AppointmentTypeForm()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.dal.OpenConnection();
            this.appointmentType = new AppointmentType();
            this.appointmentTypes = new List<AppointmentType>();
            this.foundAppointmentTypes = new List<AppointmentType>();
            this.ctr = 0;
        }

        private void AppointmentTypes_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Description cannot be empty" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void PopulateView(IList<AppointmentType> appointmentTypes)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = appointmentType.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = appointmentType.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = appointmentType.Active.ToString();
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetData()
        {
            try
            {
                appointmentTypes = dal.GetAll<AppointmentType>();
                ctr = 0;
                grid.Rows.Clear();
                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = appointmentType.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = appointmentType.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = appointmentType.Active.ToString();
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            appointmentType.Description = row.Cells["gridDescription"].Value.ToString();
                            appointmentType.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            appointmentType.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(appointmentType);
                            }
                            else
                            {
                                appointmentType.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(appointmentType);
                            }
                        }
                    }
                    GetData();
                    Clear();
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {
                            appointmentType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            appointmentType.Active = false;
                            appointmentType.Archived = true;
                            dal.Delete(appointmentType);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            GetData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundAppointmentTypes.Clear();
                appointmentTypes = dal.GetAll<AppointmentType>();
                grid.Rows.Clear();
                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    if ((appointmentType.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundAppointmentTypes.Add(appointmentType);
                    }
                }
                PopulateView(foundAppointmentTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                txtDescription.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
    }
}
