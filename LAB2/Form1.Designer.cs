namespace LAB2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckBoxFullName = new System.Windows.Forms.CheckBox();
            this.CheckBoxFaculty = new System.Windows.Forms.CheckBox();
            this.CheckBoxDepartment = new System.Windows.Forms.CheckBox();
            this.CheckBoxEducation = new System.Windows.Forms.CheckBox();
            this.CheckBoxUniversity = new System.Windows.Forms.CheckBox();
            this.CheckBoxEducationPeriod = new System.Windows.Forms.CheckBox();
            this.comboBoxFullName = new System.Windows.Forms.ComboBox();
            this.comboBoxFaculty = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.comboBoxEducation = new System.Windows.Forms.ComboBox();
            this.comboBoxUniversity = new System.Windows.Forms.ComboBox();
            this.comboBoxEducationPeriod = new System.Windows.Forms.ComboBox();
            this.radioButtonDOM = new System.Windows.Forms.RadioButton();
            this.radioButtonSAX = new System.Windows.Forms.RadioButton();
            this.radioButtonLINQtoXML = new System.Windows.Forms.RadioButton();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonTransformation = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CheckBoxFullName
            // 
            this.CheckBoxFullName.AutoSize = true;
            this.CheckBoxFullName.Location = new System.Drawing.Point(12, 30);
            this.CheckBoxFullName.Name = "CheckBoxFullName";
            this.CheckBoxFullName.Size = new System.Drawing.Size(106, 24);
            this.CheckBoxFullName.TabIndex = 0;
            this.CheckBoxFullName.Text = "Повне ім\'я";
            this.CheckBoxFullName.UseVisualStyleBackColor = true;
            // 
            // CheckBoxFaculty
            // 
            this.CheckBoxFaculty.AutoSize = true;
            this.CheckBoxFaculty.Location = new System.Drawing.Point(12, 73);
            this.CheckBoxFaculty.Name = "CheckBoxFaculty";
            this.CheckBoxFaculty.Size = new System.Drawing.Size(100, 24);
            this.CheckBoxFaculty.TabIndex = 1;
            this.CheckBoxFaculty.Text = "Факультет";
            this.CheckBoxFaculty.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDepartment
            // 
            this.CheckBoxDepartment.AutoSize = true;
            this.CheckBoxDepartment.Location = new System.Drawing.Point(12, 117);
            this.CheckBoxDepartment.Name = "CheckBoxDepartment";
            this.CheckBoxDepartment.Size = new System.Drawing.Size(91, 24);
            this.CheckBoxDepartment.TabIndex = 2;
            this.CheckBoxDepartment.Text = "Кафедра";
            this.CheckBoxDepartment.UseVisualStyleBackColor = true;
            // 
            // CheckBoxEducation
            // 
            this.CheckBoxEducation.AutoSize = true;
            this.CheckBoxEducation.Location = new System.Drawing.Point(12, 161);
            this.CheckBoxEducation.Name = "CheckBoxEducation";
            this.CheckBoxEducation.Size = new System.Drawing.Size(104, 24);
            this.CheckBoxEducation.TabIndex = 3;
            this.CheckBoxEducation.Text = "Тип освіти";
            this.CheckBoxEducation.UseVisualStyleBackColor = true;
            // 
            // CheckBoxUniversity
            // 
            this.CheckBoxUniversity.AutoSize = true;
            this.CheckBoxUniversity.Location = new System.Drawing.Point(12, 207);
            this.CheckBoxUniversity.Name = "CheckBoxUniversity";
            this.CheckBoxUniversity.Size = new System.Drawing.Size(114, 24);
            this.CheckBoxUniversity.TabIndex = 4;
            this.CheckBoxUniversity.Text = "Університет";
            this.CheckBoxUniversity.UseVisualStyleBackColor = true;
            // 
            // CheckBoxEducationPeriod
            // 
            this.CheckBoxEducationPeriod.AutoSize = true;
            this.CheckBoxEducationPeriod.Location = new System.Drawing.Point(12, 253);
            this.CheckBoxEducationPeriod.Name = "CheckBoxEducationPeriod";
            this.CheckBoxEducationPeriod.Size = new System.Drawing.Size(127, 24);
            this.CheckBoxEducationPeriod.TabIndex = 5;
            this.CheckBoxEducationPeriod.Text = "Період освіти";
            this.CheckBoxEducationPeriod.UseVisualStyleBackColor = true;
            // 
            // comboBoxFullName
            // 
            this.comboBoxFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFullName.FormattingEnabled = true;
            this.comboBoxFullName.Location = new System.Drawing.Point(151, 30);
            this.comboBoxFullName.Name = "comboBoxFullName";
            this.comboBoxFullName.Size = new System.Drawing.Size(367, 28);
            this.comboBoxFullName.TabIndex = 6;
            // 
            // comboBoxFaculty
            // 
            this.comboBoxFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFaculty.FormattingEnabled = true;
            this.comboBoxFaculty.Location = new System.Drawing.Point(151, 73);
            this.comboBoxFaculty.Name = "comboBoxFaculty";
            this.comboBoxFaculty.Size = new System.Drawing.Size(367, 28);
            this.comboBoxFaculty.TabIndex = 7;
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(151, 117);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(367, 28);
            this.comboBoxDepartment.TabIndex = 8;
            // 
            // comboBoxEducation
            // 
            this.comboBoxEducation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEducation.FormattingEnabled = true;
            this.comboBoxEducation.Location = new System.Drawing.Point(151, 161);
            this.comboBoxEducation.Name = "comboBoxEducation";
            this.comboBoxEducation.Size = new System.Drawing.Size(367, 28);
            this.comboBoxEducation.TabIndex = 9;
            // 
            // comboBoxUniversity
            // 
            this.comboBoxUniversity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUniversity.FormattingEnabled = true;
            this.comboBoxUniversity.Location = new System.Drawing.Point(151, 207);
            this.comboBoxUniversity.Name = "comboBoxUniversity";
            this.comboBoxUniversity.Size = new System.Drawing.Size(367, 28);
            this.comboBoxUniversity.TabIndex = 10;
            // 
            // comboBoxEducationPeriod
            // 
            this.comboBoxEducationPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEducationPeriod.FormattingEnabled = true;
            this.comboBoxEducationPeriod.Location = new System.Drawing.Point(151, 249);
            this.comboBoxEducationPeriod.Name = "comboBoxEducationPeriod";
            this.comboBoxEducationPeriod.Size = new System.Drawing.Size(367, 28);
            this.comboBoxEducationPeriod.TabIndex = 11;
            // 
            // radioButtonDOM
            // 
            this.radioButtonDOM.AutoSize = true;
            this.radioButtonDOM.Location = new System.Drawing.Point(12, 335);
            this.radioButtonDOM.Name = "radioButtonDOM";
            this.radioButtonDOM.Size = new System.Drawing.Size(65, 24);
            this.radioButtonDOM.TabIndex = 12;
            this.radioButtonDOM.TabStop = true;
            this.radioButtonDOM.Text = "DOM";
            this.radioButtonDOM.UseVisualStyleBackColor = true;
            // 
            // radioButtonSAX
            // 
            this.radioButtonSAX.AutoSize = true;
            this.radioButtonSAX.Location = new System.Drawing.Point(12, 365);
            this.radioButtonSAX.Name = "radioButtonSAX";
            this.radioButtonSAX.Size = new System.Drawing.Size(57, 24);
            this.radioButtonSAX.TabIndex = 13;
            this.radioButtonSAX.TabStop = true;
            this.radioButtonSAX.Text = "SAX";
            this.radioButtonSAX.UseVisualStyleBackColor = true;
            // 
            // radioButtonLINQtoXML
            // 
            this.radioButtonLINQtoXML.AutoSize = true;
            this.radioButtonLINQtoXML.Location = new System.Drawing.Point(12, 395);
            this.radioButtonLINQtoXML.Name = "radioButtonLINQtoXML";
            this.radioButtonLINQtoXML.Size = new System.Drawing.Size(114, 24);
            this.radioButtonLINQtoXML.TabIndex = 14;
            this.radioButtonLINQtoXML.TabStop = true;
            this.radioButtonLINQtoXML.Text = "LINQ to XML";
            this.radioButtonLINQtoXML.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(160, 351);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(144, 53);
            this.buttonSearch.TabIndex = 15;
            this.buttonSearch.Text = "Пошук";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonTransformation
            // 
            this.buttonTransformation.Location = new System.Drawing.Point(70, 439);
            this.buttonTransformation.Name = "buttonTransformation";
            this.buttonTransformation.Size = new System.Drawing.Size(234, 59);
            this.buttonTransformation.TabIndex = 16;
            this.buttonTransformation.Text = "Трансформація у HTML";
            this.buttonTransformation.UseVisualStyleBackColor = true;
            this.buttonTransformation.Click += new System.EventHandler(this.buttonTransformation_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(70, 554);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(234, 54);
            this.buttonClear.TabIndex = 17;
            this.buttonClear.Text = "Очистити";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(540, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(581, 594);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 634);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonTransformation);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.radioButtonLINQtoXML);
            this.Controls.Add(this.radioButtonSAX);
            this.Controls.Add(this.radioButtonDOM);
            this.Controls.Add(this.comboBoxEducationPeriod);
            this.Controls.Add(this.comboBoxUniversity);
            this.Controls.Add(this.comboBoxEducation);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.comboBoxFaculty);
            this.Controls.Add(this.comboBoxFullName);
            this.Controls.Add(this.CheckBoxEducationPeriod);
            this.Controls.Add(this.CheckBoxUniversity);
            this.Controls.Add(this.CheckBoxEducation);
            this.Controls.Add(this.CheckBoxDepartment);
            this.Controls.Add(this.CheckBoxFaculty);
            this.Controls.Add(this.CheckBoxFullName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxFullName;
        private System.Windows.Forms.CheckBox CheckBoxFaculty;
        private System.Windows.Forms.CheckBox CheckBoxDepartment;
        private System.Windows.Forms.CheckBox CheckBoxEducation;
        private System.Windows.Forms.CheckBox CheckBoxUniversity;
        private System.Windows.Forms.CheckBox CheckBoxEducationPeriod;
        private System.Windows.Forms.ComboBox comboBoxFullName;
        private System.Windows.Forms.ComboBox comboBoxFaculty;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.ComboBox comboBoxEducation;
        private System.Windows.Forms.ComboBox comboBoxUniversity;
        private System.Windows.Forms.ComboBox comboBoxEducationPeriod;
        private System.Windows.Forms.RadioButton radioButtonDOM;
        private System.Windows.Forms.RadioButton radioButtonSAX;
        private System.Windows.Forms.RadioButton radioButtonLINQtoXML;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonTransformation;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

