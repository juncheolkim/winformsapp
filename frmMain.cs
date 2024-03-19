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
            GetAllData();
        }
        private void GetAllData()
        {
            var allData = this._iDatabase.Get();
        }
    }
}
