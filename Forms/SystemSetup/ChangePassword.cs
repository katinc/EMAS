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

namespace eMAS.Forms.SystemSetup
{
    public partial class ChangePassword : Form
    {
        private DALHelper dalHelper;
        private IDAL dal;
        private string userID;

        public ChangePassword()
        {
            InitializeComponent();
            dalHelper = new DALHelper();
            userID = string.Empty;
            groupBox2.Enabled = false;
            userNameTextBox.Select();
            dal = new DAL();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            EnableNew();
        }

        private void EnableNew()
        {
            if (oldPasswordTextBox.Text.Trim() != string.Empty && userNameTextBox.Text.Trim() != string.Empty)
            {
                try
                {
                    object result = dalHelper.ExecuteScalar("Select ID From Users Where UserName='" + userNameTextBox.Text + "' And Password ='" + oldPasswordTextBox.Text.Trim() + "'");

                    if (result != null)
                    {
                        userID = result.ToString();
                        groupBox2.Enabled = true;
                    }
                    else
                    {
                        groupBox2.Enabled = false;
                        userID = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (newPasswordTextBox.Text.Trim() != string.Empty)
                {
                    dalHelper.ExecuteNonQuery("Update Users Set password='" + newPasswordTextBox.Text + "' Where ID=" + userID);
                    Clear();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void Clear()
        {
            oldPasswordTextBox.Clear();
            newPasswordTextBox.Clear();
            userNameTextBox.Clear();
            groupBox2.Enabled = false;
        }

        private void oldPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableNew();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}
