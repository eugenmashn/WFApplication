using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EFGenericRepository;
using DataAccessLayer.Models;

namespace WFAplicationVacation
{
    public partial class ChangePerson : Form
    {
        EFGenericRepository<Team> EFtems = new EFGenericRepository<Team>(new WorkerContext());
        EFGenericRepository<Person> workers = new EFGenericRepository<Person>(new WorkerContext());
        EFGenericRepository<Vacation> vacations = new EFGenericRepository<Vacation>(new WorkerContext());
        Guid persinId;
        Person person;
        public ChangePerson(Guid Id)
        {
            InitializeComponent();
            persinId = Id;
            person = workers.FindById(persinId);
            textBoxName.Text = person.Name;
            textBoxLastName.Text = person.LastName;
            List<Team> list_teams = EFtems.Get().ToList();

            foreach (Team team in list_teams)
            {
                comboBoxTeamaName.Items.Add(team.TeamName);
            }
            if (person.Team != null)
                comboBoxTeamaName.Text = person.Team.TeamName;
            else
                comboBoxTeamaName.Text = "";
            numericUpDownDays.Value = person.Days;
            numericUpDownYear.Value = person.Year;

        }

        private void ChangePerson_Load(object sender, EventArgs e)
        {
        
        }

        private void btnOk(object sender, EventArgs e)
        {
           
            person.Name = textBoxName.Text;
            person.LastName = textBoxLastName.Text;
            person.Days = (int)numericUpDownDays.Value;
            person.Year = (int)numericUpDownYear.Value;
            person.TeamId = EFtems.FindById(i => i.TeamName == comboBoxTeamaName.Text).Id; ;
           workers.Update(person);
            List<Vacation> PersonVacations = vacations.Get(y => y.Peopleid == person.Id).ToList();
            if (PersonVacations.Count() == 0)
                return;
            for (int i=0; i <PersonVacations.Count(); i++) {
                PersonVacations[i].TeamName = comboBoxTeamaName.Text;
                vacations.Update(PersonVacations[i]);
            }
          
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
