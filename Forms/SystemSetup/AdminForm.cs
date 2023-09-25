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
    public partial class AdminForm : Form
    {
        DataReference.Administrator adminTable = new DataReference.Administrator();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void cboFacility_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboFacility.DataSource = null;
                cboFacility.Items.Clear();

                var facilities = GlobalData._context.AdminFacilities.ToList();

                if (facilities.Count() > 0)
                {
                    foreach (var facility in facilities)
                    {
                        cboFacility.Items.Add(facility.Abbreviation);
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cboFacility_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                adminTable.Facility = cboFacility.Text;

                GlobalData._context.SubmitChanges();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                adminTable = GlobalData._context.Administrators.First(u=>u.ID == 1);

                cboFacility_DropDown(this, EventArgs.Empty);
                cboFacility.Text = adminTable.Facility;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnDatasets_Click(object sender, EventArgs e)
        {
            Datasets form = new Datasets();
            //form.MdiParent = eMAS.MainMDI;
            form.Show();
            
        }
    }
}
