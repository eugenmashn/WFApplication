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

    public partial class MainForm : Form
    {
        public static readonly Guid IdError = new Guid("5C60F693-BEF5-E011-A485-80EE7300C695");
       
        EFGenericRepository<Person> workers = new EFGenericRepository<Person>(new WorkerContext());
        EFGenericRepository<Vacation> EFvacations = new EFGenericRepository<Vacation>(new WorkerContext());
        EFGenericRepository<Weekend> EFweekends = new EFGenericRepository<Weekend>(new WorkerContext());
        EFGenericRepository<Team> EFtems = new EFGenericRepository<Team>(new WorkerContext());
        EFGenericRepository<GlobalSetting> EFSettings = new EFGenericRepository<GlobalSetting>(new WorkerContext());

        List<Person> persons;
        List<Team> teams;
        List<string> teamsTwo;
        public MainForm()
        {
            InitializeComponent();
            teamsTwo = new List<string>();
             persons = workers.Get().ToList();
             teams = EFtems.GetSort(i => i.TeamName).ToList();
            foreach (Person person in persons)
            {

                teamsTwo.Add((person.Team.TeamName).ToString());
            }
            teams = EFtems.Get(i => teamsTwo.Contains(i.TeamName)).OrderBy(i=>i.TeamName).ToList();

            PersonGridView.DataSource = workers.GetSort(u => u.Team.TeamName);
          this.PersonGridView.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.PaintRowrsFormOne);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
           
        private void btnAddnewPerson(object sender, EventArgs e)
        {
            AddPerson addPerson = new AddPerson();

            DialogResult result = addPerson.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
            Person person = addPerson.PersonGet;
            workers.Create(addPerson.PersonGet);
       
            UpdateDataGridView();
            addPerson.Close();
        }

        public void btnAddVacation(object sender, EventArgs e)
        {
          
            Guid id = SearcId();
            if (id == IdError)
                return;
            AddVacation addVacation = new AddVacation(id);

            DialogResult result = addVacation.ShowDialog(this);
          
            if (addVacation.GetVacation == null)
                return;
            EFvacations.Create(addVacation.GetVacation);
            addVacation.Close();
            UpdateDataGridView();
        }

        private void btnDeletePerson(object sender, EventArgs e)
        {
            Guid id = SearcId();
            if (id == IdError)
                return;
            Person person = workers.FindById(id);
            if (person == null)
            {
                return;
            }
            workers.Remove(person);
            UpdateDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnShowVacation(object sender, EventArgs e)
        {
            Guid id = SearcId();
            if (id == IdError)
                return;
            ShowVacation ShowaddVacation = new ShowVacation(id);
            ShowaddVacation.onupdate += new ONupdate(UpdateDataGridView);
            DialogResult result = ShowaddVacation.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                ShowaddVacation.onupdate -= UpdateDataGridView;
                ShowaddVacation.Close();
                return;
            }
        }

        private void btnNextYear(object sender, EventArgs e)
        {
            int Days = EFSettings.Get().ToList()[0].VacationDays;
            Guid id = new Guid();
            AddPerson Changeperson = new AddPerson();
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
                Person person = new Person();
                Person persenOne = new Person();
                persenOne = workers.FindById(id);
                persenOne.Days = (int)persenOne.Days + Days;
                persenOne.Year = (int)persenOne.Year + 1;
                workers.Update(persenOne);
            }
            UpdateDataGridView();
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
        void UpdateDataGridView()
        {
         
            Guid Id = SearcId();
            List<Person> persons = workers.Get().ToList();
            teams = EFtems.GetSort(i => i.TeamName).ToList();
            PersonGridView.MultiSelect = true;
            PersonGridView.DataSource = null;
           

            foreach (Person person in persons)
            {

                teamsTwo.Add(person.Team.TeamName);
            }
         
            teams = EFtems.Get(i => teamsTwo.Contains(i.TeamName)).OrderBy(i => i.TeamName).ToList();
            PersonGridView.DataSource = workers.GetSort(u => u.Team.TeamName);
            PersonGridView.CurrentRow.Selected = false;
            PersonGridView.ClearSelection();
            int IndexRow = 0;
        
            foreach (DataGridViewRow rows in PersonGridView.Rows) {
                IndexRow++;
                if ((Guid)rows.Cells[0].Value == Id) {
                    PersonGridView.CurrentRow.Selected = false;
                      
                    rows.Selected = true;
                    break;
                    //     PersonGridView.CurrentCell =rows.Cells[0];

                   
                }
            }
            PersonGridView.CurrentCell = PersonGridView.Rows[IndexRow-1].Cells[4];
        /*  PersonGridView.FirstDisplayedScrollingRowIndex = Index;
          PersonGridView.CurrentCell = PersonGridView.Rows[Index].Cells[3];*/

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
            newDateWeekend.dateTimePickerStartDate.Value = DateTime.Now;
            newDateWeekend.dateTimePickerEndDate.MaxDate = newDateWeekend.dateTimePickerStartDate.Value.AddDays(5);
            newDateWeekend.dateTimePickerEndDate.MinDate = newDateWeekend.dateTimePickerStartDate.Value;
            DialogResult result = newDateWeekend.ShowDialog(this);
            newWeekend.Id = Guid.NewGuid();
            newWeekend.startDate = newDateWeekend.dateTimePickerStartDate.Value;
            newWeekend.EndDate = newDateWeekend.dateTimePickerEndDate.Value;
            EFweekends.Create(newWeekend);
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
            List<Weekend> list = EFweekends.Get().ToList();
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
            UpdateDataGridView();
        }
        private int CountWeekend(DateTime StartDay, DateTime EndDay,string TeamName) {
            int Count = 0;
            List<Vacation> list = EFvacations.Get(i=>(ChackWeekend(StartDay,EndDay,i.FirstDate,i.SecontDate)&&i.TeamName==TeamName)).ToList();
           

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
            UpdateDataGridView();

        }
        public void PaintRowrsFormOne(object sender, EventArgs e)
        {
          /*  List<Person> persons = workers.Get().ToList();
           List<Team> teams=EFtems.GetSort(i=>i.TeamName).ToList();
           */
          
            Color[] colors = new Color[5];
            colors[0] = ColorTranslator.FromHtml("#87CEEB");
            colors[1] = ColorTranslator.FromHtml("#7B68EE");
            colors[2] = ColorTranslator.FromHtml("#4169E1");
            colors[3] = ColorTranslator.FromHtml("#9ACD32");
            colors[4] = ColorTranslator.FromHtml("#008080");

            string TeamNameTwo = PersonGridView.Rows[0].Cells[1].Value.ToString();
            int indexColor = 0;
            int indexTeam = 0;
            foreach (DataGridViewRow row in PersonGridView.Rows)
            {

                if (indexColor > 4)
                    indexColor = 0;

                if ((Guid)row.Cells["TeamId"].Value == teams[indexTeam].Id)
                {
                    row.DefaultCellStyle.BackColor = colors[indexColor];
                 
                }
                else {
                    indexTeam++;
                    indexColor++;
                    if (indexColor > 4)
                        indexColor = 0;
                    row.DefaultCellStyle.BackColor = colors[indexColor];
                   
                }
                
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
                UpdateDataGridView();
                changePerson.Close();
                return;
            }

           
        }

        private void Settings(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            DialogResult result = settings.ShowDialog(this);
            if (result == DialogResult.OK) {
                settings.Close();
                return;
            }
        }
    }
   

}
