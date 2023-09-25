using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRDataAccessLayer
{
    public class Criterion
    {
        private string property;
        private CriterionOperator criterionOperator;
        private object value;
        private CriteriaOperator criteriaOperator;

        public Criterion()
        {
            property = string.Empty;
            criterionOperator = CriterionOperator.None;
            value = null;
            criteriaOperator = CriteriaOperator.None;
        }

        public string Property
        {
            get { return property; }
            set { property = value; }
        }

        public CriterionOperator CriterionOperator
        {
            get { return criterionOperator; }
            set { criterionOperator = value; }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return criteriaOperator; }
            set { criteriaOperator = value; }
        }
    }
}
