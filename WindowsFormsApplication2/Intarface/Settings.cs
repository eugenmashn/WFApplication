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
    public partial class Settings : Form
    {

        EFGenericRepository<GlobalSetting> EFSettings = new EFGenericRepository<GlobalSetting>(new WorkerContext());
        public Settings()
        {
            InitializeComponent();
            List<GlobalSetting> globalSettings = EFSettings.Get().ToList();
            if (globalSettings.Count == 0)
            {
                GlobalSetting settings = new GlobalSetting();
                settings.NameCompany = "Name Company";
                settings.Id = Guid.NewGuid();
                settings.VacationDays = 17;
                EFSettings.Create(settings);
                textBoxName.Text = settings.NameCompany;
                numericUpDownDays.Value = settings.VacationDays;
            }
            else {
                GlobalSetting settings =globalSettings[0];
                textBoxName.Text = settings.NameCompany;
                numericUpDownDays.Value = settings.VacationDays;
            }

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDownDays_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOk(object sender, EventArgs e)
        {
            List<GlobalSetting> globalSettings = EFSettings.GetEntities().ToList();
            GlobalSetting settings = globalSettings[0];
            settings.NameCompany = textBoxName.Text;
            settings.VacationDays = (int)numericUpDownDays.Value;
            EFSettings.Update(settings);

        }
    }
}
