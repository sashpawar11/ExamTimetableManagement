
namespace ExamTimetableApp
{
    partial class Navigation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.yearBox = new System.Windows.Forms.ComboBox();
            this.departmentBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.opentable = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.createbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.yearBox);
            this.panel1.Controls.Add(this.departmentBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 219);
            this.panel1.TabIndex = 40;
            // 
            // yearBox
            // 
            this.yearBox.BackColor = System.Drawing.Color.Gainsboro;
            this.yearBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearBox.Font = new System.Drawing.Font("Arial", 9.5F);
            this.yearBox.ForeColor = System.Drawing.Color.Indigo;
            this.yearBox.FormattingEnabled = true;
            this.yearBox.Items.AddRange(new object[] {
            "FE",
            "SE",
            "TE",
            "BE"});
            this.yearBox.Location = new System.Drawing.Point(263, 122);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(296, 24);
            this.yearBox.TabIndex = 43;
            // 
            // departmentBox
            // 
            this.departmentBox.BackColor = System.Drawing.Color.Gainsboro;
            this.departmentBox.DropDownHeight = 120;
            this.departmentBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentBox.DropDownWidth = 296;
            this.departmentBox.Font = new System.Drawing.Font("Arial", 9.5F);
            this.departmentBox.ForeColor = System.Drawing.Color.Indigo;
            this.departmentBox.IntegralHeight = false;
            this.departmentBox.Items.AddRange(new object[] {
            "Civil Engineering",
            "Computer Engineering",
            "Electronics & Telecommunication Engineering",
            "Mechanical Engineering",
            "Science & Humanities"});
            this.departmentBox.Location = new System.Drawing.Point(263, 66);
            this.departmentBox.Name = "departmentBox";
            this.departmentBox.Size = new System.Drawing.Size(296, 24);
            this.departmentBox.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(99, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "Department :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(173, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 41;
            this.label2.Text = "Year :";
            // 
            // opentable
            // 
            this.opentable.Location = new System.Drawing.Point(315, 237);
            this.opentable.Name = "opentable";
            this.opentable.Size = new System.Drawing.Size(242, 37);
            this.opentable.TabIndex = 46;
            this.opentable.Text = "Open Timetable";
            this.opentable.UseVisualStyleBackColor = true;
            this.opentable.Click += new System.EventHandler(this.opentable_Click_1);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(12, 236);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(136, 39);
            this.updatebtn.TabIndex = 45;
            this.updatebtn.Text = "Delete Timetable";
            this.updatebtn.UseVisualStyleBackColor = true;
            // 
            // createbtn
            // 
            this.createbtn.Location = new System.Drawing.Point(164, 236);
            this.createbtn.Name = "createbtn";
            this.createbtn.Size = new System.Drawing.Size(145, 38);
            this.createbtn.TabIndex = 44;
            this.createbtn.Text = "Create Timetable";
            this.createbtn.UseVisualStyleBackColor = true;
            this.createbtn.Click += new System.EventHandler(this.createbtn_Click);
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 312);
            this.Controls.Add(this.opentable);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.createbtn);
            this.MaximizeBox = false;
            this.Name = "Navigation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navigation";
            this.Load += new System.EventHandler(this.Navigation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox yearBox;
        private System.Windows.Forms.ComboBox departmentBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button opentable;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button createbtn;
    }
}