using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Validation;
using System.Drawing;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffTraining
    {
        private int id;
        private Employee employee;
        private TrainingType trainingType;
        private InServiceTraining ist;
        private DateTime startDate;
        private DateTime trainingDate;
        private DateTime endDate;
        private string organisers;
        private string certificateAwarded;
        private string venue;
        private float costFee;
        private float accomodationFee;
        private float transportationFee;
        private string totalCost;
        private LocationType locationType;
        private Sponsor sponsor;
        private User user;
        private DateTime dateEntered;
        private DateTime serverTime;
        private DateTime serverDate;
        private bool archived;
        private int archivererID;
        private Nullable<DateTime> archivedTime;

        public StaffTraining()
        {
            this.id = 0;
            this.employee = new Employee();
            this.trainingType = new TrainingType();
            this.ist = new InServiceTraining();
            this.trainingDate = DateTime.Today;
            this.startDate = DateTime.Today;
            this.endDate = DateTime.Today;
            this.organisers = string.Empty;
            this.certificateAwarded = string.Empty;
            this.venue = string.Empty;
            this.costFee = 0;
            this.accomodationFee = 0;
            this.transportationFee = 0;
            this.totalCost = "0";
            this.locationType = new LocationType();
            this.sponsor = new Sponsor();
            this.user = new User();
            this.dateEntered = DateTime.Today;
            this.serverDate = DateTime.Today;
            this.serverTime = DateTime.Today;
            this.archived = false;
            this.archivererID = 0;
            this.archivedTime = null;
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

        public TrainingType TrainingType
        {
            get { return trainingType; }
            set { trainingType = value; }
        }

        public InServiceTraining InServiceTraining
        {
            get { return ist; }
            set { ist = value; }
        }

        public DateTime TrainingDate
        {
            get { return trainingDate; }
            set { trainingDate = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string Organisers
        {
            get { return organisers; }
            set { organisers = value; }
        }

        public string CertificateAwarded
        {
            get { return certificateAwarded; }
            set { certificateAwarded = value; }
        }

        public string Venue
        {
            get { return venue; }
            set { venue = value; }
        }

        public float CostFee
        {
            get { return costFee; }
            set { costFee = value; }
        }

        public float AccomodationFee
        {
            get { return accomodationFee; }
            set { accomodationFee = value; }
        }

        public float TransportationFee
        {
            get { return transportationFee; }
            set { transportationFee = value; }
        }

        public string TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public LocationType LocationType
        {
            get { return locationType; }
            set { locationType = value; }
        }

        public Sponsor Sponsor
        {
            get { return sponsor; }
            set { sponsor = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public DateTime DateEntered
        {
            get { return dateEntered; }
            set { dateEntered = value; }
        }

        public DateTime ServerTime
        {
            get { return serverTime; }
            set { serverTime = value; }
        }

        public DateTime ServerDate
        {
            get { return serverDate; }
            set { serverDate = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public int ArchivererID
        {
            get { return archivererID; }
            set { archivererID = value; }
        }

        public Nullable<DateTime> ArchiveTime
        {
            get { return archivedTime; }
            set { archivedTime = value;}
        }       
    }
}
