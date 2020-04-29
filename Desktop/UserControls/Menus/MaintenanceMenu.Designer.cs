namespace Desktop.UserControls.Menus
{
    partial class MaintenanceMenu
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
            this.workplacesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workplacesButton
            // 
            this.workplacesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.workplacesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workplacesButton.ForeColor = System.Drawing.Color.White;
            this.workplacesButton.Location = new System.Drawing.Point(0, -1);
            this.workplacesButton.Name = "workplacesButton";
            this.workplacesButton.Size = new System.Drawing.Size(198, 60);
            this.workplacesButton.TabIndex = 9;
            this.workplacesButton.Text = "Workplaces";
            this.workplacesButton.UseVisualStyleBackColor = false;
            this.workplacesButton.Click += new System.EventHandler(this.workplacesButton_Click);
            // 
            // MaintenanceMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.workplacesButton);
            this.Name = "MaintenanceMenu";
            this.Size = new System.Drawing.Size(200, 824);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button workplacesButton;
    }
}
