﻿namespace WFAplicationVacation
{
    partial class date
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewVacations = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.holyDayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndexDate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.firstDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secontDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVacations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holyDayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(122, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridViewVacations.AllowUserToAddRows = false;
            this.dataGridViewVacations.AutoGenerateColumns = false;
            this.dataGridViewVacations.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewVacations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewVacations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVacations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.IndexDate,
            this.firstDateDataGridViewTextBoxColumn,
            this.secontDateDataGridViewTextBoxColumn,
            this.Days});
            this.dataGridViewVacations.DataSource = this.holyDayBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewVacations.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewVacations.Location = new System.Drawing.Point(25, 37);
            this.dataGridViewVacations.Name = "dataGridView1";
            this.dataGridViewVacations.ReadOnly = true;
            this.dataGridViewVacations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVacations.Size = new System.Drawing.Size(570, 134);
            this.dataGridViewVacations.TabIndex = 14;
            this.dataGridViewVacations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(289, 228);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnDeleteDate);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(219, 234);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(43, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "use";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // holyDayBindingSource
            // 
            this.holyDayBindingSource.DataSource = typeof(WFAplicationVacation.Vacation);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // IndexDate
            // 
            this.IndexDate.DataPropertyName = "IndexDate";
            this.IndexDate.HeaderText = "it is used";
            this.IndexDate.Name = "IndexDate";
            this.IndexDate.ReadOnly = true;
            // 
            // firstDateDataGridViewTextBoxColumn
            // 
            this.firstDateDataGridViewTextBoxColumn.DataPropertyName = "FirstDate";
            this.firstDateDataGridViewTextBoxColumn.HeaderText = "Start Date";
            this.firstDateDataGridViewTextBoxColumn.Name = "firstDateDataGridViewTextBoxColumn";
            this.firstDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // secontDateDataGridViewTextBoxColumn
            // 
            this.secontDateDataGridViewTextBoxColumn.DataPropertyName = "SecontDate";
            this.secontDateDataGridViewTextBoxColumn.HeaderText = "End Date";
            this.secontDateDataGridViewTextBoxColumn.Name = "secontDateDataGridViewTextBoxColumn";
            this.secontDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Days
            // 
            this.Days.DataPropertyName = "Days";
            this.Days.HeaderText = "Days";
            this.Days.Name = "Days";
            this.Days.ReadOnly = true;
            // 
            // date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(607, 290);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridViewVacations);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "date";
            this.Text = "date";
            this.Load += new System.EventHandler(this.date_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVacations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holyDayBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.Button button1;
        protected internal System.Windows.Forms.DataGridView dataGridViewVacations;
        private System.Windows.Forms.BindingSource holyDayBindingSource;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IndexDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secontDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
    }
}