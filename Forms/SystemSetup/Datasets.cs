using eMAS.DataReference;
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
    public partial class Datasets : Form
    {
        private int ctr;
        public Datasets()
        {
            InitializeComponent();
        }

        private void Datasets_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            var datasets = GlobalData._context.EnforceDatasets.ToList();
            PopulateView(datasets);
        }

        private void PopulateView(List<EnforceDataset> datasets)
        {
            this.ctr = 0;
            grid.Rows.Clear();
            foreach (DataReference.EnforceDataset dataset in datasets)
            {
                grid.Rows.Add(1);
                grid.Rows[ctr].Cells["gridID"].Value = dataset.ID.ToString();
                grid.Rows[ctr].Cells["gridDescription"].Value = dataset.Description;
                grid.Rows[ctr].Cells["gridActive"].Value = dataset.IsActive.ToString();
                grid.Rows[ctr].Cells["gridName"].Value = dataset.Name;
                grid.Rows[ctr].Cells["gridRequireApproval"].Value = dataset.RequireChangeRequestApproval;
                ctr++;
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
                        if (row.Cells["gridName"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Name cannot be empty" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridDescription"].Value != null && row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
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
                                var dataset = new DataReference.EnforceDataset
                                {
                                    Description = row.Cells["gridDescription"].Value.ToString(),
                                    IsActive = (bool)row.Cells["gridActive"].FormattedValue,
                                    Name = row.Cells["gridName"].Value.ToString(),
                                    RequireChangeRequestApproval = (bool)row.Cells["gridRequireApproval"].FormattedValue,
                                };
                                GlobalData._context.EnforceDatasets.InsertOnSubmit(dataset);
                            }
                            else
                            {
                                int datasetId = int.Parse(row.Cells["gridID"].Value.ToString());

                                var updateDS = GlobalData._context.EnforceDatasets.SingleOrDefault(u => u.ID == datasetId);
                                updateDS.Description = Convert.ToString(row.Cells["gridDescription"].Value);
                                updateDS.IsActive = (bool)row.Cells["gridActive"].FormattedValue;
                                updateDS.Name = row.Cells["gridName"].Value.ToString();
                                updateDS.RequireChangeRequestApproval = (bool)row.Cells["gridRequireApproval"].FormattedValue;
                            }

                            GlobalData._context.SubmitChanges();
                        }
                    }
                    MessageBox.Show("Saved Successfully");
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }
    }
}
