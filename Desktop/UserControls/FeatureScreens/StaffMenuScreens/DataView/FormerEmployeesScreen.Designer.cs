﻿namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    partial class FormerEmployeesScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormerEmployeesScreen));
            this.dataPanel = new System.Windows.Forms.Panel();
            this.pagingLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.surnameFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.specialtyFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.emailFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.formerEmployeesListView = new System.Windows.Forms.ListView();
            this.pagingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagingNumericUpDown)).BeginInit();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dataPanel.Controls.Add(this.pagingLabel);
            this.dataPanel.Controls.Add(this.label4);
            this.dataPanel.Controls.Add(this.surnameFilterRadioButton);
            this.dataPanel.Controls.Add(this.specialtyFilterRadioButton);
            this.dataPanel.Controls.Add(this.emailFilterRadioButton);
            this.dataPanel.Controls.Add(this.filterTextBox);
            this.dataPanel.Controls.Add(this.formerEmployeesListView);
            this.dataPanel.Controls.Add(this.pagingNumericUpDown);
            this.dataPanel.Controls.Add(this.previousPageButton);
            this.dataPanel.Controls.Add(this.nextPageButton);
            this.dataPanel.Location = new System.Drawing.Point(0, 0);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(1156, 622);
            this.dataPanel.TabIndex = 27;
            // 
            // pagingLabel
            // 
            this.pagingLabel.AutoSize = true;
            this.pagingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pagingLabel.ForeColor = System.Drawing.Color.White;
            this.pagingLabel.Location = new System.Drawing.Point(319, 10);
            this.pagingLabel.Name = "pagingLabel";
            this.pagingLabel.Size = new System.Drawing.Size(64, 39);
            this.pagingLabel.TabIndex = 26;
            this.pagingLabel.Text = "0/1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(302, 41);
            this.label4.TabIndex = 18;
            this.label4.Text = "Former employees";
            // 
            // surnameFilterRadioButton
            // 
            this.surnameFilterRadioButton.AutoSize = true;
            this.surnameFilterRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.surnameFilterRadioButton.ForeColor = System.Drawing.Color.White;
            this.surnameFilterRadioButton.Location = new System.Drawing.Point(420, 486);
            this.surnameFilterRadioButton.Name = "surnameFilterRadioButton";
            this.surnameFilterRadioButton.Size = new System.Drawing.Size(176, 43);
            this.surnameFilterRadioButton.TabIndex = 25;
            this.surnameFilterRadioButton.Text = "Surname";
            this.surnameFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // specialtyFilterRadioButton
            // 
            this.specialtyFilterRadioButton.AutoSize = true;
            this.specialtyFilterRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.specialtyFilterRadioButton.ForeColor = System.Drawing.Color.White;
            this.specialtyFilterRadioButton.Location = new System.Drawing.Point(222, 486);
            this.specialtyFilterRadioButton.Name = "specialtyFilterRadioButton";
            this.specialtyFilterRadioButton.Size = new System.Drawing.Size(177, 43);
            this.specialtyFilterRadioButton.TabIndex = 24;
            this.specialtyFilterRadioButton.Text = "Specialty";
            this.specialtyFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // emailFilterRadioButton
            // 
            this.emailFilterRadioButton.AutoSize = true;
            this.emailFilterRadioButton.Checked = true;
            this.emailFilterRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailFilterRadioButton.ForeColor = System.Drawing.Color.White;
            this.emailFilterRadioButton.Location = new System.Drawing.Point(79, 486);
            this.emailFilterRadioButton.Name = "emailFilterRadioButton";
            this.emailFilterRadioButton.Size = new System.Drawing.Size(124, 43);
            this.emailFilterRadioButton.TabIndex = 23;
            this.emailFilterRadioButton.TabStop = true;
            this.emailFilterRadioButton.Text = "Email";
            this.emailFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // filterTextBox
            // 
            this.filterTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filterTextBox.ForeColor = System.Drawing.Color.White;
            this.filterTextBox.Location = new System.Drawing.Point(634, 486);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(445, 45);
            this.filterTextBox.TabIndex = 22;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // formerEmployeesListView
            // 
            this.formerEmployeesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.formerEmployeesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formerEmployeesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.formerEmployeesListView.ForeColor = System.Drawing.Color.White;
            this.formerEmployeesListView.FullRowSelect = true;
            this.formerEmployeesListView.GridLines = true;
            this.formerEmployeesListView.HideSelection = false;
            this.formerEmployeesListView.Location = new System.Drawing.Point(79, 56);
            this.formerEmployeesListView.MultiSelect = false;
            this.formerEmployeesListView.Name = "formerEmployeesListView";
            this.formerEmployeesListView.ShowItemToolTips = true;
            this.formerEmployeesListView.Size = new System.Drawing.Size(1000, 418);
            this.formerEmployeesListView.TabIndex = 18;
            this.formerEmployeesListView.UseCompatibleStateImageBehavior = false;
            this.formerEmployeesListView.View = System.Windows.Forms.View.List;
            // 
            // pagingNumericUpDown
            // 
            this.pagingNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pagingNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pagingNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.pagingNumericUpDown.Location = new System.Drawing.Point(959, 8);
            this.pagingNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pagingNumericUpDown.Name = "pagingNumericUpDown";
            this.pagingNumericUpDown.Size = new System.Drawing.Size(120, 45);
            this.pagingNumericUpDown.TabIndex = 21;
            this.pagingNumericUpDown.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.pagingNumericUpDown.ValueChanged += new System.EventHandler(this.pagingNumericUpDown_ValueChanged);
            // 
            // previousPageButton
            // 
            this.previousPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.previousPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.previousPageButton.ForeColor = System.Drawing.Color.White;
            this.previousPageButton.Image = ((System.Drawing.Image)(resources.GetObject("previousPageButton.Image")));
            this.previousPageButton.Location = new System.Drawing.Point(708, 5);
            this.previousPageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(50, 50);
            this.previousPageButton.TabIndex = 19;
            this.previousPageButton.UseVisualStyleBackColor = false;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nextPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextPageButton.ForeColor = System.Drawing.Color.White;
            this.nextPageButton.Image = ((System.Drawing.Image)(resources.GetObject("nextPageButton.Image")));
            this.nextPageButton.Location = new System.Drawing.Point(764, 4);
            this.nextPageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(50, 50);
            this.nextPageButton.TabIndex = 20;
            this.nextPageButton.UseVisualStyleBackColor = false;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.controlPanel.Controls.Add(this.errorLabel);
            this.controlPanel.Controls.Add(this.deleteButton);
            this.controlPanel.Controls.Add(this.showButton);
            this.controlPanel.Controls.Add(this.label1);
            this.controlPanel.Location = new System.Drawing.Point(0, 628);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1156, 212);
            this.controlPanel.TabIndex = 28;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 53);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(88, 39);
            this.errorLabel.TabIndex = 24;
            this.errorLabel.Text = "error";
            this.errorLabel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteButton.Location = new System.Drawing.Point(615, 100);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(200, 60);
            this.deleteButton.TabIndex = 22;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.showButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showButton.BackgroundImage")));
            this.showButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.showButton.Location = new System.Drawing.Point(335, 100);
            this.showButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(200, 60);
            this.showButton.TabIndex = 21;
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 41);
            this.label1.TabIndex = 19;
            this.label1.Text = "Former employees control";
            // 
            // FormerEmployeesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.controlPanel);
            this.Name = "FormerEmployeesScreen";
            this.Size = new System.Drawing.Size(1156, 840);
            this.Load += new System.EventHandler(this.FormerEmployeesScreen_Load);
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagingNumericUpDown)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Label pagingLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton surnameFilterRadioButton;
        private System.Windows.Forms.RadioButton specialtyFilterRadioButton;
        private System.Windows.Forms.RadioButton emailFilterRadioButton;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ListView formerEmployeesListView;
        private System.Windows.Forms.NumericUpDown pagingNumericUpDown;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label label1;
    }
}
