using System;
using System.Drawing;
using System.Windows.Forms;

namespace NpgsqlWinFormsApp.CustomMessageBox
{
    public class FormInputTextWithConfirm : Form
    {
        private Button button1;
        private Button button2;
        private TextBox textBox1;


        public FormInputTextWithConfirm()
        {
            InitializeComponent();
        }

        public string FilterText
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        private void FormInputTextWithConfirm_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(323, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(123, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(229, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormInputTextWithConfirm
            // 
            this.ClientSize = new System.Drawing.Size(344, 102);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "FormInputTextWithConfirm";
            this.Text = "Фильтр";
            this.Shown += new System.EventHandler(this.FormInputTextWithConfirm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}