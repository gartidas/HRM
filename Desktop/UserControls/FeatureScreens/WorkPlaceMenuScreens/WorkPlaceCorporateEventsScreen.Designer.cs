namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    partial class WorkPlaceCorporateEventsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPlaceCorporateEventsScreen));
            this.label4 = new System.Windows.Forms.Label();
            this.corporateEventsListView = new System.Windows.Forms.ListView();
            this.employeesListView = new System.Windows.Forms.ListView();
            this.employeesComboBox = new System.Windows.Forms.ComboBox();
            this.removeEmployeeButton = new System.Windows.Forms.Button();
            this.addEmployeeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.eventsControlPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.eventsControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 41);
            this.label4.TabIndex = 17;
            this.label4.Text = "Corporate events";
            // 
            // corporateEventsListView
            // 
            this.corporateEventsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.corporateEventsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.corporateEventsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.corporateEventsListView.ForeColor = System.Drawing.Color.White;
            this.corporateEventsListView.FullRowSelect = true;
            this.corporateEventsListView.GridLines = true;
            this.corporateEventsListView.HideSelection = false;
            this.corporateEventsListView.Location = new System.Drawing.Point(90, 112);
            this.corporateEventsListView.MultiSelect = false;
            this.corporateEventsListView.Name = "corporateEventsListView";
            this.corporateEventsListView.ShowItemToolTips = true;
            this.corporateEventsListView.Size = new System.Drawing.Size(616, 465);
            this.corporateEventsListView.TabIndex = 25;
            this.corporateEventsListView.UseCompatibleStateImageBehavior = false;
            this.corporateEventsListView.View = System.Windows.Forms.View.List;
            this.corporateEventsListView.SelectedIndexChanged += new System.EventHandler(this.corporateEventsListView_SelectedIndexChanged);
            // 
            // employeesListView
            // 
            this.employeesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.employeesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.employeesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeesListView.ForeColor = System.Drawing.Color.White;
            this.employeesListView.FullRowSelect = true;
            this.employeesListView.GridLines = true;
            this.employeesListView.HideSelection = false;
            this.employeesListView.Location = new System.Drawing.Point(712, 112);
            this.employeesListView.MultiSelect = false;
            this.employeesListView.Name = "employeesListView";
            this.employeesListView.ShowItemToolTips = true;
            this.employeesListView.Size = new System.Drawing.Size(346, 465);
            this.employeesListView.TabIndex = 26;
            this.employeesListView.UseCompatibleStateImageBehavior = false;
            this.employeesListView.View = System.Windows.Forms.View.List;
            // 
            // employeesComboBox
            // 
            this.employeesComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.employeesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeesComboBox.ForeColor = System.Drawing.Color.White;
            this.employeesComboBox.FormattingEnabled = true;
            this.employeesComboBox.Location = new System.Drawing.Point(27, 136);
            this.employeesComboBox.Name = "employeesComboBox";
            this.employeesComboBox.Size = new System.Drawing.Size(616, 46);
            this.employeesComboBox.TabIndex = 30;
            // 
            // removeEmployeeButton
            // 
            this.removeEmployeeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.removeEmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeEmployeeButton.ForeColor = System.Drawing.Color.White;
            this.removeEmployeeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeEmployeeButton.Image")));
            this.removeEmployeeButton.Location = new System.Drawing.Point(890, 132);
            this.removeEmployeeButton.Name = "removeEmployeeButton";
            this.removeEmployeeButton.Size = new System.Drawing.Size(50, 50);
            this.removeEmployeeButton.TabIndex = 29;
            this.removeEmployeeButton.UseVisualStyleBackColor = false;
            this.removeEmployeeButton.Click += new System.EventHandler(this.removeEmployeeButton_Click);
            // 
            // addEmployeeButton
            // 
            this.addEmployeeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.addEmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addEmployeeButton.ForeColor = System.Drawing.Color.White;
            this.addEmployeeButton.Image = ((System.Drawing.Image)(resources.GetObject("addEmployeeButton.Image")));
            this.addEmployeeButton.Location = new System.Drawing.Point(890, 64);
            this.addEmployeeButton.Name = "addEmployeeButton";
            this.addEmployeeButton.Size = new System.Drawing.Size(50, 50);
            this.addEmployeeButton.TabIndex = 28;
            this.addEmployeeButton.UseVisualStyleBackColor = false;
            this.addEmployeeButton.Click += new System.EventHandler(this.addEmployeeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 39);
            this.label3.TabIndex = 31;
            this.label3.Text = "Employees:";
            // 
            // eventsControlPanel
            // 
            this.eventsControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.eventsControlPanel.Controls.Add(this.label1);
            this.eventsControlPanel.Controls.Add(this.employeesComboBox);
            this.eventsControlPanel.Controls.Add(this.removeEmployeeButton);
            this.eventsControlPanel.Controls.Add(this.label3);
            this.eventsControlPanel.Controls.Add(this.addEmployeeButton);
            this.eventsControlPanel.Location = new System.Drawing.Point(90, 583);
            this.eventsControlPanel.Name = "eventsControlPanel";
            this.eventsControlPanel.Size = new System.Drawing.Size(968, 223);
            this.eventsControlPanel.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 41);
            this.label1.TabIndex = 32;
            this.label1.Text = "Corporate events control";
            // 
            // WorkPlaceCorporateEventsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.eventsControlPanel);
            this.Controls.Add(this.employeesListView);
            this.Controls.Add(this.corporateEventsListView);
            this.Controls.Add(this.label4);
            this.Name = "WorkPlaceCorporateEventsScreen";
            this.Size = new System.Drawing.Size(1200, 840);
            this.Load += new System.EventHandler(this.WorkPlaceCorporateEventsScreen_Load);
            this.eventsControlPanel.ResumeLayout(false);
            this.eventsControlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView corporateEventsListView;
        private System.Windows.Forms.ListView employeesListView;
        private System.Windows.Forms.ComboBox employeesComboBox;
        private System.Windows.Forms.Button removeEmployeeButton;
        private System.Windows.Forms.Button addEmployeeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel eventsControlPanel;
        private System.Windows.Forms.Label label1;
    }
}
