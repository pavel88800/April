using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NpgsqlTypes;
using NpgsqlWinFormsApp.CustomMessageBox;
using NpgsqlWinFormsApp.DB;

namespace NpgsqlWinFormsApp
{
    public class CustomDataGridView : UserControl
    {
        public delegate void ColumnChangeSettingsEventHandler(DataGridColumnCastomization settings);

        private readonly CustomDataGridContextMenu contextMenu;
        private readonly FormInputTextWithConfirm dialogForm;

        private bool BlockSaveSetting;
        private DataGridView dataGridView1;
        private int filtredColumnsIndex;
        private bool waitFilterKeyPress;

        public CustomDataGridView()
        {
            InitializeComponent();

            dialogForm = new FormInputTextWithConfirm();
            dialogForm.Text = "Введите данные";

            contextMenu = new CustomDataGridContextMenu(dataGridView1);
            contextMenu.VisibleChangeEvent += ContextMenu_VisibleChangeEvent;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnWidthChanged += DataGridView1_ColumnWidthChanged;
        }

        public DataTable DataSource
        {
            get => (DataTable) dataGridView1.DataSource;
            set
            {
                using (var query = new Query())
                {
                    query.Add("", null, NpgsqlDbType.Text);
                    var execute = query.ExecuteNonQuery();
                    var data = query.FillData();
                    var dataTable = data;
                    dataGridView1.DataSource = data;
                    if (dataTable != null)
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            var newColumn = new CustomDataGridViewTextBoxColumn();
                            newColumn.Name = col.ColumnName;
                            newColumn.DataPropertyName = col.ColumnName;
                            dataGridView1.Columns.Add(newColumn);
                        }
                }
            }
        }

        public event ColumnChangeSettingsEventHandler ColumnChangeSettingsEvent;

        private void ContextMenu_VisibleChangeEvent(CustomDataGridViewTextBoxColumn column)
        {
            ColumnChangeSettings(column);
        }

        private void DataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            ColumnChangeSettings((CustomDataGridViewTextBoxColumn) e.Column);
        }

        private void ColumnChangeSettings(CustomDataGridViewTextBoxColumn column)
        {
            if (BlockSaveSetting) return;

            var setting = new DataGridColumnCastomization
            {
                ID = column.UserSettingID != Guid.Empty ? column.UserSettingID : Guid.NewGuid(),
                Name = column.Name,
                Width = column.Width,
                Visible = column.Visible
            };
            ColumnChangeSettingsEvent?.Invoke(setting);
        }

        public void SetCastomColumnsProperty(List<DataGridColumnCastomization> settings)
        {
            BlockSaveSetting = true;
            foreach (CustomDataGridViewTextBoxColumn column in dataGridView1.Columns)
            {
                var set = settings.FirstOrDefault(s => s.Name.Equals(column.DataPropertyName));
                if (set != null)
                {
                    column.UserSettingID = set.ID;
                    column.Width = set.Width;
                    column.Visible = set.Visible;
                }
                else
                {
                    column.DefaultSeting();
                }
            }

            BlockSaveSetting = false;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    SetSelectFilterColumn(e.ColumnIndex);
                    break;
                case MouseButtons.Right:
                    ShowContextMenu(e);
                    break;
            }
        }

        private void ShowContextMenu(DataGridViewCellMouseEventArgs e)
        {
            contextMenu.CreateItems(e.ColumnIndex);
            contextMenu.Show();
        }

        private void SetSelectFilterColumn(int index = -1)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.HeaderCell.Style.Font = new Font(col.HeaderCell.Style.Font, FontStyle.Regular);

            if (waitFilterKeyPress && index >= 0 && filtredColumnsIndex != index) waitFilterKeyPress = false;

            if (!waitFilterKeyPress && index >= 0)
            {
                filtredColumnsIndex = index;

                var headerCell = dataGridView1.Columns[filtredColumnsIndex].HeaderCell;
                headerCell.Style.Font = new Font(headerCell.Style.Font, FontStyle.Bold);
            }

            waitFilterKeyPress = !waitFilterKeyPress;
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            var column = (CustomDataGridViewTextBoxColumn) e.Column;

            column.SortMode = DataGridViewColumnSortMode.Programmatic;

            var style = new DataGridViewCellStyle();
            style.Font = new Font(Font, FontStyle.Regular);

            column.HeaderCell.Style = style;

            column.DefaultWidth = column.Width;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dataGridViewControl = (DataGridViewTextBoxEditingControl) e.Control;
            dataGridViewControl.KeyPress += DataGridViewControl_KeyPress;
        }

        private void DataGridViewControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (waitFilterKeyPress)
            {
                dialogForm.FilterText = e.KeyChar.ToString();
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    var filterField = dataGridView1.Columns[filtredColumnsIndex].Name;
                    DataSource.DefaultView.RowFilter =
                        string.Format("[{0}] LIKE '%{1}%'", filterField, dialogForm.FilterText);
                }

                SetSelectFilterColumn();
                e.Handled = true;
            }
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            ((ISupportInitialize) dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(801, 409);
            dataGridView1.TabIndex = 0;
            dataGridView1.ColumnAdded += dataGridView1_ColumnAdded;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            // 
            // CustomDataGridView
            // 
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(dataGridView1);
            Name = "CustomDataGridView";
            Size = new Size(801, 409);
            ((ISupportInitialize) dataGridView1).EndInit();
            ResumeLayout(false);
        }

        public void SwitchVisibleColumn()
        {
            foreach (var column in dataGridView1.Columns)
                if (column.GetType() == typeof(CustomDataGridViewTextBoxColumn))
                {
                    var col = (CustomDataGridViewTextBoxColumn) column;
                    if (col.CanSwitch) col.Visible = !col.Visible;
                }
        }
    }
}