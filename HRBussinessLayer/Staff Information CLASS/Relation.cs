using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Relation
    {
        
        private Relationship relationship;
        private string type;
        private Employee employee;
        private string name;
        private string telephone;
        private Occupation occupation;
        private Town placeOfBirth;
        private string address;
        private Nullable<DateTime> dob;
        private bool archived;
        private User user;
        private int id;

        public Relation()
        {
            try
            {
                this.id = 0;
                this.relationship = new Relationship();
                this.type = string.Empty;
                this.employee = new Employee();
                this.name = string.Empty;
                this.telephone = string.Empty;
                this.occupation = new Occupation();
                this.placeOfBirth = new Town();
                this.address = string.Empty;
                this.archived = false;
                this.user = new User();
                this.dob = DateTime.Today;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public Relation(int id, int staffCode, string staffID, string name, int relationshipID, string relation, string type, int occupationID, string occupation, int placeOfBirthID, string placeOfBirth, string telephone, string address, Nullable<DateTime> dob)
        {
            try
            {
                this.relationship = new Relationship();
                this.occupation = new Occupation();
                this.placeOfBirth = new Town();
                this.employee = new Employee();
                this.id = id;
                this.employee.StaffID = staffID;
                this.employee.ID = staffCode;
                this.relationship.ID = relationshipID;
                this.relationship.Description = relation;
                this.type = type;
                this.name = name;
                this.telephone = telephone;
                this.occupation.Description = occupation;
                this.occupation.ID = occupationID;
                this.placeOfBirth.Description = placeOfBirth;
                this.placeOfBirth.ID = placeOfBirthID;
                this.address = address;
                this.DOB = dob;
                this.archived = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        public Relationship Relationship
        {
            get { return relationship; }
            set { relationship = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public Occupation Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public Town POB
        {
            get { return placeOfBirth; }
            set { placeOfBirth = value; }
        }

        public Nullable<DateTime> DOB
        {
            get { return dob; }
            set
            {
                dob = value;
            }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
