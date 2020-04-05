namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    partial class WorkPlaceSpecialtiesScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPlaceSpecialtiesScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.legendPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.removeSpecialtyButton = new System.Windows.Forms.Button();
            this.addSpecialtyButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.specialtiesListView = new System.Windows.Forms.ListView();
            this.legendPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 41);
            this.label1.TabIndex = 18;
            this.label1.Text = "Specialties";
            // 
            // legendPanel
            // 
            this.legendPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.legendPanel.Controls.Add(this.label3);
            this.legendPanel.Controls.Add(this.label2);
            this.legendPanel.Controls.Add(this.countTextBox);
            this.legendPanel.Controls.Add(this.removeSpecialtyButton);
            this.legendPanel.Controls.Add(this.addSpecialtyButton);
            this.legendPanel.Controls.Add(this.nameTextBox);
            this.legendPanel.Controls.Add(this.label8);
            this.legendPanel.Location = new System.Drawing.Point(183, 568);
            this.legendPanel.Name = "legendPanel";
            this.legendPanel.Size = new System.Drawing.Size(781, 225);
            this.legendPanel.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 39);
            this.label3.TabIndex = 29;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(426, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 39);
            this.label2.TabIndex = 28;
            this.label2.Text = "Count:";
            // 
            // countTextBox
            // 
            this.countTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.countTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.countTextBox.ForeColor = System.Drawing.Color.White;
            this.countTextBox.Location = new System.Drawing.Point(433, 112);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(138, 45);
            this.countTextBox.TabIndex = 27;
            // 
            // removeSpecialtyButton
            // 
            this.removeSpecialtyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.removeSpecialtyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeSpecialtyButton.ForeColor = System.Drawing.Color.White;
            this.removeSpecialtyButton.Image = ((System.Drawing.Image)(resources.GetObject("removeSpecialtyButton.Image")));
            this.removeSpecialtyButton.Location = new System.Drawing.Point(693, 109);
            this.removeSpecialtyButton.Name = "removeSpecialtyButton";
            this.removeSpecialtyButton.Size = new System.Drawing.Size(50, 50);
            this.removeSpecialtyButton.TabIndex = 26;
            this.removeSpecialtyButton.UseVisualStyleBackColor = false;
            this.removeSpecialtyButton.Click += new System.EventHandler(this.removeSpecialtyButton_Click);
            // 
            // addSpecialtyButton
            // 
            this.addSpecialtyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.addSpecialtyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addSpecialtyButton.ForeColor = System.Drawing.Color.White;
            this.addSpecialtyButton.Image = ((System.Drawing.Image)(resources.GetObject("addSpecialtyButton.Image")));
            this.addSpecialtyButton.Location = new System.Drawing.Point(637, 109);
            this.addSpecialtyButton.Name = "addSpecialtyButton";
            this.addSpecialtyButton.Size = new System.Drawing.Size(50, 50);
            this.addSpecialtyButton.TabIndex = 25;
            this.addSpecialtyButton.UseVisualStyleBackColor = false;
            this.addSpecialtyButton.Click += new System.EventHandler(this.addSpecialtyButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameTextBox.ForeColor = System.Drawing.Color.White;
            this.nameTextBox.Location = new System.Drawing.Point(43, 112);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(302, 45);
            this.nameTextBox.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(296, 41);
            this.label8.TabIndex = 23;
            this.label8.Text = "Specialties control";
            // 
            // specialtiesListView
            // 
            this.specialtiesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.specialtiesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.specialtiesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.specialtiesListView.ForeColor = System.Drawing.Color.White;
            this.specialtiesListView.FullRowSelect = true;
            this.specialtiesListView.GridLines = true;
            this.specialtiesListView.HideSelection = false;
            this.specialtiesListView.Location = new System.Drawing.Point(183, 97);
            this.specialtiesListView.MultiSelect = false;
            this.specialtiesListView.Name = "specialtiesListView";
            this.specialtiesListView.ShowItemToolTips = true;
            this.specialtiesListView.Size = new System.Drawing.Size(781, 465);
            this.specialtiesListView.TabIndex = 24;
            this.specialtiesListView.UseCompatibleStateImageBehavior = false;
            this.specialtiesListView.View = System.Windows.Forms.View.List;
            // 
            // WorkPlaceSpecialtiesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.legendPanel);
            this.Controls.Add(this.specialtiesListView);
            this.Controls.Add(this.label1);
            this.Name = "WorkPlaceSpecialtiesScreen";
            this.Size = new System.Drawing.Size(1200, 840);
            this.Load += new System.EventHandler(this.WorkPlaceSpecialtiesScreen_Load);
            this.legendPanel.ResumeLayout(false);
            this.legendPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel legendPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView specialtiesListView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Button removeSpecialtyButton;
        private System.Windows.Forms.Button addSpecialtyButton;
    }
}
