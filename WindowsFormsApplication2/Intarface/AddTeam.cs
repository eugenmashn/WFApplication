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
    public partial class AddTeam : Form
    {
        EFGenericRepository<Team> EFTeam = new EFGenericRepository<Team>(new WorkerContext());

        public AddTeam()
        {
            InitializeComponent();

        }

        private void AddTeam_Load(object sender, EventArgs e)
        {

            
        }

        private void TextBoxTeamName(object sender, EventArgs e)
        {

        }

        private void btnOK(object sender, EventArgs e)
        {
            Team team = new Team();
            team.TeamName = TextBoxTeamNameText.Text;
            team.Id = Guid.NewGuid();
            //team.Year = (int)numericUpDownYear.Value;
            team.MinNumberWorkers =(int)numericUpDownNumberWorks.Value;
            EFTeam.Create(team);
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
