using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
namespace eMAS.Forms.SystemSetup
{
    public partial class HolidayEdit : Form
    {
        IDAL dal;
        Holiday holiday;
        HolidayView holidayView;

        public HolidayEdit(IDAL dal,Holiday holiday,HolidayView holidayView)
        {
            InitializeComponent();
            this.dal = dal;
            this.holiday = holiday;
            this.holidayView = holidayView;
            dateTimePicker1.Text = holiday.Date.ToString();
            textBox1.Text = holiday.Description;
        }

        public HolidayEdit()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.holiday = new Holiday();
            this.holidayView = new HolidayView();
            dateTimePicker1.Text = holiday.Date.ToString();
            textBox1.Text = holiday.Description;
        }

        private void HolidayEdit_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void Clear()
        {
            holiday.ID = 0;
            dateTimePicker1.ResetText();
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateHolidayEntity();
            try
            {
                if (ValidateFields())
                {
                    dal.Update(holiday);
                    Clear();
                    holidayView.GetHolidays();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void UpdateHolidayEntity()
        {
            holiday.Date = DateTime.Parse(dateTimePicker1.Text);
            holiday.Description = textBox1.Text;
        }
        private bool ValidateFields()
        {
            bool result = true;
            return result;
        }
    }
}
