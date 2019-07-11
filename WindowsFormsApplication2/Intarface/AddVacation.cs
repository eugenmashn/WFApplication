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
    public partial class AddHol : Form
    {
        EFGenericRepository<Person> workers = new EFGenericRepository<Person>(new WorkerContext());
        EFGenericRepository<Vacation> vacations = new EFGenericRepository<Vacation>(new WorkerContext());
        EFGenericRepository<Weekend> holydays = new EFGenericRepository<Weekend>(new WorkerContext());
        EFGenericRepository<Team> EFTeams = new EFGenericRepository<Team>(new WorkerContext());

        int Days;
        Guid Id;
        public AddHol(Guid id)
        {
            Id = id;

           
            Person person = workers.FindById(i => i.Id == id);
            if (person == null)
            {
                return;
            }
             Days = person.Days-1;
            InitializeComponent();
            DateTime CountDate = dateTimePickerFirstDate.Value;
            if (person.Days < 1)
            {
                MessageBox.Show("don`t have weekend!!!");
                return;
            }
            dateTimePickerSecondDate.MaxDate = dateTimePickerFirstDate.Value.AddDays(this.CountDays(dateTimePickerFirstDate.Value, Days));
            dateTimePickerSecondDate.MinDate = dateTimePickerFirstDate.Value;
            dateTimePickerFirstDate.ValueChanged += Limited;
            int Indexday=Days;
            DateTime date = new DateTime(person.Year, 1, 1);
            if (person.Days < 1)
            {
                MessageBox.Show("don`t have weekend!!!");
                return;
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void Limited(object sender,EventArgs e) {
            int IndexDay = Days;
            DateTime CountDate = dateTimePickerFirstDate.Value;
           
            if (dateTimePickerFirstDate.Value > dateTimePickerSecondDate.MaxDate)
            {
                dateTimePickerSecondDate.MaxDate = dateTimePickerFirstDate.Value.AddDays(this.CountDays(dateTimePickerFirstDate.Value, Days));
                dateTimePickerSecondDate.MinDate = dateTimePickerFirstDate.Value;
            }
            else {
                IndexDay = Days;
                dateTimePickerSecondDate.MinDate = dateTimePickerFirstDate.Value;
                dateTimePickerSecondDate.MaxDate = dateTimePickerFirstDate.Value.AddDays(this.CountDays(dateTimePickerFirstDate.Value, Days ));

            }
        }

        private void AddHol_Load(object sender, EventArgs e)
        {

        }
 
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    
        private bool AuditDate(DateTime date) {
            bool TrueorFalse=false;
            List<Weekend> list= holydays.Get().ToList();
            foreach (var i in list) {
                if (((DateTime.Compare(date.Date , i.startDate.Date)>=0) && DateTime.Compare(date.Date ,i.EndDate.Date)<=0) || (date == i.startDate)) {
                    TrueorFalse = true;
                }
            }
            return TrueorFalse;
        }

        private void BtnOk(object sender, EventArgs e)
        {
            workers = new EFGenericRepository<Person>(new WorkerContext());

            Guid id = Id;
            Person person = workers.FindById(i => i.Id == id);
        
            if (person == null)
            {
                return;
            }
            Vacation holydayn = new Vacation();
            holydayn.Peopleid = person.Id;
            DateTime date = new DateTime(person.Year, 1, 1);
            if (person.Days < 1)
            {
                MessageBox.Show("don`t have weekend!!!");
                return;
            }
            Team team  = EFTeams.FindById(i=>i.TeamName==person.TeamName);
            if (team == null)
                return;
            int Daysu = person.Days;
            //DialogResult result = addHolForm.ShowDialog(this);
            holydayn.Id = Guid.NewGuid();
            holydayn.FirstDate =dateTimePickerFirstDate.Value;
            DateTime CountDate = dateTimePickerFirstDate.Value;
            holydayn.IndexDate = false;
            holydayn.SecontDate = dateTimePickerSecondDate.Value;
           
            if ((CountTeam(person.TeamName) - CountWeekend(holydayn.FirstDate, holydayn.SecontDate, person.TeamName) <=team.MinNumberWorkers)&&((int)team.MinNumberWorkers!=0))
            {
                MessageBox.Show("Date busy");
                return;
            }
            int IndexDay = 0;
            for (DateTime i = dateTimePickerFirstDate.Value.Date; i <= dateTimePickerSecondDate.Value.Date;)
            {
                if (i.DayOfWeek != DayOfWeek.Sunday && i.DayOfWeek != DayOfWeek.Saturday && !AuditDate(i))
                {
                    IndexDay++;
                    
                }
                
   
              
                i = i.AddDays(1);
            }
           
            holydayn.TeamName = person.TeamName;
            holydayn.Days = IndexDay;
            Daysu = person.Days-holydayn.Days;
            person.Days = Daysu;
            if (CountTeam(person.TeamName) - CountWeekend(holydayn.FirstDate, holydayn.SecontDate, person.TeamName) <= team.MinNumberWorkers && team.MinNumberWorkers!=0)
            {
                MessageBox.Show("Date busy");
                return;
            }
            this.GetVacation = holydayn;
            this.PersonGet = person;
            workers.Update(person);
        }
        private int CountWeekend(DateTime StartDay, DateTime EndDay, string TeamName)
        {
            int Count = 0;
            List<Vacation> list = vacations.Get(i => (ChackWeekend(StartDay, EndDay, i.FirstDate, i.SecontDate, TeamName,i.TeamName) )).ToList();
            if (list == null)
                return 0;
            Count = list.Count();
            return Count;
        }
        private int CountTeam(string TeamName)
        {
            List<Person> list = workers.Get(i => i.TeamName == TeamName).ToList();
            return list.Count;
        }
        private Vacation getvacation;
        public Vacation GetVacation
        {

            get
            {
                return getvacation;
            }
            set
            {
                getvacation = value;

            }

        }
        private Person GetPerson;
        public Person PersonGet
        {

            get
            {
                return GetPerson;
            }
            set
            {
                GetPerson = value;

            }

        }
        public int CountDays(DateTime CountDate, int Days)
        {

           int  IndexDay = Days;
       
      
            for (int i = 0; i <= IndexDay; i++)
            {
                if (CountDate.DayOfWeek == DayOfWeek.Sunday || CountDate.DayOfWeek == DayOfWeek.Saturday || AuditDate(CountDate))
                {
                    IndexDay++;
                }
                CountDate = CountDate.AddDays(1);
            }
            return IndexDay;
        }
        private bool ChackWeekend(DateTime StartDay, DateTime EndDay, DateTime StartDaySecond, DateTime EndDaySecond,string TeamNameOne,string TeamNameTwo)
        {
            if (TeamNameOne != TeamNameTwo)
                 return false;
            bool check = false;
            for (DateTime indexFirstDate = StartDay; indexFirstDate <= EndDay;)
            {
                for (DateTime indexSecondDate = StartDaySecond; indexSecondDate <= EndDaySecond;) { 
                    if (indexFirstDate.Date == indexSecondDate.Date)
                    {
                        return true;
                     
                    }

                    indexSecondDate= indexSecondDate.AddDays(1);
                }

                indexFirstDate= indexFirstDate.AddDays(1);
            }


            return check;

        }
    }
}
