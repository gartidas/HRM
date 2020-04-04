namespace Desktop.UserControls.Menus
{
    partial class WorkPlaceMenu
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
            this.workPlaceCorporateEventsButton = new System.Windows.Forms.Button();
            this.workPlaceVacationsButton = new System.Windows.Forms.Button();
            this.workPlaceDataButton = new System.Windows.Forms.Button();
            this.workPlaceSpecialtiesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workPlaceCorporateEventsButton
            // 
            this.workPlaceCorporateEventsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.workPlaceCorporateEventsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workPlaceCorporateEventsButton.ForeColor = System.Drawing.Color.White;
            this.workPlaceCorporateEventsButton.Location = new System.Drawing.Point(0, 132);
            this.workPlaceCorporateEventsButton.Name = "workPlaceCorporateEventsButton";
            this.workPlaceCorporateEventsButton.Size = new System.Drawing.Size(197, 60);
            this.workPlaceCorporateEventsButton.TabIndex = 7;
            this.workPlaceCorporateEventsButton.Text = "Corporate events";
            this.workPlaceCorporateEventsButton.UseVisualStyleBackColor = false;
            this.workPlaceCorporateEventsButton.Click += new System.EventHandler(this.workPlaceCorporateEventsButton_Click);
            // 
            // workPlaceVacationsButton
            // 
            this.workPlaceVacationsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.workPlaceVacationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workPlaceVacationsButton.ForeColor = System.Drawing.Color.White;
            this.workPlaceVacationsButton.Location = new System.Drawing.Point(0, 66);
            this.workPlaceVacationsButton.Name = "workPlaceVacationsButton";
            this.workPlaceVacationsButton.Size = new System.Drawing.Size(197, 60);
            this.workPlaceVacationsButton.TabIndex = 6;
            this.workPlaceVacationsButton.Text = "Vacations";
            this.workPlaceVacationsButton.UseVisualStyleBackColor = false;
            this.workPlaceVacationsButton.Click += new System.EventHandler(this.workPlaceVacationsButton_Click);
            // 
            // workPlaceDataButton
            // 
            this.workPlaceDataButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.workPlaceDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workPlaceDataButton.ForeColor = System.Drawing.Color.White;
            this.workPlaceDataButton.Location = new System.Drawing.Point(0, 0);
            this.workPlaceDataButton.Name = "workPlaceDataButton";
            this.workPlaceDataButton.Size = new System.Drawing.Size(197, 60);
            this.workPlaceDataButton.TabIndex = 5;
            this.workPlaceDataButton.Text = "Workplace";
            this.workPlaceDataButton.UseVisualStyleBackColor = false;
            this.workPlaceDataButton.Click += new System.EventHandler(this.workPlaceDataButton_Click);
            // 
            // workPlaceSpecialtiesButton
            // 
            this.workPlaceSpecialtiesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.workPlaceSpecialtiesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workPlaceSpecialtiesButton.ForeColor = System.Drawing.Color.White;
            this.workPlaceSpecialtiesButton.Location = new System.Drawing.Point(0, 198);
            this.workPlaceSpecialtiesButton.Name = "workPlaceSpecialtiesButton";
            this.workPlaceSpecialtiesButton.Size = new System.Drawing.Size(197, 60);
            this.workPlaceSpecialtiesButton.TabIndex = 8;
            this.workPlaceSpecialtiesButton.Text = "Specialties";
            this.workPlaceSpecialtiesButton.UseVisualStyleBackColor = false;
            this.workPlaceSpecialtiesButton.Click += new System.EventHandler(this.workPlaceSpecialtiesButton_Click);
            // 
            // WorkPlaceMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.workPlaceSpecialtiesButton);
            this.Controls.Add(this.workPlaceCorporateEventsButton);
            this.Controls.Add(this.workPlaceVacationsButton);
            this.Controls.Add(this.workPlaceDataButton);
            this.Name = "WorkPlaceMenu";
            this.Size = new System.Drawing.Size(198, 838);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button workPlaceCorporateEventsButton;
        private System.Windows.Forms.Button workPlaceVacationsButton;
        private System.Windows.Forms.Button workPlaceDataButton;
        private System.Windows.Forms.Button workPlaceSpecialtiesButton;
    }
}
