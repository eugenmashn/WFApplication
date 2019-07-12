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
using System.Drawing;
namespace WFAplicationVacation
{

    public partial class Form1 : Form
    {
        public static readonly Guid IdError = new Guid("5C60F693-BEF5-E011-A485-80EE7300C695");
       
        EFGenericRepository<Person> workers = new EFGenericRepository<Person>(new WorkerContext());
        EFGenericRepository<Vacation> vacations = new EFGenericRepository<Vacation>(new WorkerContext());
        EFGenericRepository<Weekend> holydays = new EFGenericRepository<Weekend>(new WorkerContext());
        EFGenericRepository<Team> EFtems = new EFGenericRepository<Team>(new WorkerContext());

      
        public Form1()
        {
            InitializeComponent();
            
            PersonGridView.DataSource = workers.GetSort (u => u.TeamId);
          this.PersonGridView.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.PaintRowrsFormOne);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
           
        private void btnAddnewPerson(object sender, EventArgs e)
        {
            Add addForm = new Add();

            DialogResult result = addForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
            Person person = addForm.PersonGet;
            workers.Create(addForm.PersonGet);
       
            evenstb();
            addForm.Close();
        }

        public void btnAddVacation(object sender, EventArgs e)
        {
             /*workers = new EFGenericRepository<Person>(new WorkerContext());
            vacations = new EFGenericRepository<Vacation>(new WorkerContext());*/
            Vacation holydayn = new Vacation();
            Guid id = SearcId();
            if (id == IdError)
                return;
            AddHol addHolForm = new AddHol(id);

            DialogResult result = addHolForm.ShowDialog(this);
          
            if (addHolForm.GetVacation == null)
                return;
            vacations.Create(addHolForm.GetVacation);
            addHolForm.Close();
            evenstb();
        }

        private void btnDeletePerson(object sender, EventArgs e)
        {
            Guid id = SearcId();
            if (id == IdError)
                return;
            Person peopl = workers.FindById(id);
            if (peopl == null)
            {
                return;
            }
            workers.Remove(peopl);
            evenstb();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnShowDate(object sender, EventArgs e)
        {
            Guid id = SearcId();
            if (id == IdError)
                return;
            date addHolForm = new date(id);
            addHolForm.onupdate += new ONupdate(evenstb);
            DialogResult result = addHolForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                addHolForm.onupdate -= evenstb;
                addHolForm.Close();
                return;
            }

        }

        private void btnNextYear(object sender, EventArgs e)
        {
            Guid id = new Guid();
            Add addForm = new Add();
            int index = 0;
            if (PersonGridView.RowCount > workers.Count())
            {
                index = PersonGridView.RowCount - 1;
            }
            else
            {
                index = PersonGridView.RowCount;
            }
            for (int i = 0; i < index; i++)
            {
                id = (Guid)PersonGridView[0, i].Value;
                Person people = new Person();
                Person peopleOne = new Person();
                peopleOne = workers.FindById(id);
                peopleOne.Days = (int)peopleOne.Days + 18;
                peopleOne.Year = (int)peopleOne.Year + 1;
                workers.Update(peopleOne);
            }
            evenstb();
        }

        private void btnSortDate(object sender, EventArgs e)
        {
            Guid id = SearcId();
            if (id == IdError)
                return;
            Person person = workers.FindById(i => i.Id == id);
            if (person == null)
                return;
            Sort sort = new Sort(id, person.Name, person.LastName);
            DialogResult result = sort.ShowDialog(this);
            sort.Close();
        }
      
        void evenstb()
        {
            /* workers = new EFGenericRepository<Person>(new WorkerContext());
             vacations = new EFGenericRepository<Vacation>(new WorkerContext());*/
            Guid Id = SearcId();
            PersonGridView.MultiSelect = true;
            PersonGridView.DataSource = null;
            PersonGridView.DataSource = workers.GetSort(u => u.Team.Id);
            foreach (DataGridViewRow rows in PersonGridView.Rows) {
                if ((Guid)rows.Cells[0].Value == Id) {
                    rows.Selected = true;
               //     PersonGridView.CurrentCell =rows.Cells[0];

                }
            }
          
        }
        public Guid SearcId()
        {
            if (PersonGridView.SelectedRows.Count > 0)
            {  
                Guid id = (Guid)PersonGridView.CurrentRow.Cells[0].Value;
                return id;
            }
            else
            {
                return IdError;
            }

        }

        private void AddnewWeekend(object sender, EventArgs e)
        {
            Weekend newWeekend = new Weekend();
            AddnewWeekend newDateWeekend = new AddnewWeekend();
            newDateWeekend.dateTimePicker1.Value = DateTime.Now;
            newDateWeekend.dateTimePicker2.MaxDate = newDateWeekend.dateTimePicker1.Value.AddDays(5);
            newDateWeekend.dateTimePicker2.MinDate = newDateWeekend.dateTimePicker1.Value;
            DialogResult result = newDateWeekend.ShowDialog(this);
            newWeekend.Id = Guid.NewGuid();
            newWeekend.startDate = newDateWeekend.dateTimePicker1.Value;
            newWeekend.EndDate = newDateWeekend.dateTimePicker2.Value;
            holydays.Create(newWeekend);
            newDateWeekend.Close();
        }

        private void ShowDateWeekend(object sender, EventArgs e)
        {
            newWeekendDatagridview newWeekend = new newWeekendDatagridview();
            DialogResult result = newWeekend.ShowDialog(this);
            newWeekend.Close();
        }
        private bool AuditDate(DateTime date)
        {
            bool TrueorFalse = false;
            List<Weekend> list = holydays.Get().ToList();
            foreach (var i in list)
            {
                if (((date.Date >= i.startDate.Date) && (date.Date <= i.EndDate.Date)) || (date.Date == i.startDate.Date))
                {
                    TrueorFalse = true;
                }
            }
            return TrueorFalse;
        }

        private void Addday(object sender, EventArgs e)
        {
            Guid id = SearcId();
            Person person = workers.FindById(id);
            if (person == null)
                return;
            person.Days++;
            workers.Update(person);
            evenstb();
        }
        private int CountWeekend(DateTime StartDay, DateTime EndDay,string TeamName) {
            int Count = 0;
            List<Vacation> list = vacations.Get(i=>(ChackWeekend(StartDay,EndDay,i.FirstDate,i.SecontDate)&&i.TeamName==TeamName)).ToList();
           

            if (list == null)
                return 0;
            Count = list.Count();
            return Count;
        }
        private int CountTeam(string TeamName) {
            List<Person> list = workers.Get(i => i.Team.TeamName == TeamName).ToList();
            return list.Count;
        }

        private void PersonGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool ChackWeekend(DateTime StartDay, DateTime EndDay, DateTime StartDaySecond, DateTime EndDaySecond) {
            bool check = true;
            for (DateTime indexFirstDate = StartDay.Date; indexFirstDate <= EndDay.Date;)
            {
                for(DateTime indexSecondDate = StartDaySecond.Date; indexSecondDate <= EndDaySecond.Date;)
                if (indexFirstDate== indexSecondDate)
                {
                        check = false;
                        break;
                }
            }
            return check;
        }
        private void SubtractDay(object sender, EventArgs e)
        {
            Guid id = SearcId();
            Person person = workers.FindById(id);
            if (person == null)
                return;
            person.Days--;
            workers.Update(person);
            evenstb();

        }
        public void PaintRowrsFormOne(object sender, EventArgs e)
        {
            List<Person> persons = workers.Get().ToList();
           List<Team> teams=EFtems.GetSort(i=>i.Id).ToList();
           
          
            Color[] colors = new Color[5];
            colors[0] = ColorTranslator.FromHtml("#87CEEB");
            colors[1] = ColorTranslator.FromHtml("#7B68EE");
            colors[2] = ColorTranslator.FromHtml("#4169E1");
            colors[3] = ColorTranslator.FromHtml("#9ACD32");
            colors[4] = ColorTranslator.FromHtml("#008080");

            string TeamNameTwo = PersonGridView.Rows[0].Cells[1].Value.ToString();
            int indexColor = 0;
            foreach (DataGridViewRow row in PersonGridView.Rows)
            {
                


                if ((Guid)row.Cells[6].Value == teams[indexColor].Id)
                {
                    row.DefaultCellStyle.BackColor = colors[indexColor];
                 
                }
                else {

                    indexColor++;
                    row.DefaultCellStyle.BackColor = colors[indexColor];
                }
                if (indexColor >= 4)
                    indexColor = 0;
            }
        }

        private void BtnAddTeam(object sender, EventArgs e)
        {
 
            AddTeam addTeam = new AddTeam();
            DialogResult result = addTeam.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
        }

        private void ShowNameTeam(object sender, EventArgs e)
        {
            ShowNameTeam Showteam = new ShowNameTeam();

            DialogResult result = Showteam.ShowDialog(this);
            if (result == DialogResult.OK)
            {

                Showteam.Close();
                return;
            }

        }

        private void btnChangePerson(object sender, EventArgs e)
        {
            Guid id = SearcId();
            ChangePerson changePerson = new ChangePerson(id);
            DialogResult result = changePerson.ShowDialog(this);
            if (result == DialogResult.OK) {
                evenstb();
                changePerson.Close();
                return;
            }

           
        }
    }
   

}
