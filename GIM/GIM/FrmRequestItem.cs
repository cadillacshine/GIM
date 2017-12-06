using DevExpress.XtraEditors;
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
    public partial class FrmRequestItem: Form {
        ItemRepository itemRepository;

        NavigatorCustomButton BtnAdd, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        private string actionState = "a";
        private int itemID = 0;

        public FrmRequestItem() {
            InitializeComponent();

            itemRepository = new ItemRepository();

            BtnAdd = controlNavigator1.Buttons.CustomButtons[0];
            BtnSave = controlNavigator1.Buttons.CustomButtons[2];
            BtnCancel = controlNavigator1.Buttons.CustomButtons[3];
            BtnSwitch = controlNavigator1.Buttons.CustomButtons[4];
            BtnRefresh = controlNavigator1.Buttons.CustomButtons[5];

            controlNavigator1.Buttons.ImageList = sharedImageCollection1;
            controlNavigator1.Buttons.CustomButtons[0].ImageIndex = 6;
            controlNavigator1.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigator1.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigator1.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigator1.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigator1.Buttons.CustomButtons[5].ImageIndex = 5;
        }

        private void FrmRequestItem_Load(object sender, EventArgs e) {
            loadForm();
        }

        private void loadForm() {
            gridControl1.DataSource = itemRepository.loadData();
        }

        private void setControlValues() {
            txtItemName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
            txtShortName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ShortName").ToString();
            txtAlias.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Alias").ToString();
            txtQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Quantity").ToString();
        }

        private void selectionChanged() {
            setControlState(false);

            BtnAdd.Enabled = true;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnSwitch.Enabled = true;
            BtnRefresh.Enabled = true;

            txtRequestQuantity.Text = "0";
            txtRequestQuantity.SelectAll();
            txtRequestQuantity.Focus();
        }

        private void setControlState(bool status) {
            txtRequestQuantity.Enabled = status;
        }

        private void emptyControls() {
            txtItemName.Text = "";
            txtShortName.Text = "";
            txtAlias.Text = "";
            txtQuantity.Text = "";
        }

        private bool verifyInput() {
            if (txtRequestQuantity.Text.Trim().Equals("")) {
                MessageBox.Show("Quantity cannot be empty!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRequestQuantity.Focus();
                return false;
            }

            if (Convert.ToDouble(txtRequestQuantity.Text) > Convert.ToDouble(txtQuantity.Text)) {
                MessageBox.Show("Quantity requested cannot be more than quantity in stock!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRequestQuantity.Focus();
                return false;
            }
            return true;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            // try {
            if (e.Button.Tag.ToString() == "Request") {
                toolStripStatusLabel1.Text = "Requesting for item...";

                itemID = itemRepository.getID(txtItemName.Text);

                if (tableLayoutPanel1.RowStyles[2].Height == 1)
                    tableLayoutPanel1.RowStyles[2].Height = 120;
                actionState = "a";
                setControlState(true);

                txtItemName.Focus();
                BtnAdd.Enabled = false;
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnSwitch.Enabled = false;
                BtnRefresh.Enabled = false;

                controlNavigator1.Buttons.First.Enabled = false;
                controlNavigator1.Buttons.Next.Enabled = false;
                controlNavigator1.Buttons.Prev.Enabled = false;
                controlNavigator1.Buttons.Last.Enabled = false;

                searchControl1.Enabled = false;
                gridControl1.Enabled = false;

            } else if (e.Button.Tag.ToString() == "Save") {

                if (actionState == "a") {
                    toolStripStatusLabel1.Text = "Saving...";

                    if (!verifyInput())
                        return;

                    Item item = new Item {
                        name = txtItemName.Text,
                        shortName = txtShortName.Text,
                        alias = txtAlias.Text,
                        description = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Description").ToString(),
                        quantity = Convert.ToDouble(txtQuantity.Text) - Convert.ToDouble(txtRequestQuantity.Text),
                        unitOfMeasure = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UOM").ToString(),
                        price = (double)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Price"),
                        extension = (double)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Extension"),
                        status = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Status").ToString(),
                        active = (bool)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Active")
                    };

                    itemRepository.update(itemID, item);
                }

                gridControl1.DataSource = itemRepository.loadData();
                setControlState(false);
                BtnSave.Enabled = false;
                BtnAdd.Enabled = true;
                BtnCancel.Enabled = false;
                BtnSwitch.Enabled = true;
                BtnRefresh.Enabled = true;

                controlNavigator1.Buttons.First.Enabled = true;
                controlNavigator1.Buttons.Next.Enabled = true;
                controlNavigator1.Buttons.Prev.Enabled = true;
                controlNavigator1.Buttons.Last.Enabled = true;

                searchControl1.Enabled = true;
                gridControl1.Enabled = true;
                toolStripStatusLabel1.Text = "Saved";

            } else if (e.Button.Tag.ToString() == "Cancel") {
                setControlState(false);
                actionState = "a";
                BtnAdd.Enabled = true;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnSwitch.Enabled = true;
                BtnRefresh.Enabled = true;

                controlNavigator1.Buttons.First.Enabled = true;
                controlNavigator1.Buttons.Next.Enabled = true;
                controlNavigator1.Buttons.Prev.Enabled = true;
                controlNavigator1.Buttons.Last.Enabled = true;

                searchControl1.Enabled = true;
                gridControl1.Enabled = true;

                toolStripStatusLabel1.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Refresh") {
                toolStripStatusLabel1.Text = "Refreshing...";
                gridControl1.DataSource = itemRepository.loadData();
                toolStripStatusLabel1.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Switch") {
                if (tableLayoutPanel1.RowStyles[2].Height == 120) {
                    tableLayoutPanel1.RowStyles[2].Height = 1;
                } else {
                    tableLayoutPanel1.RowStyles[2].Height = 120;
                }
            }
            //} catch {

            //}
        }
    }
}
