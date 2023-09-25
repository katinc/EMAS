using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
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
    public partial class ChartSetup : Form
    {
        private DALHelper dalHelper;
        private IDAL dal;
        public ChartSetup()
        {
            InitializeComponent();
            dalHelper = new DALHelper();
            dal = new DAL();
        }

        private void ChartSetup_Load(object sender, EventArgs e)
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
                var charts = GlobalData._context.ChartsSetups.Where(u => u.Archived == false);

                int ctr = 0;
                grid.Rows.Clear();
                foreach (var chart in charts)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = chart.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = chart.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = chart.Active;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["gridID"].Value == null)
                            {
                                var chartSetup = new DataReference.ChartsSetup
                                {
                                    Description = row.Cells["gridDescription"].Value.ToString(),
                                    Active = (bool)row.Cells["gridActive"].FormattedValue,
                                    Archived = false,
                                };
                                GlobalData._context.ChartsSetups.InsertOnSubmit(chartSetup);
                            }
                            else
                            {
                                int chartId = int.Parse(row.Cells["gridID"].Value.ToString());

                                var updateCharts = GlobalData._context.ChartsSetups.SingleOrDefault(u => u.ID == chartId);
                                updateCharts.Description = row.Cells["gridDescription"].Value.ToString();
                                updateCharts.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            }

                            GlobalData._context.SubmitChanges();
                        }
                    }
                    MessageBox.Show("Saved Successfully");
                    GetAll();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider1.Clear();
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
            }
            return result;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {
                            int chartId = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());

                            var updateCharts = GlobalData._context.ChartsSetups.SingleOrDefault(u => u.ID == chartId);
                            updateCharts.Archived = true;
                            updateCharts.ArchivedTime = DateTime.Now;
                            updateCharts.ArchiverID = GlobalData.User.ID.ToString();

                            GlobalData._context.SubmitChanges();
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
