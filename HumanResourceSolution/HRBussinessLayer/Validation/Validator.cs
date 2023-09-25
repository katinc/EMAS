using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HRBussinessLayer.Validation
{
    public enum StringLengthOperator
    {
        GreaterThan,
        LessThan,
        EqualTo
    }

    public enum DateUnit
    {
        Day,
        Week,
        Month,
        Year
    }

    public enum DateRangeBoundary
    {
        UpperExclusive,
        UpperInclusive,
        LowerExclusive,
        LowerInclusive
    }

    public class Validator
    {
        private static bool result;
        private static Dictionary<string, string> errors = new Dictionary<string,string>();

        public static Dictionary<string, string> Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        public static void ClearErrors()
        {
            errors.Clear();
        }

        #region Enum Validation
        public static bool EnumValidator(object target, Type enumType)
        {
            bool result = false;

            try
            {
                object enumResult = Enum.Parse(enumType, target.ToString(), true);
                result = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                result = false;
            }
            
            return result;
        }
        #endregion

        #region Decimal Validation
        public static bool DecimalValidator(string target)
        {
            result = true;
            try
            {
                decimal.Parse(target);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region Integer Validation
        public static bool IntegerValidator(string target)
        {
            result = true;
            try
            {
                int.Parse(target);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region String Validation
        public static bool NullOrEmptyStringValidator(string target)
        {
            result = true;
            if (target == null || target.Trim() == string.Empty)
            {
                result = false;
            }
            return result;
        }

        public static bool StringLengthValidator(string target,int length,StringLengthOperator oper)
        {
            result = false;
            switch(oper)
            {
                case StringLengthOperator.EqualTo:
                if (target.Trim().Length == length)
                {
                    return true;
                }
                break;
                case StringLengthOperator.GreaterThan:
                if (target.Trim().Length > length)
                {
                    return true;
                }
                break;
                case StringLengthOperator.LessThan:
                if (target.Trim().Length < length)
                {
                    return true;
                }
                break;
                default:
                break;
            }
            return result;
        }
        #endregion

        #region DateRange Validation
        public static bool DateRangeValidator(DateTime target,DateTime currentDate,DateUnit dateUnit, DateRangeBoundary boundryType,int range)
        {
            result = false;
            TimeSpan diff = target.Subtract(currentDate);
            switch (boundryType)
            {
                case DateRangeBoundary.LowerExclusive:
                    if (dateUnit == DateUnit.Day)
                    {
                        
                        if ((-1 * diff.Days) > range)
                        {
                            result = true;
                        }
                    }
                    
                    break;
                case DateRangeBoundary.LowerInclusive:
                    if (dateUnit == DateUnit.Day)
                    {
                        if ((-1 * diff.Days) >= range)
                        {
                            result = true;
                        }
                    }
                    break;
                case DateRangeBoundary.UpperExclusive:
                    if (dateUnit == DateUnit.Day)
                    {
                        if (diff.Days < range)
                        {
                            result = true;
                        }
                    }
                    break;
                case DateRangeBoundary.UpperInclusive:
                    if (dateUnit == DateUnit.Day)
                    {
                        if (diff.Days <= range)
                        {
                            result = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
        #endregion

        #region Email Validation
        public static bool EmailValidator(string email)
        {
            return Regex.IsMatch(email, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
        }
        #endregion
    }
}
