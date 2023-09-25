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

namespace eMAS.Forms.EmployeeManagement
{
    public partial class LeaveLetterApplcationSignature : Form
    {
        public LeaveLetterApplcationSignature()
        {
            InitializeComponent();
        }

        private bool ValidateFields()
        {
            bool result = true;

            try
            {
                errorProvider1.Clear();
                if (txtSigneeName.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider1.SetError(txtSigneeName, "Please enter name");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void LeaveLetterApplcationSignature_Load(object sender, EventArgs e)
        {
            try
            {
                var getdata = GlobalData._context.LeaveLetterSignatures.FirstOrDefault();
            if (getdata != null)
            {
                txtSignatureCC.Text = getdata.cc.Trim();
                txtSigneeDepartment.Text = getdata.department.Trim();
                txtSigneeName.Text = getdata.name.Trim();
                txtSigneePosition.Text = getdata.position.Trim();
            }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("There was an error. Contact your administrator");
                //throw;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {

                    var signature = GlobalData._context.LeaveLetterSignatures.FirstOrDefault();

                    if (signature == null)
                    {
                        var sign = new DataReference.LeaveLetterSignature
                        {
                            id = 1,
                            name = txtSigneeName.Text,
                            position = txtSigneePosition.Text,
                            department = txtSigneeDepartment.Text,
                            cc = txtSignatureCC.Text,
                        };
                        GlobalData._context.LeaveLetterSignatures.InsertOnSubmit(sign);
                    }
                    else
                    {
                        signature.name = txtSigneeName.Text;
                        signature.position = txtSigneePosition.Text;
                        signature.department = txtSigneeDepartment.Text;
                        signature.cc = txtSignatureCC.Text;
                    }

                    GlobalData._context.SubmitChanges();
                    MessageBox.Show("Successfully saved");


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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSigneePosition.Text = string.Empty;
            txtSigneeName.Text = string.Empty;
            txtSigneeDepartment.Text = string.Empty;
            txtSignatureCC.Text = string.Empty;
        }




    }
}
