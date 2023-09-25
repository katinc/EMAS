using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.TimeAndAttendance;
using HRDataAccessLayerBase;
using HRDataAccessLayer.TimeAndAttendance;
using System.Data;

namespace HRDataAccessLayer.TimeAndAttendance
{
    public class TimeCardDataMapper
    {
        DALHelper dal;

        public TimeCardDataMapper()
        {
            dal = new DALHelper();
        }


        public IList<TimeCard> GetAll()
        {
            IList<TimeCard> timeCards = new List<TimeCard>();
            return timeCards;
        }

        public IList<TimeCard> GetByCriteria(Query query)
        {
            DataTable table = new DataTable();
            IList<TimeCard> timeCards = new List<TimeCard>();
            string selectStatement = QueryTranslater.TranslateQuery("Select ID,CheckType,CheckTime from CheckInOut", query);

            table = dal.ExecuteReader(selectStatement);
            foreach (DataRow row in table.Rows)
            {
                
            }
            return timeCards;
        }
    }
}
