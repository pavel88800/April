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
                query.Add("email", "e2", NpgsqlDbType.Text);
              var a =  query.ExecuteNonQuery();
             var v = query.FillData();
            }
        }
    }
}