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
    public partial class RecommendReviewSalaryForm : Form
    {
        private IDAL dal;
        public RecommendReviewSalaryForm()
        {
            InitializeComponent();
            this.dal = new DAL();
        }

        private void RecommendReviewSalaryForm_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}
