using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.EFGenericRepository;

namespace WFAplicationVacation
{
    public partial class Sort : Form
    {
        Guid _Id;
        int YearIndex;
        EFGenericRepository<Person> workers = new EFGenericRepository<Person>(new WorkerContext());
        EFGenericRepository<Vacation> vacations = new EFGenericRepository<Vacation>(new WorkerContext());
        public Sort(Guid Id, string name,string lastName)
        {
            _Id = Id;
            InitializeComponent();
            linkLabel2.Text = name;
            linkLabel3.Text = lastName;
            Person peopl =workers.FindById(_Id);
            YearIndex =peopl.Year;
            numericUpDown1.Value = YearIndex;
            if (vacations.Count(i => i.FirstDate.Year == YearIndex)<1) {
                    MessageBox.Show("not booked");
               
            }
            else {

                BindingSource DatedbOne = new BindingSource();
                var DatedbOnek = from w in vacations.Get().ToList()
                                where w.FirstDate.Year == YearIndex
                                where w.Peopleid==_Id
                                select w;
                var qieryAsList = new BindingList<Vacation>(DatedbOnek.ToList());
                DatedbOne.DataSource = qieryAsList;
                dataGridViewPersonsVacationSort.DataSource = DatedbOne;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            YearIndex = (int)numericUpDown1.Value;
            if (vacations.Count(i => i.FirstDate.Year == YearIndex) < 1)
            {
                MessageBox.Show("not booked");

            }
            else
            {
                BindingSource DatedbOne = new BindingSource();
                var DatedbOnek = from w in vacations.Get()
                                 where w.FirstDate.Year == YearIndex
                                 where w.Peopleid==_Id
                                 select w;
                var qieryAsList = new BindingList<Vacation>(DatedbOnek.ToList());
                DatedbOne.DataSource = qieryAsList;
                dataGridViewPersonsVacationSort.DataSource = DatedbOne;

            }
        }


       

        private void Sort_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
