using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVX_OptionChange
{
    public partial class frmSDVXOption : Form, Functions.IMain
    {
        private Functions.MainPresenter _cPresenter;

        public frmSDVXOption()
        {
            InitializeComponent();

        }

        private void frmSDVXOption_Load(object sender, EventArgs e)
        {
            _cPresenter = new Functions.MainPresenter(this);
            _cPresenter.LoadNavigatorList();
            _cPresenter.LoadFile();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            _cPresenter.HexEdit();
        }

        private void btnPremFreeHelp_Click(object sender, EventArgs e)
        {
            _cPresenter.ShowPremFreeHelp();
        }

        private void chkPremFree_CheckedChanged(object sender, EventArgs e)
        {
            _cPresenter.ShowPremFreeHelp();
        }

        #region Interface
        public DataTable NavigatorDataSource
        {
            get
            {
                return (DataTable) cmbNavigator.DataSource;
            }
            set
            {
                cmbNavigator.DataSource = value;
                cmbNavigator.DisplayMember = "NavName";
                cmbNavigator.BindingContext = this.BindingContext;
            }
        }
        public int NavigatorSelect {
            get
            {
                return cmbNavigator.SelectedIndex;
            }
            set
            {
                cmbNavigator.SelectedIndex = value;
            }
        }
        public bool AllStageSafe {
            get
            {
                return chkStageSafe.Checked;
            }
            set
            {
                chkStageSafe.Checked = value;
            }
        }

        public bool ForceEventMode
        {
            get
            {
                return chkEventMode.Checked;
            }
            set
            {
                chkEventMode.Checked = value;
            }
        }

        public bool AllDifficultyUnlock
        {
            get
            {
                return chkDiffUnlock.Checked;
            }
            set
            {
                chkDiffUnlock.Checked = value;
            }
        }

        public bool PremFree
        {
            get
            {
                return chkPremFree.Checked;
            }
            set
            {
                chkPremFree.Checked = value;
            }
        }
        #endregion


    }
}
