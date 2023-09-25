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
using eMAS.Forms.SystemSetup;

namespace eMAS.Forms.System_SetupFORMS
{
    public partial class HolidaysForm : Form
    {
        private IDAL dal;

        public HolidaysForm()
        {
            InitializeComponent();
            dal = new DAL();
            dal.OpenConnection();
        }

        private void Holidays_Load(object sender, EventArgs e)
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
            textBox1.Clear();
            dateTimePicker1.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Holiday holiday = new Holiday();
            UpdateHolidayEntity(holiday);
            try
            {
                if (ValidateFields())
                {
                    dal.Save(holiday);
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

        private void UpdateHolidayEntity(Holiday holiday)
        {
            holiday.Date = DateTime.Parse(dateTimePicker1.Text);
            holiday.Description = textBox1.Text;
        }

        private bool ValidateFields()
        {
            bool result = true;
            errorProvider1.Clear();
            if (textBox1.Text.Trim() == string.Empty)
            {
                result = false;
                errorProvider1.SetError(textBox1, "Please enter a description for the holiday");
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HolidayView holidayView = new HolidayView(dal);
            holidayView.ShowDialog();
        }
    }
}
