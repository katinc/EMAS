using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS
{
    public class HirePurchase
    {
        private string itemDescription;
        private string itemCost;
        private string spreadOver;
        private DateTime repaymentFrom;
        private DateTime repaymentTo;
        private string monthlyInstallment;
        private string amountToBePaid;
        private DateTime purchaseDate;

        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        public string ItemCost
        {
            get { return itemCost; }
            set
            {
                    itemCost = value;
            }
        }

        public string SpreadOver
        {
            get { return spreadOver; }
            set
            {
                    spreadOver = value;
            }
        }

        public DateTime RepaymentFrom
        {
            get { return repaymentFrom; }
            set { repaymentFrom = value; }
        }

        public DateTime RepaymentTo
        {
            get { return repaymentTo; }
            set { repaymentTo = value; }
        }

        public string MonthlyInstallment
        {
            get { return monthlyInstallment; }
            set
            {
                    monthlyInstallment = value;
            }
        }

        public string AmountToBePaid
        {
            get { return amountToBePaid; }
            set
            {
                    amountToBePaid = value;
            }
        }

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }
    }
}
