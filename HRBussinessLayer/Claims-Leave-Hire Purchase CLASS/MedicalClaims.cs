using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Validation;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Drawing;

namespace HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS
{
    public class MedicalClaims
    {
        private int id;
        private Employee employee;
        private string patientName;
        private Nullable<DateTime> patientDOB;
        private string age;
        private Relationship relationship;
        private string opdNumber;
        private string diagnosis;
        private string doctorName;
        private bool doctorSign;
        private Nullable<DateTime> doctorDate;
        private string supervisorName;
        private bool supervisorSign;
        private decimal serviceCost;
        private decimal medicineCost;
        private decimal totalCost;
        private HealthFacilityType healthFacilityType;
        private string healthFacilityName;
        private Nullable<DateTime> paymentDate;
        private Nullable<DateTime> entryDate;
        private string receiptNo;
        private bool paid;
        private bool paidToStaff;
        private string paymentType;
        private string chequeNumber;
        private Nullable<DateTime> paidToStaffDate;
        private bool onPayRoll;
        private bool archived;
        private User user;
        private decimal approvedAmount;
        private bool approved;
        private string approvedUser;
        private string approvedUserStaffID;
        private Nullable<DateTime> approvedDate;
        private Nullable<DateTime> approvedTime;
        private bool rejected;
        private string rejectedUser;
        private string rejectedUserStaffID;
        private Nullable<DateTime> rejectedDate;
        private Nullable<DateTime> rejectedTime;
        private string reason;

        public MedicalClaims()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.patientName = string.Empty;
                this.patientDOB = null;
                this.age = string.Empty;
                this.relationship = new Relationship();
                this.opdNumber = string.Empty;
                this.diagnosis = string.Empty;
                this.doctorName = string.Empty;
                this.doctorSign = false;
                this.doctorDate = null;
                this.supervisorName = string.Empty;
                this.supervisorSign = false;
                this.serviceCost = 0;
                this.medicineCost = 0;
                this.totalCost = 0;
                this.healthFacilityType = new HealthFacilityType();
                this.healthFacilityName = string.Empty;
                this.paymentDate = null;
                this.entryDate = null;
                this.receiptNo = string.Empty;
                this.paid = false;
                this.paidToStaff = false;
                this.paymentType = string.Empty;
                this.chequeNumber = string.Empty;
                this.paidToStaffDate = null;
                this.onPayRoll = false;
                this.archived = false;
                this.user = new User();
                this.approvedAmount = 0;
                this.approvedDate = null;
                this.approvedTime = null;
                this.approvedUser = string.Empty;
                this.approvedUserStaffID = string.Empty;
                this.approved = false;
                this.rejected = false;
                this.rejectedDate = null;
                this.rejectedUserStaffID = string.Empty;
                this.rejectedTime = null;
                this.rejectedUser = string.Empty;
                this.reason = string.Empty;
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

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public string  PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }

        public Nullable<DateTime> PatientDOB
        {
            get { return patientDOB; }
            set { patientDOB = value; }
        }

        public Relationship Relationship
        {
            get { return relationship; }
            set { relationship = value; }
        }

        public string OPDNumber
        {
            get { return opdNumber; }
            set { opdNumber = value; }
        }

        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        public string DoctorName
        {
            get { return doctorName; }
            set { doctorName = value; }
        }

        public Nullable<DateTime> DoctorDate
        {
            get { return doctorDate; }
            set { doctorDate = value; }
        }

        public bool DoctorSign
        {
            get { return doctorSign; }
            set { doctorSign = value; }
        }

        public string SupervisorName
        {
            get { return supervisorName; }
            set { supervisorName = value; }
        }

        public bool SupervisorSign
        {
            get { return supervisorSign; }
            set { supervisorSign = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public decimal ServiceCost
        {
            get { return serviceCost; }
            set { serviceCost = value; }
        }

        public decimal MedicineCost
        {
            get { return medicineCost; }
            set { medicineCost = value; }
        }

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public HealthFacilityType HealthFacilityType
        {
            get { return healthFacilityType; }
            set { healthFacilityType = value;}
        }

        public string HealthFacilityName
        {
            get { return healthFacilityName; }
            set
            {
                if (Validator.NullOrEmptyStringValidator(value))
                {
                    healthFacilityName = value;
                }
                else
                {
                    if (!Validator.Errors.ContainsKey("HealthFacilityName"))
                    {
                        Validator.Errors.Add("HealthFacilityName", "Please enter a health facility name");
                    }
                }
            }
        }

        public Nullable<DateTime> PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value;}
        }

        public Nullable<DateTime> EntryDate
        {
            get { return entryDate; }
            set { entryDate = value;}
        }

        public string ReceiptNo
        {
            get { return receiptNo; }
            set { receiptNo = value; }
        }

        public bool Paid
        {
            get { return paid; }
            set { paid = value; }
        }

        public bool PaidToStaff
        {
            get { return paidToStaff; }
            set { paidToStaff = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        public string ChequeNumber
        {
            get { return chequeNumber; }
            set { chequeNumber = value; }
        }

        public Nullable<DateTime> PaidToStaffDate
        {
            get { return paidToStaffDate; }
            set { paidToStaffDate = value; }
        }

        public bool OnPayRoll
        {
            get { return onPayRoll; }
            set { onPayRoll = value; }
        }

        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }

        public decimal ApprovedAmount
        {
            get { return approvedAmount; }
            set { approvedAmount = value; }
        }

        public Nullable<DateTime> ApprovedDate
        {
            get { return approvedDate; }
            set { approvedDate = value; }
        }

        public Nullable<DateTime> ApprovedTime
        {
            get { return approvedTime; }
            set { approvedTime = value; }
        }

        public string ApprovedUser
        {
            get { return approvedUser; }
            set { approvedUser = value; }
        }

        public string ApprovedUserStaffID
        {
            get { return approvedUserStaffID; }
            set { approvedUserStaffID = value; }
        }

        public bool Rejected
        {
            get { return rejected; }
            set { rejected = value; }
        }

        public Nullable<DateTime> RejectedDate
        {
            get { return rejectedDate; }
            set { rejectedDate = value; }
        }

        public Nullable<DateTime> RejectedTime
        {
            get { return rejectedTime; }
            set { rejectedTime = value; }
        }

        public string RejectedUser
        {
            get { return rejectedUser; }
            set { rejectedUser = value; }
        }

        public string RejectedUserStaffID
        {
            get { return rejectedUserStaffID; }
            set { rejectedUserStaffID = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public string Age
        {
            get
            {
                string age = String.Empty;
                try
                {
                    int yrcheck = Hospital.CurrentDate.Year - DateTime.Parse(patientDOB.ToString()).Year;
                    int monthcheck = Hospital.CurrentDate.Month - DateTime.Parse(patientDOB.ToString()).Month;
                    int daycheck = Hospital.CurrentDate.Day - DateTime.Parse(patientDOB.ToString()).Day;
                    if (yrcheck == 0)
                    {
                        if (daycheck == 0 || daycheck > 0)
                            age = monthcheck + " months";
                        else
                            age = monthcheck - 1 + " months";
                    }
                    else if (yrcheck == 1)
                    {
                        if (monthcheck < 0)
                        {
                            if (daycheck > 0 || daycheck == 0)
                                age = monthcheck + 12 + " months";
                            else if (daycheck < 1)
                                age = (monthcheck - 1) + 12 + " months";
                        }
                        else if (monthcheck == 0)
                        {
                            if (daycheck == 0 || daycheck > 0)
                                age = "1 yr";
                            else if (daycheck < 0)
                                age = "11 months";
                            else if (monthcheck > 0)
                                age = "1 yr";
                        }
                    }
                    else if (yrcheck > 1)
                    {
                        if (monthcheck > 0)
                            age = yrcheck + " yrs";
                        else if (monthcheck < 0)
                            age = yrcheck - 1 + " yrs";
                        else if (monthcheck == 0)
                        {
                            if (daycheck == 0 && daycheck > 0)
                                age = yrcheck + " yrs";
                            else
                                age = yrcheck - 1 + " yrs";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    age = "N/A";
                }
                return age;
            }
            set { age = this.Age; }
        }   
    }
}
