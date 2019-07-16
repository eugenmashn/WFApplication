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
    public partial class AddPerson : Form
    {
        EFGenericRepository<Team> EFTeams = new EFGenericRepository<Team>(new WorkerContext());
     
        public AddPerson()
        {
            InitializeComponent();
            
        }

        internal void Add_Load(object sender, EventArgs e)
        {
            Person person = new Person();
            List<Team> list_teams = EFTeams.Get().ToList();
        
            foreach (Team team in list_teams) {
                comboBoxTeamName.Items.Add(team.TeamName);
            }
    
            
        }
        private Person GetPerson;
        public Person PersonGet {
           
            get {
                return GetPerson;
            }
            set
            {
                GetPerson = value;

            }

        }

        private void btnOk(object sender, EventArgs e)
        {
            Person person = new Person();
            person.Id = Guid.NewGuid();
            person.Name = textBox1.Text;
            person.LastName = textBox2.Text;
            person.Days = (int)numericUpDown1.Value;
            person.Year = DateTime.Now.Year;
            
            //REMOVE THIS CODE
            var team = EFTeams.FindById(i => i.TeamName == comboBoxTeamName.Text);
            if (team != null)
            {
            person.TeamId = EFTeams.FindById(i => i.TeamName == comboBoxTeamName.Text).Id;
            }



            //
            //people.Team = 
            //people.TeamId = EFtems.FindById(i => i.TeamName == comboBox1.Text).Id; 
            this.PersonGet = person;
            this.Hide();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
