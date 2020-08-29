using System;
using System.Windows.Forms;
using NpgsqlTypes;
using NpgsqlWinFormsApp.DB;

namespace NpgsqlWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var query = new Query())
            {
                try
                {
                    query.Add("email", "e", NpgsqlDbType.Text);
                    var a = query.ExecuteNonQuery();
                    var v = query.FillData();
                    MessageBox.Show("success");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var query = new Query())
            {
                query.Add("email", "e", NpgsqlDbType.Text);
                var a = query.ExecuteNonQuery();
                var v = query.FillData();
                var dataTableJson = new DataTableJsonConverter();
                var json = dataTableJson.ConvertToJson(v);
                MessageBox.Show(json);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var query = new Query())
            {
                try
                {
                    query.Add("email", "e", NpgsqlDbType.Text);
                    var a = query.ExecuteNonQuery();
                    var v = query.FillData();
                    var dataTableJson = new DataTableJsonConverter();
                    var json = dataTableJson.ConvertToJson(v);
                    var dataTable = dataTableJson.ConvertToDataTable(json);
                    MessageBox.Show("success");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                
            }
        }
        private void SetDataGridColumnCastomization(User user)
        {
            MessageBox.Show("234");
        }
        

        /*private void CustomDataGridView1_ColumnChangeSettingsEvent(DataGridColumnCastomization settings)
        {
            var castomProperty = context.DataGridColumnCastomization.FirstOrDefault(dg => dg.ID.Equals(settings.ID));
            if (castomProperty != null)
            {
                castomProperty.Width = settings.Width;
                castomProperty.Visible = settings.Visible;

                context.Entry(castomProperty).State = EntityState.Modified;
            }
            else
            {
                var user = (User)comboBoxUserActive.SelectedValue;
                settings.UserId = user.ID;
                context.DataGridColumnCastomization.Add(settings);
            }
            context.SaveChanges();
        }*/

        private void comboBoxUserActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var user = (User)((ComboBox)sender).SelectedValue;
                SetDataGridColumnCastomization(user);
            }
            catch (Exception ex)
            {
                // TODO: error connection
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customDataGridView1.SwitchVisibleColumn();
        }
    }
}