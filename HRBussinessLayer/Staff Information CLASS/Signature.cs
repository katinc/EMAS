using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Signature
    {
        private int id;
        private string name;
        private string position;
        private string department;
        private string cc;

        public Signature()
        {
            this.id = 0;
            this.name = string.Empty;
            this.position = string.Empty;
            this.department = string.Empty;
            this.cc = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Cc
        {
            get { return cc; }
            set { cc = value; }
        }

    }
}
