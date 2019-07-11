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
    public partial class ShowNameTeam : Form
    {
        EFGenericRepository<Team> EFtems = new EFGenericRepository<Team>(new WorkerContext());

        public ShowNameTeam()
        {
            InitializeComponent();
            BindingSource DatedbOne = new BindingSource();
            var DatedbOneK = EFtems.Get();
            var qieryAsList = new BindingList<Team>(DatedbOneK.ToList());
            DatedbOne.DataSource = qieryAsList;
            dataGridViewTeamName.DataSource = DatedbOne;
        }

        private void DeleteTeamName(object sender, EventArgs e)
        {
            Guid id = SearcId();
            if (id == Form1.IdError)
                return;
            Team team = EFtems.FindById(c => c.Id == id);
            BindingSource DatedbOne = new BindingSource();
            var DatedbOneK = EFtems.Get();
               EFtems.Remove(team);
                DatedbOneK = EFtems.Get();
                var qieryAsList = new BindingList<Team>(DatedbOneK.ToList());
                DatedbOne.DataSource = qieryAsList;
            dataGridViewTeamName.DataSource = DatedbOne;
            dataGridViewTeamName.Update();
            dataGridViewTeamName.Refresh();
            
        }

        private void ShowNameTeam_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public Guid SearcId()
        {

            Guid id = Form1.IdError;
            if (dataGridViewTeamName.SelectedRows.Count > 0)
            {
                id = (Guid)dataGridViewTeamName.CurrentRow.Cells[0].Value;
            }
            return id;
        }
    }
}
