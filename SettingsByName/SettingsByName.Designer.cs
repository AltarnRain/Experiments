namespace SettingsByName
{
    partial class SettingsByName
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
            this.button1 = new System.Windows.Forms.Button();
            this.PersonAge = new System.Windows.Forms.TextBox();
            this.PersonName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PersonAlive = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PersonAge
            // 
            this.PersonAge.Location = new System.Drawing.Point(3, 29);
            this.PersonAge.Name = "PersonAge";
            this.PersonAge.Size = new System.Drawing.Size(103, 20);
            this.PersonAge.TabIndex = 2;
            // 
            // PersonName
            // 
            this.PersonName.Location = new System.Drawing.Point(3, 3);
            this.PersonName.Name = "PersonName";
            this.PersonName.Size = new System.Drawing.Size(103, 20);
            this.PersonName.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PersonAlive);
            this.panel1.Controls.Add(this.PersonName);
            this.panel1.Controls.Add(this.PersonAge);
            this.panel1.Location = new System.Drawing.Point(45, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 108);
            this.panel1.TabIndex = 4;
            // 
            // PersonAlive
            // 
            this.PersonAlive.AutoSize = true;
            this.PersonAlive.Location = new System.Drawing.Point(2, 57);
            this.PersonAlive.Name = "PersonAlive";
            this.PersonAlive.Size = new System.Drawing.Size(80, 17);
            this.PersonAlive.TabIndex = 4;
            this.PersonAlive.Text = "checkBox1";
            this.PersonAlive.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SettingsByName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "SettingsByName";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PersonAge;
        private System.Windows.Forms.TextBox PersonName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox PersonAlive;
        private System.Windows.Forms.Button button2;
    }
}

