using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using Microsoft.VisualBasic;
using Session_Framework;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class SponsorShipGuarantersForm : Form
    {
        private TrainingBondForm parentForm;
        private HRBussinessLayer.System_Setup_Class.SponsorshipGuaranter guaranter;
        private MemoryStream stream;
        private HRDataAccessLayer.System_Setup_Data_Control.StaffIdentificationTypesDataMapper identityDataMapper;
        private IList<StaffIdentificationType> lstStaffIdentificationType;

        bool editMode = false;
        public SponsorShipGuarantersForm()
        {
            InitializeComponent();
            stream = new MemoryStream();
            lstStaffIdentificationType = new List<StaffIdentificationType>();
            identityDataMapper = new HRDataAccessLayer.System_Setup_Data_Control.StaffIdentificationTypesDataMapper();
        }
        public SponsorShipGuarantersForm(TrainingBondForm parentForm,SponsorshipGuaranter guaranter,bool editMode)
        {
            InitializeComponent();
            this.parentForm=parentForm;
            this.guaranter = guaranter;
            this.editMode = editMode;
            stream = new MemoryStream();
            lstStaffIdentificationType = new List<StaffIdentificationType>();
            identityDataMapper = new HRDataAccessLayer.System_Setup_Data_Control.StaffIdentificationTypesDataMapper();
            try
            {
                txtDesignation.Text = guaranter.Designation;
                txtEmailAddress.Text = guaranter.Email;
                txtEmployeeNumber.Text = guaranter.EmpNumber;
                txtGuaranterName.Text = guaranter.GuaranterName;
                txtMobileNumber.Text = guaranter.MobileNo;
                txtOrganization.Text = guaranter.Organization;

                cmdIdentificationType_DropDown(this, EventArgs.Empty);
                cmdIdentificationType.SelectedItem = guaranter.IdentificationType.CardName;

                txtPassPortNumber.Text = guaranter.PassPortNo;
                txtPostalAddress.Text = guaranter.Address;
                txtTelNo.Text = guaranter.TelNo;
                chkActive.Checked = guaranter.Active;
                dtpExpiryDate.Value = guaranter.PassPortExpiryDate;
                dtpIssueDate.Value = guaranter.PassPortIssueDate.Date;

                stream = new MemoryStream(guaranter.Photo);
                pictureBox.Image = Image.FromStream(stream);
            }
            catch (Exception e1) { }
            
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtGuaranterName.Text == string.Empty)
                errorProvider1.SetError(txtGuaranterName, "Guaranter's Name is required!");
            else if (txtDesignation.Text == string.Empty)
                errorProvider1.SetError(txtDesignation, "Designation is required!");
            else if (txtOrganization.Text == string.Empty)
                errorProvider1.SetError(txtOrganization, "Organization is required!");
            else if (txtEmployeeNumber.Text == string.Empty)
                errorProvider1.SetError(txtEmployeeNumber, "Employee Number is required!");
            else if(txtTelNo.Text!=string.Empty && !Information.IsNumeric(txtTelNo.Text))
                errorProvider1.SetError(txtTelNo, "A Valid Mobile Number is required!");
            else if (txtMobileNumber.Text != string.Empty && !Information.IsNumeric(txtMobileNumber.Text))
                errorProvider1.SetError(txtMobileNumber, "A Valid Mobile Number is required!");
            else if(txtEmailAddress.Text!=string.Empty && !AppUtils.isValidEmail(txtEmailAddress.Text))
                errorProvider1.SetError(txtEmailAddress, "A Valid Email Address is required!");
            else if (cmdIdentificationType.Text!=string.Empty && txtPassPortNumber.Text==string.Empty)
            errorProvider1.SetError(txtPassPortNumber, "A Valid ID Number is required!");
            else{

                if (pictureBox.Image != null)
                {
                    stream = new MemoryStream();
                    pictureBox.Image.Save(stream, ImageFormat.Jpeg);
                    
                }
                if (guaranter == null)
                {
                    guaranter = new SponsorshipGuaranter();
                    guaranter.Archived = false;
                }

                guaranter.GuaranterName = txtGuaranterName.Text;
                guaranter.EmpNumber = txtEmployeeNumber.Text;
                guaranter.Designation = txtDesignation.Text;
                guaranter.Email = txtEmailAddress.Text;
                guaranter.Address = txtPostalAddress.Text;
                guaranter.Active = chkActive.Checked;
                guaranter.MobileNo = txtMobileNumber.Text;
                guaranter.Organization = txtOrganization.Text;
                guaranter.PassPortExpiryDate = dtpExpiryDate.Value.Date;
                guaranter.PassPortIssueDate = dtpIssueDate.Value.Date;
                guaranter.PassPortNo = txtPassPortNumber.Text;
                guaranter.Address = txtPostalAddress.Text.Trim();
                guaranter.TelNo = txtTelNo.Text;
                guaranter.Photo = stream.GetBuffer();

                if(cmdIdentificationType.SelectedIndex>=0 && txtPassPortNumber.Text!=string.Empty)
                guaranter.IdentificationType = lstStaffIdentificationType[cmdIdentificationType.SelectedIndex];

               
               // parentForm.trainingBond.SponsorshipGuaranters.Add(guaranter);
                if (editMode == true){

                    parentForm.EditToGuarantersGrid(guaranter, parentForm.gridGuaranters.CurrentRow.Index);
                    parentForm.lstGuaranters[parentForm.gridGuaranters.CurrentRow.Index] = guaranter;
                }
                else
                {
                    parentForm.AddToGuarantersGrid(guaranter);
                    btnClear_Click(sender, e);
                }
                   
            }
        }

     
        private void SponsorShipGuarantersForm_Load(object sender, EventArgs e)
        {
            chkActive.Checked = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGuaranterName.Clear();
            txtDesignation.Clear();
            txtOrganization.Clear();
            txtEmployeeNumber.Clear();
            txtTelNo.Clear();
            txtMobileNumber.Clear();
            txtEmailAddress.Clear();
            txtPostalAddress.Clear();
            cmdIdentificationType.Text = string.Empty;
            cmdIdentificationType.Items.Clear();
            txtPassPortNumber.Clear();
            dtpExpiryDate.ResetText();
            dtpExpiryDate.Checked = true;
            dtpIssueDate.ResetText();
            dtpIssueDate.Checked = true;
            chkActive.Checked = true;
            pictureBox.Image = global::eMAS.Properties.Resources._default;
            guaranter = new SponsorshipGuaranter();
            editMode = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opd = new OpenFileDialog())
            {
                opd.Filter = "Guaranter's Image|*.png;*.bmp;*.jpg";
                if (opd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(opd.FileName);
                }
            }
        }

        private void cmdIdentificationType_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstStaffIdentificationType = identityDataMapper.getData();

                cmdIdentificationType.Items.Clear();
                
                foreach (var item in lstStaffIdentificationType)
                {
                    cmdIdentificationType.Items.Add(item.CardName);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

        //private void txtTelNo_TextChanged(object sender, EventArgs e)
        //{
        //    //if (System.Text.RegularExpressions.Regex.IsMatch(txtTelNo.Text, "  ^ [0-9]"))
        //    //{
        //    //    txtTelNo.Text = "";
        //    //}

        //    MessageBox.Show("TextChanged");
            
        //}
        //private void txtTelNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void txtTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
