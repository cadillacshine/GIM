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
    public partial class FrmItem: Form {
        ItemRepository itemRepository;
        UOMRepository uomRepository;
        StatusRepository statusRepository;

        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        private string actionState = "a";
        private int itemID = 0;

        public FrmItem() {
            InitializeComponent();

            itemRepository = new ItemRepository();
            uomRepository = new UOMRepository();
            statusRepository = new StatusRepository();

            BtnAdd = controlNavigator1.Buttons.CustomButtons[0];
            BtnEdit = controlNavigator1.Buttons.CustomButtons[1];
            BtnSave = controlNavigator1.Buttons.CustomButtons[2];
            BtnCancel = controlNavigator1.Buttons.CustomButtons[3];
            BtnSwitch = controlNavigator1.Buttons.CustomButtons[4];
            BtnRefresh = controlNavigator1.Buttons.CustomButtons[5];
        }

        private void FrmItem_Load(object sender, EventArgs e) {
            loadForm();
        }

        private void loadForm() {
            gridControl1.DataSource = itemRepository.loadData();
            cmbUOM.DataSource = uomRepository.loadActiveData();
            cmbUOM.DisplayMember = "Name";
            cmbStatus.DataSource = statusRepository.loadActiveData();
            cmbStatus.DisplayMember = "Name";
        }

        private void setControlValues() {
            txtItemName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
            txtShortName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ShortName").ToString();
            txtAlias.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Alias").ToString();
            txtDescription.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Description").ToString();
            txtQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Quantity").ToString();
            cmbUOM.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UOM").ToString();
            txtPrice.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Price").ToString();
            txtExtension.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Extension").ToString();
            cmbStatus.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Status").ToString();
            cbActive.Checked = (bool)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Active");
        }

        private void selectionChanged() {
            setControlState(false);

            BtnAdd.Enabled = true;
            BtnEdit.Enabled = true;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnSwitch.Enabled = true;
            BtnRefresh.Enabled = true;
        }

        private void setControlState(bool status) {
            txtItemName.Enabled = status;
            txtShortName.Enabled = status;
            txtAlias.Enabled = status;
            txtDescription.Enabled = status;
            txtQuantity.Enabled = status;
            cmbUOM.Enabled = status;
            txtPrice.Enabled = status;
            txtExtension.Enabled = status;
            cmbStatus.Enabled = status;
            cbActive.Enabled = status;
        }

        private void emptyControls() {
            txtItemName.Text = "";
            txtShortName.Text = "";
            txtAlias.Text = "";
            txtDescription.Text = "";
            txtQuantity.Text = "";
            cmbUOM.Text = "";
            txtPrice.Text = "";
            txtExtension.Text = "";
            cmbStatus.Text = "";
            cbActive.Checked = true;
        }

        private bool verifyInput() {
            if (txtItemName.Text.Trim().Equals("")) {
                MessageBox.Show("Item name cannot be empty!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemName.Focus();
                return false;
            }
            return true;
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            // try {
            if (e.Button.Tag.ToString() == "Add") {
                toolStripStatusLabel1.Text = "Adding...";
                if (tableLayoutPanel1.RowStyles[2].Height == 1)
                    tableLayoutPanel1.RowStyles[2].Height = 295;
                actionState = "a";
                setControlState(true);
                emptyControls();
                txtItemName.Focus();

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
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

            } else if (e.Button.Tag.ToString() == "Edit") {

                itemID = itemRepository.getID(txtItemName.Text);

                if (tableLayoutPanel1.RowStyles[2].Height == 1)
                    tableLayoutPanel1.RowStyles[2].Height = 295;
                actionState = "e";
                setControlState(true);

                txtItemName.Focus();
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
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

                if (actionState == "e") {
                    toolStripStatusLabel1.Text = "Editing...";

                    Item item = new Item {
                        name = txtItemName.Text,
                        shortName = txtShortName.Text,
                        alias = txtAlias.Text,
                        description = txtDescription.Text,
                        quantity = Convert.ToDouble(txtQuantity.Text),
                        unitOfMeasure = cmbUOM.Text,
                        price = Convert.ToDouble(txtPrice.Text),
                        extension = Convert.ToDouble(txtExtension.Text),
                        status = cmbStatus.Text,
                        active = cbActive.Checked
                    };

                    itemRepository.update(itemID, item);
                } else if (actionState == "a") {
                    toolStripStatusLabel1.Text = "Saving...";

                    if (!verifyInput())
                        return;

                    Item item = new Item {
                        name = txtItemName.Text,
                        shortName = txtShortName.Text,
                        alias = txtAlias.Text,
                        description = txtDescription.Text,
                        quantity = Convert.ToDouble(txtQuantity.Text),
                        unitOfMeasure = cmbUOM.Text,
                        price = Convert.ToDouble(txtPrice.Text),
                        extension = Convert.ToDouble(txtExtension.Text),
                        status = cmbStatus.Text,
                        active = cbActive.Checked
                    };

                    itemRepository.add(item);
                }

                actionState = "a";

                gridControl1.DataSource = itemRepository.loadData();
                setControlState(false);
                BtnSave.Enabled = false;
                BtnEdit.Enabled = true;
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
                BtnEdit.Enabled = true;
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
                if (tableLayoutPanel1.RowStyles[2].Height == 295) {
                    tableLayoutPanel1.RowStyles[2].Height = 1;
                } else {
                    tableLayoutPanel1.RowStyles[2].Height = 295;
                }
            }
            //} catch {

            //}
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e) {
            txtShortName.Text = txtItemName.Text;
        }
    }
}
