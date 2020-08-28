namespace BallonTipApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTest = new System.Windows.Forms.Label();
            this.txtboxTestHint = new System.Windows.Forms.TextBox();
            this.btnTestHint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(32, 42);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(90, 13);
            this.lblTest.TabIndex = 0;
            this.lblTest.Text = "Проверка Хинта";
            // 
            // txtboxTestHint
            // 
            this.txtboxTestHint.Location = new System.Drawing.Point(181, 42);
            this.txtboxTestHint.Name = "txtboxTestHint";
            this.txtboxTestHint.Size = new System.Drawing.Size(546, 20);
            this.txtboxTestHint.TabIndex = 1;
            // 
            // btnTestHint
            // 
            this.btnTestHint.Location = new System.Drawing.Point(181, 143);
            this.btnTestHint.Name = "btnTestHint";
            this.btnTestHint.Size = new System.Drawing.Size(447, 23);
            this.btnTestHint.TabIndex = 2;
            this.btnTestHint.Text = "Test";
            this.btnTestHint.UseVisualStyleBackColor = true;
            this.btnTestHint.Click += new System.EventHandler(this.btnTestHint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTestHint);
            this.Controls.Add(this.txtboxTestHint);
            this.Controls.Add(this.lblTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtboxTestHint;
        private System.Windows.Forms.Button btnTestHint;
    }
}

