using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;

namespace eMAS.Forms.Reports
{
    public partial class OverTimeReportSelect : Form
    {
        private IDAL dal;

        public OverTimeReportSelect()
        {
            InitializeComponent();
            this.dal = new DAL();
        }

        private void OverTimeReportSelect_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}
