using HRBussinessLayer.ErrorLogging;
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
    public partial class FieldMapping : Form
    {
        private DALHelper dal;
        public FieldMapping()
        {
            InitializeComponent();
            this.dal = new DALHelper();
        }

        private void FieldMapping_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDatasets();

                LoadDetails();

                LoadMenuForm();
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadMenuForm()
        {
            var getMenuItems = GlobalData._context.UserAccessLevel3s.OrderBy(u=>u.ControlID).ToList();
            var getForms = GlobalData._context.EnforceDatasets.OrderBy(u=>u.Name).ToList();

            cboMenuItem.DataSource = null;
            cboForm.DataSource = null;

            cboMenuItem.DataSource = getMenuItems;
            cboMenuItem.DisplayMember = "ControlID";
            cboMenuItem.ValueMember = "ID";

            cboForm.DataSource = getForms;
            cboForm.DisplayMember = "Name";
            cboForm.ValueMember = "ID";

        }

        private void LoadDetails()
        {
            LoadDataTypes();
            LoadControlType();
            LoadTables();
            //LoadStaffTable();
        }

        private void LoadControlType()
        {
            cmbControlTypes.Items.Clear();

            cmbControlTypes.Items.Add("CalenderColumn");
            cmbControlTypes.Items.Add("CalenderTimeColumn");
            cmbControlTypes.Items.Add("DataGridViewButtonColumn");
            cmbControlTypes.Items.Add("DataGridViewCheckBoxColumn");
            cmbControlTypes.Items.Add("DataGridViewComboBoxColumn");
            cmbControlTypes.Items.Add("DataGridViewLinkColumn");
            cmbControlTypes.Items.Add("DataGridViewTextBoxColumn");

            //cmbControlTypes.Items.Add("checkbox");
            //cmbControlTypes.Items.Add("combobox");
            //cmbControlTypes.Items.Add("datetimepicker");
            //cmbControlTypes.Items.Add("grid");
            //cmbControlTypes.Items.Add("numericupdown");
            //cmbControlTypes.Items.Add("picturebox");
            //cmbControlTypes.Items.Add("textbox");
        }

        private void LoadDataTypes()
        {
            cmbDataType.Items.Clear();
            cmbDataType.Items.Add("String");
            cmbDataType.Items.Add("Int");
            cmbDataType.Items.Add("Image");
        }

        private void LoadStaffTable()
        {
            if (cmbStaffDataTable.Text != string.Empty)
            {
                cmbStaffDataColumn.Items.Clear();
                string tableName = cmbStaffDataTable.Text;
                string query = "select * from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + tableName + "'ORDER BY COLUMN_NAME ";
                DataTable table = dal.ExecuteReader(query);

                cmbStaffDataColumn.Items.Add("NULL");

                foreach (DataRow row in table.Rows)
                {
                    cmbStaffDataColumn.Items.Add(row["COLUMN_NAME"]);
                }
            }
            else
            {
                MessageBox.Show(this, "Set a value for staff data table first");
            }
            
        }

        private void LoadTables()
        {
            string query = "select * from INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";
            DataTable table = dal.ExecuteReader(query);

            cmbComboDataTable.Items.Add("NULL");
            cmbStaffDataView.Items.Add("NULL");

            foreach (DataRow row in table.Rows)
            {
                if (row["TABLE_TYPE"].ToString() == "BASE TABLE")
                {
                    cmbStaffDataTable.Items.Add(row["TABLE_NAME"]);
                }
                else if (row["TABLE_TYPE"].ToString() == "VIEW")
                {
                    cmbStaffDataView.Items.Add(row["TABLE_NAME"]);
                }
                cmbComboDataTable.Items.Add(row["TABLE_NAME"]);
            }
        }

        private void LoadDataElements()
        {
            var dataElements = GlobalData._context.EnforceDataElementsViews.Where(u => u.SubDatasetID.ToString() == cmbSubDataset.SelectedValue.ToString()).OrderBy(u => u.Description).ToList();
            cmbDataElement.DataSource = null;

            foreach (var item in dataElements)
            {
                //cboDataElement.Items.Add(item.Description);
                cmbDataElement.DataSource = dataElements;
                cmbDataElement.ValueMember = "ID";
                cmbDataElement.DisplayMember = "Description";
            }
        }

        private void LoadSubDatasets()
        {
            var subdatasets = GlobalData._context.EnforceSubDatasetViews.Where(u => u.DatasetID.ToString() == cmbDataset.SelectedValue.ToString()).OrderBy(u => u.Description).ToList();
            cmbSubDataset.DataSource = null;

            foreach (var item in subdatasets)
            {
                //cboDataElement.Items.Add(item.Description);
                cmbSubDataset.DataSource = subdatasets;
                cmbSubDataset.ValueMember = "ID";
                cmbSubDataset.DisplayMember = "Description";
            }
        }

        private void LoadDatasets()
        {
            try
            {
                var datasets = GlobalData._context.EnforceDatasets.OrderBy(u => u.Description).ToList();
                cmbDataset.DataSource = null;

                foreach (var item in datasets)
                {
                    //cboDataElement.Items.Add(item.Description);
                    cmbDataset.DataSource = datasets;
                    cmbDataset.ValueMember = "ID";
                    cmbDataset.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateText(string columnName, string tableName, decimal ChangeID, string newValue)
        {
            try
            {
                string colname = columnName;
                string tablename = tableName;
                decimal id = ChangeID;
                string value = newValue;
                dal.ClearParameters();
                dal.CreateParameter("@NewValue", value, DbType.String);
                dal.CreateParameter("@ColumnName", colname, DbType.String);
                dal.CreateParameter("@TableName", tablename, DbType.String);
                dal.CreateParameter("@ChangeID", id, DbType.Decimal);
                string query = "Update " + tableName + " set " + columnName + " = @NewValue where ID = '" + ChangeID + "'";
                //string query = "Update @TableName set @ColumnName = @NewValue where ID = @ChangeID";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbDataset_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadSubDatasets();
            cmbDataElement.DataSource = null;
            cmbDataElement.Text = string.Empty;
        }

        private void cmbSubDataset_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDataElements();
        }



        private void cmbDataElement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var dataElementDetails = GlobalData._context.EnforceDataElements.SingleOrDefault(u=>u.ID.ToString() == cmbDataElement.SelectedValue.ToString());

            if (dataElementDetails != null)
            {
                clearDetails();
                cmbDataType.Text = dataElementDetails.DataType == null ? "" : dataElementDetails.DataType; ;
                cmbControlTypes.Text = dataElementDetails.ControlType == null ? "" : dataElementDetails.ControlType; ;
                cmbComboDataTable.Text = dataElementDetails.ComboDataTable == null ? "" : dataElementDetails.ComboDataTable; ;
                cmbStaffDataTable.Text = dataElementDetails.StaffDataTable == null ? "" : dataElementDetails.StaffDataTable; ;
                cmbStaffDataView.Text = dataElementDetails.StaffDataView == null ? "" : dataElementDetails.StaffDataView; ;
                cmbStaffDataColumn.Text = dataElementDetails.StaffDataColumn == null ? "" : dataElementDetails.StaffDataColumn;
            }
            else
            {
                clearDetails();
            }
        }

        private void clearDetails()
        {
            cmbDataType.Items.Clear();
            cmbControlTypes.Items.Clear();
            cmbComboDataTable.Items.Clear();
            cmbStaffDataTable.Items.Clear();
            cmbStaffDataView.Items.Clear();
            cmbStaffDataColumn.Items.Clear();
            LoadDetails();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbDataset.SelectedItem = null;
            cmbDataset.DataSource = null;

            cmbSubDataset.SelectedItem = null;
            cmbSubDataset.DataSource = null;

            cmbDataElement.SelectedItem = null;
            cmbDataElement.DataSource = null;

            cmbDataType.Items.Clear();
            cmbControlTypes.Items.Clear();
            cmbComboDataTable.Items.Clear();
            cmbStaffDataTable.Items.Clear();
            cmbStaffDataView.Items.Clear();
            cmbStaffDataColumn.Items.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var dataElements = GlobalData._context.EnforceDataElements.SingleOrDefault(u => u.ID.ToString() == cmbDataElement.SelectedValue.ToString());

                if (dataElements != null)
                {
                    dataElements.DataType = cmbDataType.Text;
                    dataElements.ControlType = cmbControlTypes.Text;
                    dataElements.ComboDataTable = cmbComboDataTable.Text;
                    dataElements.StaffDataTable = cmbStaffDataTable.Text;
                    dataElements.StaffDataView = cmbStaffDataView.Text;
                    dataElements.StaffDataColumn = cmbStaffDataColumn.Text;

                    GlobalData._context.SubmitChanges();
                    MessageBox.Show("Done!");
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnClearD_Click(object sender, EventArgs e)
        {
            clearDetails();
        }

        private void cmbStaffDataTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadStaffTable();
        }

        private void btnUpdateMenuForm_Click(object sender, EventArgs e)
        {
            var datasets = GlobalData._context.EnforceDatasets.SingleOrDefault(u => u.Name == cboForm.Text);

            if (datasets != null)
            {
                datasets.MenuItem = cboMenuItem.Text;

                GlobalData._context.SubmitChanges();
                MessageBox.Show("Done!");
            }
            else
            {
                MessageBox.Show("No form like that boss");
            }
        }
    }
}
