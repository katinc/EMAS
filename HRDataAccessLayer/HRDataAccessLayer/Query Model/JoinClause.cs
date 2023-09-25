using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRDataAccessLayer 
{
    public class JoinClause
    {
        private JoinOperator joinOperator;
        private string entity;
        private string primaryProperty;
        private string secondaryProperty;

        public JoinClause()
        {
            joinOperator = JoinOperator.None;
            entity = string.Empty;
            primaryProperty = string.Empty;
            secondaryProperty = string.Empty;
        }

        public JoinOperator JoinOperator
        {
            get { return joinOperator; }
            set { joinOperator = value; }
        }

        public string Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public string PrimaryProperty
        {
            get { return primaryProperty; }
            set { primaryProperty = value;}
        }

        public string SecondaryProperty
        {
            get { return secondaryProperty; }
            set { secondaryProperty = value; }
        }
    }
}
