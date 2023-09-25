using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;
namespace HRDataAccessLayer 
{
    public static class QueryTranslater
    {
        public static string TranslateQuery(string selectStatement,Query query)
        {
            foreach (JoinClause joinClause in query.JoinClauses)
            {
                selectStatement += TranslateJoinClause(joinClause);
            }
            if (query.Criteria.Count > 0)
            {
                selectStatement += " Where ";
            }
            foreach (Criterion criterion in query.Criteria)
            {
                selectStatement += TranslateCriterion(criterion);
            }
            selectStatement += TranslateOrderClause(query.OrderClause);
            return selectStatement;
        }

        private static string TranslateCriterion(Criterion criterion)
        {

            string result = string.Empty;
            result += criterion.Property +" ";
            switch (criterion.CriterionOperator)
            {
                case CriterionOperator.EqualTo:
                    result += "= ";
                    break;
                case CriterionOperator.NotEqualTo:
                    result += "<> ";
                    break;
                case CriterionOperator.GreaterThan:
                    result += "> ";
                    break;
                case CriterionOperator.GreaterThanOrEqualTo:
                    result += ">= ";
                    break;
                case CriterionOperator.LessThan:
                    result += "< ";
                    break;
                case CriterionOperator.LessThanOrEqualTo:
                    result += "<= ";
                    break;
                case CriterionOperator.Like:
                    result += "Like ";
                    break;
                default:
                    break;
            }
            var hello = criterion.Value;
            result += criterion.Value.GetType() == typeof(int) || criterion.Value.GetType() == typeof(decimal) ? criterion.Value.ToString() : "'" + criterion.Value.ToString() + "'";
            switch (criterion.CriteriaOperator)
            {
                case CriteriaOperator.And:
                    result += " And ";
                    break;
                case CriteriaOperator.Or:
                    result += " Or ";
                    break;
                case CriteriaOperator.None:
                    break;
                default:
                    break;
            }
            return result;
        }

        private static string TranslateOrderClause(OrderClause orderClause)
        {
            string result = string.Empty;
            if (orderClause.Property.Trim() != string.Empty)
            {
                result = " order by " + orderClause.Entity + "." + orderClause.Property + " ";
                switch (orderClause.OrderClauseOperator)
                {
                    case OrderClauseOperator.None:
                        break;
                    case OrderClauseOperator.Asc:
                        result += " ASC";
                        break;
                    case OrderClauseOperator.Desc:
                        result += " DESC";
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        private static string TranslateJoinClause(JoinClause joinClause)
        {
            string result = string.Empty;
            switch (joinClause.JoinOperator)
            {
                case JoinOperator.InnerJoin:
                    result = " Inner Join ";
                    break;
                case JoinOperator.LeftOuterJoin:
                    result = " Left Outer Join ";
                    break;
                default:
                    break;
            }

            result += joinClause.Entity +" on "+ joinClause.PrimaryProperty + " = " + joinClause.SecondaryProperty +" ";
            return result;
        }
    }
}
