using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIM {
    public partial class FrmLogin: Form {
        private FrmDashboard fDashboard;

        public FrmLogin() {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e) {
            Misc.setConn("Production");
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            fDashboard = new FrmDashboard();
            fDashboard.Show();
            this.Hide();
        }
    }
}
