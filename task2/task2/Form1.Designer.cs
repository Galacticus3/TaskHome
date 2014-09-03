namespace task2
{
    partial class Form1
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
            this.btnAddToList = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblEducation = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblProfession = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbEducation = new System.Windows.Forms.ComboBox();
            this.dtmDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cmbProfession = new System.Windows.Forms.ComboBox();
            this.lblZp = new System.Windows.Forms.Label();
            this.txtZp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(31, 176);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToList.TabIndex = 0;
            this.btnAddToList.Text = "Додати";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(29, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(26, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Ім\'я";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(28, 41);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(56, 13);
            this.lblSurname.TabIndex = 2;
            this.lblSurname.Text = "Прізвище";
            // 
            // lblEducation
            // 
            this.lblEducation.AutoSize = true;
            this.lblEducation.Location = new System.Drawing.Point(29, 98);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(40, 13);
            this.lblEducation.TabIndex = 3;
            this.lblEducation.Text = "Освіта";
            this.lblEducation.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(28, 71);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(98, 13);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "Дата народження";
            this.lblDateOfBirth.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblProfession
            // 
            this.lblProfession.AutoSize = true;
            this.lblProfession.Location = new System.Drawing.Point(29, 120);
            this.lblProfession.Name = "lblProfession";
            this.lblProfession.Size = new System.Drawing.Size(55, 13);
            this.lblProfession.TabIndex = 5;
            this.lblProfession.Text = "Професія";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(141, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(141, 38);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(145, 20);
            this.txtSurname.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(31, 228);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(657, 204);
            this.dataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ім\'я";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Прізвище";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Дата народження";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Освіта";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Професія";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Зарплата";
            this.Column6.Name = "Column6";
            // 
            // cmbEducation
            // 
            this.cmbEducation.FormattingEnabled = true;
            this.cmbEducation.Items.AddRange(new object[] {
            "Вища",
            "Бакалавр",
            "Середня"});
            this.cmbEducation.Location = new System.Drawing.Point(141, 90);
            this.cmbEducation.Name = "cmbEducation";
            this.cmbEducation.Size = new System.Drawing.Size(144, 21);
            this.cmbEducation.TabIndex = 10;
            // 
            // dtmDateOfBirth
            // 
            this.dtmDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmDateOfBirth.Location = new System.Drawing.Point(141, 64);
            this.dtmDateOfBirth.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtmDateOfBirth.MinDate = new System.DateTime(1985, 1, 1, 0, 0, 0, 0);
            this.dtmDateOfBirth.Name = "dtmDateOfBirth";
            this.dtmDateOfBirth.Size = new System.Drawing.Size(145, 20);
            this.dtmDateOfBirth.TabIndex = 11;
            this.dtmDateOfBirth.Value = new System.DateTime(1985, 1, 1, 0, 0, 0, 0);
            // 
            // cmbProfession
            // 
            this.cmbProfession.FormattingEnabled = true;
            this.cmbProfession.Items.AddRange(new object[] {
            "Бухгалтер",
            "Економіст",
            "Кадровик",
            "Інженер з нагляду за будівництвом",
            "Інженер з охорони праці і техніки безпеки",
            "Касир",
            "Юрист",
            "Програміст",
            "Системний адміністратор",
            "Секретар",
            "Охоронник"});
            this.cmbProfession.Location = new System.Drawing.Point(141, 117);
            this.cmbProfession.Name = "cmbProfession";
            this.cmbProfession.Size = new System.Drawing.Size(144, 21);
            this.cmbProfession.TabIndex = 12;
            // 
            // lblZp
            // 
            this.lblZp.AutoSize = true;
            this.lblZp.Location = new System.Drawing.Point(28, 147);
            this.lblZp.Name = "lblZp";
            this.lblZp.Size = new System.Drawing.Size(55, 13);
            this.lblZp.TabIndex = 13;
            this.lblZp.Text = "Зарплата";
            // 
            // txtZp
            // 
            this.txtZp.BackColor = System.Drawing.SystemColors.Window;
            this.txtZp.Location = new System.Drawing.Point(141, 144);
            this.txtZp.Name = "txtZp";
            this.txtZp.Size = new System.Drawing.Size(144, 20);
            this.txtZp.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 466);
            this.Controls.Add(this.txtZp);
            this.Controls.Add(this.lblZp);
            this.Controls.Add(this.cmbProfession);
            this.Controls.Add(this.dtmDateOfBirth);
            this.Controls.Add(this.cmbEducation);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblProfession);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblEducation);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnAddToList);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblProfession;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtmDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ComboBox cmbProfession;
        private System.Windows.Forms.Label lblZp;
        private System.Windows.Forms.TextBox txtZp;
        private System.Windows.Forms.ComboBox cmbEducation;
    }
}

