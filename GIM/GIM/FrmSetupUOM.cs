﻿using DevExpress.XtraEditors;
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
    public partial class FrmSetupUOM: Form {

        UOMRepository repository;
        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        private string actionState = "a";
        private int uomID = 0;

        public FrmSetupUOM() {
            InitializeComponent();

            repository = new UOMRepository();

            BtnAdd = controlNavigator1.Buttons.CustomButtons[0];
            BtnEdit = controlNavigator1.Buttons.CustomButtons[1];
            BtnSave = controlNavigator1.Buttons.CustomButtons[2];
            BtnCancel = controlNavigator1.Buttons.CustomButtons[3];
            BtnSwitch = controlNavigator1.Buttons.CustomButtons[4];
            BtnRefresh = controlNavigator1.Buttons.CustomButtons[5];
        }

        private void FrmSetupUOM_Load(object sender, EventArgs e) {
            loadForm();
        }

        private void loadForm() {
            gridControl1.DataSource = repository.loadData();
        }

        private void setControlValues() {
            txtUom.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
            txtShortName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ShortName").ToString();
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
            txtUom.Enabled = status;
            txtShortName.Enabled = status;
            cbActive.Enabled = status;
        }   

        private void emptyControls() {
            txtUom.Text = "";
            txtShortName.Text = "";
        }

        private bool verifyInput() {
            if (txtUom.Text.Trim().Equals("")) {
                MessageBox.Show("Unit Of Measure cannot be empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUom.Focus();
                return false;
            }
            return true;
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            // try {
            if (e.Button.Tag.ToString() == "Add") {
                toolStripStatusLabel1.Text = "Adding...";
                if (tableLayoutPanel1.RowStyles[2].Height == 1)
                    tableLayoutPanel1.RowStyles[2].Height = 80;
                actionState = "a";
                setControlState(true);
                emptyControls();
                txtUom.Focus();

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

                uomID = repository.getID(txtUom.Text);

                if (tableLayoutPanel1.RowStyles[2].Height == 1)
                    tableLayoutPanel1.RowStyles[2].Height = 80;
                actionState = "e";
                setControlState(true);

                txtUom.Focus();
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

                    UnitOfMeasure uom = new UnitOfMeasure {
                        name = txtUom.Text,
                        shortName = txtShortName.Text,
                        active = cbActive.Checked
                    };

                    repository.update(uomID, uom);
                } else if (actionState == "a") {
                    toolStripStatusLabel1.Text = "Saving...";

                    if (!verifyInput())
                        return;

                    UnitOfMeasure uom = new UnitOfMeasure {
                        name = txtUom.Text,
                        shortName = txtShortName.Text,
                        active = cbActive.Checked
                    };

                    repository.add(uom);
                }

                actionState = "a";

                gridControl1.DataSource = repository.loadData();
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
                gridControl1.DataSource = repository.loadData();
                toolStripStatusLabel1.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Switch") {
                if (tableLayoutPanel1.RowStyles[2].Height == 80) {
                    tableLayoutPanel1.RowStyles[2].Height = 1;
                } else {
                    tableLayoutPanel1.RowStyles[2].Height = 80;
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

        private void txtUom_TextChanged(object sender, EventArgs e) {
            txtShortName.Text = txtUom.Text;
        }
    }
}
