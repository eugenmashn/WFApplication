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
    public partial class Add : Form
    {
        EFGenericRepository<Team> EFtems = new EFGenericRepository<Team>(new WorkerContext());
     
        public Add()
        {
            InitializeComponent();
            
        }

        internal void Add_Load(object sender, EventArgs e)
        {
            Person people = new Person();
            List<Team> list_teams = EFtems.Get().ToList();
        
            foreach (Team team in list_teams) {
                comboBox1.Items.Add(team.TeamName);
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

        private void Button1_Click(object sender, EventArgs e)
        {
            Person people = new Person();
            people.Id = Guid.NewGuid();
            people.Name = textBox1.Text;
            people.LastName = textBox2.Text;
            people.Days = (int)numericUpDown1.Value;
            people.Year = (int)numericUpDown2.Value;
            people.TeamId = EFtems.FindById(i => i.TeamName == comboBox1.Text).Id; 
            this.PersonGet = people;
            this.Hide();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
