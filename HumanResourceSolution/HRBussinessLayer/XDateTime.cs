using System;
using System.Collections;
using System.Configuration;

namespace HRBussinessLayer
{
	/// <summary>
	/// Specifies the type of the XDateTime class.
	/// </summary>
	/// <remarks>
	/// The XDateTimeType enumeration represents the type of the XDateTime object.
	/// This enumeration ranges from zero, indicating Calendar, to one, indicating Business.
	/// This enumeration is useful when it is desirable to have a strongly typed specification 
	/// of the type of the XDateTime object. For example, this enumeration is the type of the 
	/// property value for the DateType property of the XDateTime class.
	/// </remarks>
	public enum XDateTimeType { Calendar=0, Business=1 };

	/// <summary>
	/// A XDateTime class represents an instant in time, typically expressed as a date and time of day.
	/// It consists an instance of System.DateTime structure inside and provides some specific functionality
	/// for working with business dates. This class is useful if you have to deal with such terms as
	/// next business day, previous business day and so on. If you dont't need to manipulate with business dates
	/// use, please, the standard System.DateTime.
	/// </summary>
	public class XDateTime
	{
		#region Private Class Member Variable

		private string _format = "MM/dd/yyyy";
		private DateTime _date;
		private XDateTimeType _type;
		private Hashtable _holidays;

		#endregion

		#region Constructor
		
		public XDateTime()
		{
			init(DateTime.Now, XDateTimeType.Calendar);

		}

		public XDateTime(string dateTime)
		{
			init(Convert.ToDateTime(dateTime), XDateTimeType.Calendar);
		}

		public XDateTime(string dateTime, XDateTimeType dateType)
		{
			init(Convert.ToDateTime(dateTime), dateType);
			check();
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Gets or sets the type of the Smart Date which is a value of XDateTimeType enumeration
		/// and could be Calendar or Business type. 
		/// </summary>
		/// <remarks>
		/// If you set the DateType to Business type the value of the inner DateTime variable might be
		/// changed to the value of the closest next business date.
		/// </remarks>
		public XDateTimeType DateType
		{
			get { return _type; }
			set 
			{ 
				_type = value;
				check();
			}
		}

		/// <summary>
		/// Gets or sets a value of the inner System.DateTime variable of the Smart Date.
		/// </summary>
		/// <remarks>
		/// If you set the Date and the DateType is a Business type the value of the inner DateTime variable
		/// might be changed to the value of the closest next business date.
		/// </remarks>
		public DateTime Date
		{
			get { return _date; }
			set 
			{
				_date = value;
				check();
			}
		}
		
		/// <summary>
		/// Returns true if the value of the inner DateTime variable is a public Holiday, otherwise false.
		/// </summary>
		public bool IsHoliday
		{
			get
			{
				return _holidays.ContainsValue(_date.ToString(_format));
			}
		}

		/// <summary>
		/// Returns true if the value of the inner DateTime variable is a work day, otherwise false.
		/// </summary>
		public bool IsWorkDay
		{
			get
			{
				return !(_date.DayOfWeek == DayOfWeek.Saturday || _date.DayOfWeek == DayOfWeek.Sunday || this.IsHoliday);
			}
		}

		/// <summary>
		/// Adds given hours to the value of the inner DateTime variable considering the DateType value.
		/// </summary>
		/// <param name="hours">Hours to add.</param>
		public void AddHours(short hours)
		{
			_date = _date.AddHours(Convert.ToDouble(hours));
			check();
		}

		/// <summary>
		/// Adds one business or calendar day depending on the DateType value to the value of the inner DateTime variable.
		/// </summary>
		public void AddDay()
		{
			_date = _date.AddDays(1.0);
			check();
		}

		/// <summary>
		/// Adds given CALENDAR amount of days to the value of the inner DateTime variable. Always considers
		/// a value of DateType property and change the inner date according to this value.
		/// </summary>
		/// <param name="days">Calendar days to add.</param>
		public void AddDays(short days)
		{
			_date = _date.AddDays(Convert.ToDouble(days));
			check();
		}

		/// <summary>
		/// Adds given BUSINESS amount of days to the value of the inner DateTime variable. Always considers
		/// a value of DateType property and change the inner date according to this value.
		/// </summary>
		/// <param name="days">Business days to add.</param>
		public void AddBusinessDays(short days)
		{
			double sign = Convert.ToDouble(Math.Sign(days));
			int unsignedDays = Math.Sign(days)*days;
			for (int i=0; i<unsignedDays; i++)
			{
				do
				{
					_date = _date.AddDays(sign);
				}
				while (!this.IsWorkDay);
			}
		}

		/// <summary>
		/// Returns a new instance of the System.DateTime object with the value of Next Business Day counting from
		/// the value of the XDateTime object.
		/// </summary>
		public DateTime NextBusinessDay()
		{
			DateTime date = _date;
			do 
			{
				date = date.AddDays(1.0);
			}
			while (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || 
				_holidays.ContainsValue(date.ToString(_format)));
			return date;
		}

		/// <summary>
		/// Returns a new instance of the System.DateTime object with the value of Previous Business Day counting from
		/// the value of the XDateTime object.
		/// </summary>
		public DateTime PreviousBusinessDay()
		{
			DateTime date = _date;
			do 
			{
				date = date.AddDays(-1.0);
			}
			while (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || 
				_holidays.ContainsValue(date.ToString(_format)));
			return date;
		}

		public int NumberOfBusinessDaysFrom(DateTime date)
		{
			double dayToAdd = -1;
			int numberOfBusinessDays = 0;

			if (date < _date)
			{
				dayToAdd = 1;
			}
			while ( _date != date )
			{
				date = date.AddDays(dayToAdd);
				if (!(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || _holidays.ContainsValue(date.ToString(_format))))
				{
					// if date is a working (business) day - increase a counter
					numberOfBusinessDays++;
				}
			}
			return numberOfBusinessDays;
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Initializes private members of the XDateTime object. For using in the class constructors only.
		/// </summary>
		/// <param name="dateTime">Initial date.</param>
		/// <param name="dateType">Date type.</param>
		private void init(DateTime dateTime, XDateTimeType dateType)
		{
			_date = dateTime;
			_type = dateType;
			initHolidays();
		}


		/// <summary>
		/// Loads a list of public holidays from .config file.
		/// </summary>
		private void initHolidays()
		{
			//Read holidays from .config file
			_holidays = (Hashtable)ConfigurationSettings.GetConfig("Holidays");
		}

		/// <summary>
		/// Tests a value of the inner DateTime variable and changes it if needed.
		/// </summary>
		private void check()
		{
			if (_type == XDateTimeType.Business && !this.IsWorkDay)
			{
				_date = this.NextBusinessDay();
			}
		}

		#endregion
	}
}
