using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class SSNITContribution
    {
        private int id;
        private decimal employerPercentage;
        private decimal employeePercentage;
        private decimal exemptEmployerPercentage;
        private decimal exemptEmployeePercentage;
        private decimal ssnitFirstTierRate;
        private decimal secondTierRate;
        private decimal providentFundEmployeeRate;
        private decimal providentFundEmployerRate;
        private decimal exemptSSNITFirstTierRate;

        public SSNITContribution()
        {
            try
            {
                this.id = 0;
                this.employeePercentage = 0;
                this.employerPercentage = 0;
                this.exemptEmployeePercentage = 0;
                this.exemptEmployerPercentage = 0;
                this.ssnitFirstTierRate = 0;
                this.secondTierRate = 0;
                this.providentFundEmployeeRate = 0;
                this.providentFundEmployerRate = 0;
                this.exemptSSNITFirstTierRate = 0;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public decimal EmployerPercentage
        {
            get { return employerPercentage; }
            set { employerPercentage = value; }
        }

        public decimal EmployeePercentage
        {
            get { return employeePercentage; }
            set { employeePercentage = value; }
        }

        public decimal ExemptEmployerPercentage
        {
            get { return exemptEmployerPercentage; }
            set { exemptEmployerPercentage = value; }
        }

        public decimal ExemptEmployeePercentage
        {
            get { return exemptEmployeePercentage; }
            set { exemptEmployeePercentage = value; }
        }

        public decimal SSNITFirstTierRate
        {
            get { return ssnitFirstTierRate; }
            set { ssnitFirstTierRate = value; }
        }

        public decimal SecondTierRate
        {
            get { return secondTierRate; }
            set { secondTierRate = value; }
        }

        public decimal ProvidentFundEmployeeRate
        {
            get { return providentFundEmployeeRate; }
            set { providentFundEmployeeRate = value; }
        }
        public decimal ProvidentFundEmployerRate
        {
            get { return providentFundEmployerRate; }
            set { providentFundEmployerRate = value; }
        }

        public decimal ExemptSSNITFirstTierRate
        {
            get { return exemptSSNITFirstTierRate; }
            set { exemptSSNITFirstTierRate = value; }
        }
    }
}
