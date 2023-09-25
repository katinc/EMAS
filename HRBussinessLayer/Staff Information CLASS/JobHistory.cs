using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class JobHistory
    {
        private string fromMonth;
        private string fromYear;
        private string toMonth;
        private string toYear;
        private string employementType;
        private string post;
        private string department;
        private string location;
        private string reportTo;

        public JobHistory()
        {
            fromMonth = string.Empty;
            fromYear = string.Empty;
            toMonth = string.Empty;
            toYear = string.Empty;
            employementType = string.Empty;
            post = string.Empty;
            department = string.Empty;
            location = string.Empty;
            reportTo = string.Empty;
        }

        public JobHistory(string from, string to, string employementType, string post, string department, string location, string reportTo)
        {

            this.fromYear = from;
            this.toYear = to;
            this.employementType = employementType;
            this.post = post;
            this.department = department;
            this.location = location;
            this.reportTo = reportTo;
        }


        public string FromMonth
        {
            get { return fromMonth; }
            set { fromMonth = value; }
        }

        public string FromYear
        {
            get { return fromYear; }
            set { fromYear = value; }
        }

        public string ToMonth
        {
            get { return toMonth; }
            set { toMonth = value; }
        }

        public string ToYear
        {
            get { return toYear; }
            set { toYear = value; }
        }
       
        public string EmployementType
        {
            get { return employementType; }
            set { employementType = value; }
        }

        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string ReportTo
        {
            get { return reportTo; }
            set { reportTo = value; }
        }
    }
}
