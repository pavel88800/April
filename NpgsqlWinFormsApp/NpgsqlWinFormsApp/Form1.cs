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
    }
}