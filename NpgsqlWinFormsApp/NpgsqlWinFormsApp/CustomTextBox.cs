using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NpgsqlWinFormsApp.Interfaces;

namespace NpgsqlWinFormsApp
{
    public partial class CustomTextBox : TextBox, ICheckableControl
    {
        public CustomTextBox()
        {
            InitializeComponent();
        }
       
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        public bool EmptyDataCheck { get; set; }

        public bool Check()
        {
            if (this.Text != null && this.Text != string.Empty) 
                return true;

            return false;
        }
    }
}
