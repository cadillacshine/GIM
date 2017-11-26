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
    public partial class FrmDashboard: Form {
        private FrmSetupStatus fSetupStatus;
        private FrmSetupUOM fSetupUOM;
        private FrmItem fItem;
        private FrmAddItemQuantity fAddItemQuantity;

        public FrmDashboard() {
            InitializeComponent();
        }

        private void launchItemStatus() {
            if (fSetupStatus != null) {
                if (!fSetupStatus.IsDisposed) {
                    fSetupStatus.MdiParent = this;
                    fSetupStatus.WindowState = FormWindowState.Normal;
                    fSetupStatus.BringToFront();
                } else {
                    fSetupStatus = new FrmSetupStatus();
                    fSetupStatus.MdiParent = this;
                    fSetupStatus.Show();
                }
            } else {
                fSetupStatus = new FrmSetupStatus();
                fSetupStatus.MdiParent = this;
                fSetupStatus.Show();
            }
        }

        private void launchUOM() {
            if (fSetupUOM != null) {
                if (!fSetupUOM.IsDisposed) {
                    fSetupUOM.MdiParent = this;
                    fSetupUOM.WindowState = FormWindowState.Normal;
                    fSetupUOM.BringToFront();
                } else {
                    fSetupUOM = new FrmSetupUOM();
                    fSetupUOM.MdiParent = this;
                    fSetupUOM.Show();
                }
            } else {
                fSetupUOM = new FrmSetupUOM();
                fSetupUOM.MdiParent = this;
                fSetupUOM.Show();
            }
        }

        private void launchItem() {
            if (fItem != null) {
                if (!fItem.IsDisposed) {
                    fItem.MdiParent = this;
                    fItem.WindowState = FormWindowState.Normal;
                    fItem.BringToFront();
                } else {
                    fItem = new FrmItem();
                    fItem.MdiParent = this;
                    fItem.Show();
                }
            } else {
                fItem = new FrmItem();
                fItem.MdiParent = this;
                fItem.Show();
            }
        }

        private void launchAddItemQuantity() {
            if (fAddItemQuantity != null) {
                if (!fAddItemQuantity.IsDisposed) {
                    fAddItemQuantity.MdiParent = this;
                    fAddItemQuantity.WindowState = FormWindowState.Normal;
                    fAddItemQuantity.BringToFront();
                } else {
                    fAddItemQuantity = new FrmAddItemQuantity();
                    fAddItemQuantity.MdiParent = this;
                    fAddItemQuantity.Show();
                }
            } else {
                fAddItemQuantity = new FrmAddItemQuantity();
                fAddItemQuantity.MdiParent = this;
                fAddItemQuantity.Show();
            }
        }

        private void FrmDashboard_Load(object sender, EventArgs e) {

        }

        private void nbiSetupItemStatus_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchItemStatus();
        }

        private void nbiSetupUOM_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchUOM();
        }

        private void nbiManageItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchItem();
        }

        private void nbiAddItemQuantity_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchAddItemQuantity();
        }
    }
}
