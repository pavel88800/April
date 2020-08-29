namespace NpgsqlWinFormsApp
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
            this.btnConnection = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.customDataGridView1 = new NpgsqlWinFormsApp.CustomDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(12, 12);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(181, 23);
            this.btnConnection.TabIndex = 0;
            this.btnConnection.Text = "Проверка соединение с БД";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Проверка преобразования из DataTable в Json";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(527, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Проверка преобразования из Json в DataTable ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnConnection);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.customDataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(949, 477);
            this.splitContainer1.SplitterDistance = 113;
            this.splitContainer1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Скрыть/Отобразить колонки";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // customDataGridView1
            // 
            this.customDataGridView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.customDataGridView1.DataSource = null;
            this.customDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.customDataGridView1.Name = "customDataGridView1";
            this.customDataGridView1.Size = new System.Drawing.Size(945, 356);
            this.customDataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 477);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button3;
        private CustomDataGridView customDataGridView1;
    }
}

