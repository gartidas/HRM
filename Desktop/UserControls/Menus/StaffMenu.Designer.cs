namespace Desktop.UserControls.Menus
{
    partial class StaffMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.formerEmployeesButton = new System.Windows.Forms.Button();
            this.employeesButton = new System.Windows.Forms.Button();
            this.candidatesButton = new System.Windows.Forms.Button();
            this.corporateEventsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formerEmployeesButton
            // 
            this.formerEmployeesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.formerEmployeesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.formerEmployeesButton.ForeColor = System.Drawing.Color.White;
            this.formerEmployeesButton.Location = new System.Drawing.Point(0, 132);
            this.formerEmployeesButton.Name = "formerEmployeesButton";
            this.formerEmployeesButton.Size = new System.Drawing.Size(198, 60);
            this.formerEmployeesButton.TabIndex = 11;
            this.formerEmployeesButton.Text = "Former employees";
            this.formerEmployeesButton.UseVisualStyleBackColor = false;
            this.formerEmployeesButton.Click += new System.EventHandler(this.formerEmployeesButton_Click);
            // 
            // employeesButton
            // 
            this.employeesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.employeesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeesButton.ForeColor = System.Drawing.Color.White;
            this.employeesButton.Location = new System.Drawing.Point(0, 66);
            this.employeesButton.Name = "employeesButton";
            this.employeesButton.Size = new System.Drawing.Size(198, 60);
            this.employeesButton.TabIndex = 10;
            this.employeesButton.Text = "Employees";
            this.employeesButton.UseVisualStyleBackColor = false;
            this.employeesButton.Click += new System.EventHandler(this.employeesButton_Click);
            // 
            // candidatesButton
            // 
            this.candidatesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.candidatesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.candidatesButton.ForeColor = System.Drawing.Color.White;
            this.candidatesButton.Location = new System.Drawing.Point(0, 0);
            this.candidatesButton.Name = "candidatesButton";
            this.candidatesButton.Size = new System.Drawing.Size(198, 60);
            this.candidatesButton.TabIndex = 9;
            this.candidatesButton.Text = "Candidates";
            this.candidatesButton.UseVisualStyleBackColor = false;
            this.candidatesButton.Click += new System.EventHandler(this.candidatesButton_Click);
            // 
            // corporateEventsButton
            // 
            this.corporateEventsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.corporateEventsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.corporateEventsButton.ForeColor = System.Drawing.Color.White;
            this.corporateEventsButton.Location = new System.Drawing.Point(0, 198);
            this.corporateEventsButton.Name = "corporateEventsButton";
            this.corporateEventsButton.Size = new System.Drawing.Size(198, 60);
            this.corporateEventsButton.TabIndex = 12;
            this.corporateEventsButton.Text = "Corporate events";
            this.corporateEventsButton.UseVisualStyleBackColor = false;
            this.corporateEventsButton.Click += new System.EventHandler(this.corporateEventsButton_Click);
            // 
            // StaffMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.corporateEventsButton);
            this.Controls.Add(this.formerEmployeesButton);
            this.Controls.Add(this.employeesButton);
            this.Controls.Add(this.candidatesButton);
            this.Name = "StaffMenu";
            this.Size = new System.Drawing.Size(200, 824);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button formerEmployeesButton;
        private System.Windows.Forms.Button employeesButton;
        private System.Windows.Forms.Button candidatesButton;
        private System.Windows.Forms.Button corporateEventsButton;
    }
}
