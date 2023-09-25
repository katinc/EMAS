using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ReviewSalaryForm : Form
    {
        private IDAL dal;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public ReviewSalaryForm()
        {
            InitializeComponent();
            this.dal = new DAL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void ReviewSalaryForm_Load(object sender, EventArgs e)
        {
           // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnSave.Visible = getPermissions.CanAdd;
               // findbtn.Visible = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }
    }
}
