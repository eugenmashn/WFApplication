using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAplicationVacation
{
    public partial class AddnewWeekend : Form
    {
        public AddnewWeekend()
        {
            InitializeComponent();
            dateTimePickerStartDate.Value = DateTime.Now;
            dateTimePickerStartDate.ValueChanged += Limited;
            dateTimePickerEndDate.MaxDate = dateTimePickerStartDate.Value.AddDays(15);
            dateTimePickerEndDate.MinDate = dateTimePickerStartDate.Value;
        }
        private void Limited(object sender, EventArgs e)
        {
            DateTime CountDate = dateTimePickerStartDate.Value;
            if (dateTimePickerStartDate.Value > dateTimePickerEndDate.MaxDate)
            {
                dateTimePickerEndDate.MaxDate = dateTimePickerStartDate.Value.AddDays(15);
            }
            else
            {
                dateTimePickerEndDate.MinDate = dateTimePickerStartDate.Value;
            }
            dateTimePickerEndDate.MinDate = dateTimePickerStartDate.Value;
            dateTimePickerEndDate.MaxDate = dateTimePickerStartDate.Value.AddDays(15);
        }
        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void AddnewWeekend_Load(object sender, EventArgs e)
        {
     
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
