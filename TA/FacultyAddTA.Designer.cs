namespace TA
{
    partial class FacultyAddTA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacultyAddTA));
            this.button1 = new System.Windows.Forms.Button();
            this.sub = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(226, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sub
            // 
            this.sub.Location = new System.Drawing.Point(226, 232);
            this.sub.Name = "sub";
            this.sub.Size = new System.Drawing.Size(186, 22);
            this.sub.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label2.Location = new System.Drawing.Point(52, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Subject";
            // 
            // rid
            // 
            this.rid.Location = new System.Drawing.Point(226, 91);
            this.rid.Name = "rid";
            this.rid.Size = new System.Drawing.Size(186, 22);
            this.rid.TabIndex = 20;
            this.rid.TextChanged += new System.EventHandler(this.rid_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label5.Location = new System.Drawing.Point(52, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 29);
            this.label5.TabIndex = 19;
            this.label5.Text = "Role ID";
            // 
            // rname
            // 
            this.rname.Location = new System.Drawing.Point(226, 139);
            this.rname.Name = "rname";
            this.rname.Size = new System.Drawing.Size(186, 22);
            this.rname.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label6.Location = new System.Drawing.Point(52, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 29);
            this.label6.TabIndex = 22;
            this.label6.Text = "Role_Name";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(895, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ta
            // 
            this.ta.Location = new System.Drawing.Point(226, 185);
            this.ta.Name = "ta";
            this.ta.Size = new System.Drawing.Size(186, 22);
            this.ta.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label3.Location = new System.Drawing.Point(52, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 29);
            this.label3.TabIndex = 25;
            this.label3.Text = "TA ID";
            // 
            // FacultyAddTA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.ta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sub);
            this.Controls.Add(this.label2);
            this.Name = "FacultyAddTA";
            this.Text = "FacultyAddTA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox sub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ta;
        private System.Windows.Forms.Label label3;
    }
}