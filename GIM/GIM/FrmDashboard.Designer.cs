namespace GIM {
    partial class FrmDashboard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiManageItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem2 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiAddItemQuantity = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem4 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiRequestItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem5 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem1 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup5 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiSetupItemStatus = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem3 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiSetupUOM = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup2;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup5,
            this.navBarGroup2,
            this.navBarGroup3,
            this.navBarGroup4});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarSeparatorItem1,
            this.navBarItem2,
            this.nbiManageItem,
            this.navBarSeparatorItem2,
            this.navBarItem4,
            this.nbiSetupItemStatus,
            this.navBarSeparatorItem3,
            this.nbiSetupUOM,
            this.nbiAddItemQuantity,
            this.navBarSeparatorItem4,
            this.navBarSeparatorItem5,
            this.nbiRequestItem});
            this.navBarControl1.Location = new System.Drawing.Point(0, 35);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 174;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(174, 577);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Items";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiManageItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiAddItemQuantity),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem4),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiRequestItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4)});
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup2.SmallImage")));
            // 
            // nbiManageItem
            // 
            this.nbiManageItem.Caption = "Manage Item(s)";
            this.nbiManageItem.Name = "nbiManageItem";
            this.nbiManageItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbiManageItem.SmallImage")));
            this.nbiManageItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiManageItem_LinkClicked);
            // 
            // navBarSeparatorItem2
            // 
            this.navBarSeparatorItem2.CanDrag = false;
            this.navBarSeparatorItem2.Enabled = false;
            this.navBarSeparatorItem2.Hint = null;
            this.navBarSeparatorItem2.LargeImageIndex = 0;
            this.navBarSeparatorItem2.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem2.Name = "navBarSeparatorItem2";
            this.navBarSeparatorItem2.SmallImageIndex = 0;
            this.navBarSeparatorItem2.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiAddItemQuantity
            // 
            this.nbiAddItemQuantity.Caption = "Add Quantity";
            this.nbiAddItemQuantity.Name = "nbiAddItemQuantity";
            this.nbiAddItemQuantity.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbiAddItemQuantity.SmallImage")));
            this.nbiAddItemQuantity.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiAddItemQuantity_LinkClicked);
            // 
            // navBarSeparatorItem4
            // 
            this.navBarSeparatorItem4.CanDrag = false;
            this.navBarSeparatorItem4.Enabled = false;
            this.navBarSeparatorItem4.Hint = null;
            this.navBarSeparatorItem4.LargeImageIndex = 0;
            this.navBarSeparatorItem4.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem4.Name = "navBarSeparatorItem4";
            this.navBarSeparatorItem4.SmallImageIndex = 0;
            this.navBarSeparatorItem4.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiRequestItem
            // 
            this.nbiRequestItem.Caption = "Request Item(s)";
            this.nbiRequestItem.Name = "nbiRequestItem";
            this.nbiRequestItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbiRequestItem.SmallImage")));
            // 
            // navBarSeparatorItem5
            // 
            this.navBarSeparatorItem5.CanDrag = false;
            this.navBarSeparatorItem5.Enabled = false;
            this.navBarSeparatorItem5.Hint = null;
            this.navBarSeparatorItem5.LargeImageIndex = 0;
            this.navBarSeparatorItem5.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem5.Name = "navBarSeparatorItem5";
            this.navBarSeparatorItem5.SmallImageIndex = 0;
            this.navBarSeparatorItem5.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "Junkyard";
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem4.SmallImage")));
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "System Admin";
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.SmallImage")));
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Manage Account(s)";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem1.SmallImage")));
            // 
            // navBarSeparatorItem1
            // 
            this.navBarSeparatorItem1.CanDrag = false;
            this.navBarSeparatorItem1.Enabled = false;
            this.navBarSeparatorItem1.Hint = null;
            this.navBarSeparatorItem1.LargeImageIndex = 0;
            this.navBarSeparatorItem1.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem1.Name = "navBarSeparatorItem1";
            this.navBarSeparatorItem1.SmallImageIndex = 0;
            this.navBarSeparatorItem1.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Activity Log";
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem2.SmallImage")));
            // 
            // navBarGroup5
            // 
            this.navBarGroup5.Caption = "Me";
            this.navBarGroup5.Name = "navBarGroup5";
            this.navBarGroup5.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup5.SmallImage")));
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Inventory";
            this.navBarGroup3.Name = "navBarGroup3";
            this.navBarGroup3.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup3.SmallImage")));
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "Setups";
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSetupItemStatus),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSetupUOM)});
            this.navBarGroup4.Name = "navBarGroup4";
            this.navBarGroup4.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup4.SmallImage")));
            // 
            // nbiSetupItemStatus
            // 
            this.nbiSetupItemStatus.Caption = "Item Status";
            this.nbiSetupItemStatus.Name = "nbiSetupItemStatus";
            this.nbiSetupItemStatus.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbiSetupItemStatus.SmallImage")));
            this.nbiSetupItemStatus.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSetupItemStatus_LinkClicked);
            // 
            // navBarSeparatorItem3
            // 
            this.navBarSeparatorItem3.CanDrag = false;
            this.navBarSeparatorItem3.Enabled = false;
            this.navBarSeparatorItem3.Hint = null;
            this.navBarSeparatorItem3.LargeImageIndex = 0;
            this.navBarSeparatorItem3.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem3.Name = "navBarSeparatorItem3";
            this.navBarSeparatorItem3.SmallImageIndex = 0;
            this.navBarSeparatorItem3.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiSetupUOM
            // 
            this.nbiSetupUOM.Caption = "Unit Of Measure";
            this.nbiSetupUOM.Name = "nbiSetupUOM";
            this.nbiSetupUOM.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbiSetupUOM.SmallImage")));
            this.nbiSetupUOM.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSetupUOM_LinkClicked);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1164, 35);
            this.panelControl1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(871, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administrator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(1126, 5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(33, 25);
            this.pictureEdit1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 612);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1164, 14);
            this.panelControl2.TabIndex = 3;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1164, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 626);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1164, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 626);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1164, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 626);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 626);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDashboard";
            this.Text = "GIM - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup4;
        private DevExpress.XtraNavBar.NavBarItem nbiSetupItemStatus;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem3;
        private DevExpress.XtraNavBar.NavBarItem nbiSetupUOM;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem nbiManageItem;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup5;
        private DevExpress.XtraNavBar.NavBarItem nbiAddItemQuantity;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem4;
        private DevExpress.XtraNavBar.NavBarItem nbiRequestItem;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem5;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}