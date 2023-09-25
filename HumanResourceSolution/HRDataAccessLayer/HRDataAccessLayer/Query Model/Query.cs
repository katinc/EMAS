using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRDataAccessLayer
{
    public class Query
    {
        private Criteria criteria;
        private JoinClauses joinClauses;
        private OrderClause orderClause;

        public Query()
        {
            criteria = new Criteria();
            joinClauses = new JoinClauses();
            orderClause = new OrderClause();
        }

        public Criteria Criteria
        {
            get { return criteria; }
            set { criteria = value; }
        }

        public JoinClauses JoinClauses
        {
            get { return joinClauses; }
            set { joinClauses = value; }
        }

        public OrderClause OrderClause
        {
            get { return orderClause; }
            set { orderClause = value; }
        }
    }
}
