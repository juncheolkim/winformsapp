using WinFormsAppMaster.Interfaces;
using WinFormsAppMaster.Models;

namespace WinFormsAppMaster
{
    public partial class frmMain : Form
    {
        private readonly IDatabase<GangnamguPopulation> _iDatabase;
        public frmMain(IDatabase<GangnamguPopulation> idatabase)
        {
            InitializeComponent();

            _iDatabase = idatabase;
        }

        private void btnReadAll_Click(object sender, EventArgs e)
        {
            var datas = _iDatabase.Get();
            dgvDataTable.DataSource = datas;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var targetId = this.nbxId.Value;
            var data = this._iDatabase.GetDetail(Convert.ToInt16(targetId));

            this.tbxAdministrativeAgency.Text = data.AdministrativeAgency;
            this.nbxFemalePopulation.Value = (decimal)data.FemalePopulation;
            this.nbxId.Value = (decimal)data.Id;
            this.nbxMalePopulation.Value = (decimal)data.MalePopulation;
            this.nbxNumberOfHousehold.Value = (decimal)data.NumberOfHouseholds;
            this.nbxPeoplePerHousehold.Value = (decimal)data.NumberOfPeoplePerHousehold;
            this.nbxSexRatio.Value = (decimal)data.SexRatio;
            this.nbxTotalPopulation.Value = (decimal)data.TotalPopulation;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            GangnamguPopulation gangnamguPopulation = new GangnamguPopulation()
            {
                AdministrativeAgency = this.tbxAdministrativeAgency.Text,
                FemalePopulation = (int)this.nbxFemalePopulation.Value,
                MalePopulation = (int)this.nbxMalePopulation.Value,
                NumberOfHouseholds = (int)this.nbxNumberOfHousehold.Value,
                NumberOfPeoplePerHousehold = (double)this.nbxPeoplePerHousehold.Value,
                SexRatio = (int)this.nbxSexRatio.Value,
                TotalPopulation = (int)this.nbxTotalPopulation.Value
            };

            this._iDatabase.Create(gangnamguPopulation);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var targetId = this.nbxId.Value;
            var data = this._iDatabase.GetDetail(Convert.ToInt16(targetId));
            data.AdministrativeAgency = this.tbxAdministrativeAgency.Text;
            data.FemalePopulation = (int)this.nbxFemalePopulation.Value;
            data.MalePopulation = (int)this.nbxMalePopulation.Value;
            data.NumberOfHouseholds = (int)this.nbxNumberOfHousehold.Value;
            data.NumberOfPeoplePerHousehold = (double)this.nbxPeoplePerHousehold.Value;
            data.SexRatio = (int)this.nbxSexRatio.Value;
            data.TotalPopulation = (int)this.nbxTotalPopulation.Value;

            this._iDatabase.Update(data);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var targetId = this.nbxId.Value;
            this._iDatabase.Delete((int)targetId);
        }
    }
}
