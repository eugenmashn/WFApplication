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
namespace WFAplicationVacation
{

    public delegate void ONupdate();
 
    public partial class date : Form
    {
        EFGenericRepository<Person> workers = new EFGenericRepository<Person>(new WorkerContext());
        EFGenericRepository<Vacation> vacations = new EFGenericRepository<Vacation>(new WorkerContext());

        public event ONupdate onupdate;
        Guid _Id;
        Vacation personOfweekend;
      
        public class HollydayTwo {
            public Guid Id;
            public DateTime FirstDate;
            public DateTime SecondDate;
        }
        protected virtual void Onstartevent() {
            if (onupdate != null) {
                onupdate();
            }
        }

        public date(Guid Id)
        {
            InitializeComponent();
            _Id = Id;
            if (vacations.Count(i=>i.Peopleid==_Id)<1)
            {
               MessageBox.Show("Don`t have weekend");
            }
            else {
               
            BindingSource DatedbOne = new BindingSource();
            var DatedbOneK = vacations.Get(i => i.Peopleid == _Id);
            personOfweekend = vacations.FindById(i => i.Peopleid == _Id);
            if (personOfweekend == null)
                  return;
            checkBox1.Checked = personOfweekend.IndexDate;
            var qieryAsList = new BindingList<Vacation>(DatedbOneK.ToList());
            DatedbOne.DataSource = qieryAsList;
            dataGridViewVacations.DataSource = DatedbOne;

            }
            this.dataGridViewVacations.RowPrePaint +=new DataGridViewRowPrePaintEventHandler(this.PaintRows);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void date_Load(object sender, EventArgs e)
        {

        }
   

        private void btnDeleteDate(object sender, EventArgs e)
        {
          
             

               Guid id =SearcId();
               if (id == Form1.IdError)
                    return;
            Vacation peoplday = vacations.FindById(c => c.Id == id);
                Person people = workers.FindById( c => c.Id == peoplday.Peopleid);
                BindingSource DatedbOne = new BindingSource();
            var DatedbOneK = vacations.Get(i => i.Peopleid == _Id);

            if (peoplday.IndexDate == true)
                {
                    MessageBox.Show("it is used");
                }
                else
                {
                   int DaysRegain = peoplday.Days;
                    people.Days += DaysRegain;
                    workers.Update(people);
                    vacations.Remove(peoplday);
                    DatedbOneK = vacations.Get(i => i.Peopleid == _Id);
                    var qieryAsList = new BindingList<Vacation>(DatedbOneK.ToList());
                    DatedbOne.DataSource = qieryAsList;
                    dataGridViewVacations.DataSource = DatedbOne;
                    dataGridViewVacations.Update();
                    dataGridViewVacations.Refresh();
                }
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Guid id = SearcId();
            if (id == Form1.IdError)
                return;
            Vacation peoplday = vacations.FindById(c => c.Id == id);
            if (peoplday == null)
                return;
                peoplday.IndexDate = true;
            vacations.Update(peoplday);
         


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Onstartevent();
        }
         public Guid SearcId() {

            Guid id = Form1.IdError;
            if (dataGridViewVacations.SelectedRows.Count > 0)
            {
               id = (Guid)dataGridViewVacations.CurrentRow.Cells[0].Value;     
            }
          return id;
         }
        private void PaintRows(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dataGridViewVacations.Rows) {

                if ((bool)row.Cells[1].Value)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
    }
}
