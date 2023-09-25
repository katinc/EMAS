using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRDataAccessLayer 
{
    public class OrderClause
    {
        private OrderClauseOperator orderClauseOperator;
        private string property;
        private string entity;

        public OrderClause()
        {
            orderClauseOperator = OrderClauseOperator.None;
            property = string.Empty;
            entity = string.Empty;
        }

        public OrderClauseOperator OrderClauseOperator
        {
            get { return orderClauseOperator; }
            set { orderClauseOperator = value; }
        }

        public string Property
        {
            get { return property; }
            set { property = value; }
        }

        public string Entity
        {
            get { return entity; }
            set { entity = value; }
        }
    }

    public enum OrderClauseOperator
    {
        None,
        Asc,
        Desc
    }

}
