
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.adminpanel = new System.Windows.Forms.Panel();
            this.opentable = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.createbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.adminpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.yearBox);
            this.panel1.Controls.Add(this.departmentBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.adminpanel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 385);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // yearBox
            // 
            this.yearBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearBox.FormattingEnabled = true;
            this.yearBox.Items.AddRange(new object[] {
            "FE",
            "SE",
            "TE",
            "BE"});
            this.yearBox.Location = new System.Drawing.Point(252, 128);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(296, 24);
            this.yearBox.TabIndex = 13;
            // 
            // departmentBox
            // 
            this.departmentBox.DropDownHeight = 120;
            this.departmentBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentBox.IntegralHeight = false;
            this.departmentBox.Items.AddRange(new object[] {
            "Computer Engineering",
            "Civil Engineering",
            "Mechanical Engineering",
            "Electronics & Telecommunication Engineering",
            "Science & Humanities"});
            this.departmentBox.Location = new System.Drawing.Point(252, 74);
            this.departmentBox.Name = "departmentBox";
            this.departmentBox.Size = new System.Drawing.Size(296, 24);
            this.departmentBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Year :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Department :";
            // 
            // adminpanel
            // 
            this.adminpanel.Controls.Add(this.opentable);
            this.adminpanel.Controls.Add(this.updatebtn);
            this.adminpanel.Controls.Add(this.createbtn);
            this.adminpanel.Location = new System.Drawing.Point(252, 171);
            this.adminpanel.Name = "adminpanel";
            this.adminpanel.Size = new System.Drawing.Size(296, 151);
            this.adminpanel.TabIndex = 17;
            // 
            // opentable
            // 
            this.opentable.Location = new System.Drawing.Point(0, 9);
            this.opentable.Name = "opentable";
            this.opentable.Size = new System.Drawing.Size(296, 37);
            this.opentable.TabIndex = 16;
            this.opentable.Text = "Open Timetable";
            this.opentable.UseVisualStyleBackColor = true;
            this.opentable.Click += new System.EventHandler(this.opentable_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(0, 95);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(296, 37);
            this.updatebtn.TabIndex = 15;
            this.updatebtn.Text = "Delete Timetable";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // createbtn
            // 
            this.createbtn.Location = new System.Drawing.Point(0, 52);
            this.createbtn.Name = "createbtn";
            this.createbtn.Size = new System.Drawing.Size(296, 37);
            this.createbtn.TabIndex = 14;
            this.createbtn.Text = "Create Timetable";
            this.createbtn.UseVisualStyleBackColor = true;
            this.createbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(654, 409);
            this.Controls.Add(this.panel1);
            this.Name = "Navigation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navigation";
            this.Load += new System.EventHandler(this.Navigation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.adminpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button opentable;
        private System.Windows.Forms.ComboBox yearBox;
        private System.Windows.Forms.ComboBox departmentBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel adminpanel;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button createbtn;
    }
}