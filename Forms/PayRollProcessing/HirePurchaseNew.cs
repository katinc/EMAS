using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayer;

namespace eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS
{
    public partial class Hire_Purchase : Form
    {
        HirePurchase hirePurchase;
        HirePurchaseManip hirePurchaseManip;
        Employee staffInformation;
        private IDAL dal;

        public Hire_Purchase()
        {
            InitializeComponent();
            hirePurchase = new HirePurchase();
            hirePurchaseManip = new HirePurchaseManip();
            staffInformation = new Employee();
            this.dal = new DAL();
        }

        private void Hire_Purchase_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Assign();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "IDNS Human Resource", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void findbtn_Click(object sender, EventArgs e)
        {

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ASSINGNMENTS
        private void Assign()
        {
            hirePurchase.ItemDescription = itemDescriptiontxt.Text;
            hirePurchase.ItemCost = itemCosttxt.Text;
            hirePurchase.SpreadOver = spreadOvertxt.Text;
            hirePurchase.PurchaseDate = purchaseDate.Value;
            hirePurchase.RepaymentFrom = fromDate.Value;
            hirePurchase.RepaymentTo = toDate.Value;
            hirePurchase.MonthlyInstallment = monthlyInstallmenttxt.Text;
            hirePurchase.AmountToBePaid = amountToBePaidtxt.Text;
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            itemCosttxt.Clear();
            itemDescriptiontxt.Clear();
            spreadOvertxt.Clear();
            fromDate.Value = DateTime.Now;
            toDate.Value = DateTime.Now;
            monthlyInstallmenttxt.Clear();
            amountToBePaidtxt.Clear();
            purchaseDate.Value = DateTime.Now;

        }
        #endregion
    }
}
