using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;

namespace eMAS.Forms.SystemSetup
{
    public partial class ShiftsView : Form
    {
        public DALHelper dal;
        private Shifts shiftsForm;

        public ShiftsView(Shifts shiftsForm)
        {
            InitializeComponent();
            dal = new DALHelper();
            this.shiftsForm = shiftsForm;
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        public ShiftsView()
        {
            InitializeComponent();
            dal = new DALHelper();
            this.shiftsForm = new Shifts();
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                shiftsForm.PopulateView(grid.CurrentRow);
                this.Close();
            }
        }

        private void ShiftsView_Load(object sender, EventArgs e)
        {
            try
            {
                dal.OpenConnection();
                grid.DataSource = dal.ExecuteReader("Select * from WorkShifts Where Archived='False'");
                if (grid.ColumnCount > 0)
                {
                    grid.Columns["ID"].Visible = false;
                    grid.Columns["DateModified"].Visible = false;
                    grid.Columns["UserID"].Visible = false;
                    grid.Columns["Archived"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    dal.OpenConnection();
                    dal.ExecuteReader("Update WorkShifts Set Archived ='True' where ID = " + grid.CurrentRow.Cells["ID"].Value.ToString());
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }
    }
}
