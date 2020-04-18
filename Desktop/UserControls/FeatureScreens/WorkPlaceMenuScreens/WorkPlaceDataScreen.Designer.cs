namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    partial class WorkPlaceDataScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPlaceDataScreen));
            this.label4 = new System.Windows.Forms.Label();
            this.workPlaceEmployeesListView = new System.Windows.Forms.ListView();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.pagingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.workPlaceDataPanel = new System.Windows.Forms.Panel();
            this.locationLabel = new System.Windows.Forms.Label();
            this.labelLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pagingLabel = new System.Windows.Forms.Label();
            this.surnameFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.specialtyFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.emailFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pagingNumericUpDown)).BeginInit();
            this.workPlaceDataPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 41);
            this.label4.TabIndex = 16;
            this.label4.Text = "Employees";
            // 
            // workPlaceEmployeesListView
            // 
            this.workPlaceEmployeesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.workPlaceEmployeesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workPlaceEmployeesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workPlaceEmployeesListView.ForeColor = System.Drawing.Color.White;
            this.workPlaceEmployeesListView.FullRowSelect = true;
            this.workPlaceEmployeesListView.GridLines = true;
            this.workPlaceEmployeesListView.HideSelection = false;
            this.workPlaceEmployeesListView.Location = new System.Drawing.Point(79, 56);
            this.workPlaceEmployeesListView.Name = "workPlaceEmployeesListView";
            this.workPlaceEmployeesListView.ShowItemToolTips = true;
            this.workPlaceEmployeesListView.Size = new System.Drawing.Size(1000, 418);
            this.workPlaceEmployeesListView.TabIndex = 18;
            this.workPlaceEmployeesListView.UseCompatibleStateImageBehavior = false;
            this.workPlaceEmployeesListView.View = System.Windows.Forms.View.List;
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
            // workPlaceDataPanel
            // 
            this.workPlaceDataPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.workPlaceDataPanel.Controls.Add(this.locationLabel);
            this.workPlaceDataPanel.Controls.Add(this.labelLabel);
            this.workPlaceDataPanel.Controls.Add(this.label3);
            this.workPlaceDataPanel.Controls.Add(this.label2);
            this.workPlaceDataPanel.Controls.Add(this.label1);
            this.workPlaceDataPanel.Location = new System.Drawing.Point(0, 0);
            this.workPlaceDataPanel.Name = "workPlaceDataPanel";
            this.workPlaceDataPanel.Size = new System.Drawing.Size(1156, 255);
            this.workPlaceDataPanel.TabIndex = 22;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.locationLabel.ForeColor = System.Drawing.Color.White;
            this.locationLabel.Location = new System.Drawing.Point(180, 171);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(135, 39);
            this.locationLabel.TabIndex = 21;
            this.locationLabel.Text = "location";
            this.locationLabel.Visible = false;
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLabel.ForeColor = System.Drawing.Color.White;
            this.labelLabel.Location = new System.Drawing.Point(135, 101);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(90, 39);
            this.labelLabel.TabIndex = 20;
            this.labelLabel.Text = "label";
            this.labelLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 41);
            this.label3.TabIndex = 19;
            this.label3.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 41);
            this.label2.TabIndex = 18;
            this.label2.Text = "Label:";
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
            this.label1.Size = new System.Drawing.Size(180, 41);
            this.label1.TabIndex = 17;
            this.label1.Text = "Workplace";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.pagingLabel);
            this.panel1.Controls.Add(this.surnameFilterRadioButton);
            this.panel1.Controls.Add(this.specialtyFilterRadioButton);
            this.panel1.Controls.Add(this.emailFilterRadioButton);
            this.panel1.Controls.Add(this.filterTextBox);
            this.panel1.Controls.Add(this.workPlaceEmployeesListView);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pagingNumericUpDown);
            this.panel1.Controls.Add(this.previousPageButton);
            this.panel1.Controls.Add(this.nextPageButton);
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1156, 579);
            this.panel1.TabIndex = 23;
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
            // WorkPlaceDataScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.workPlaceDataPanel);
            this.Controls.Add(this.panel1);
            this.Name = "WorkPlaceDataScreen";
            this.Size = new System.Drawing.Size(1156, 840);
            this.Load += new System.EventHandler(this.WorkPlaceDataScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pagingNumericUpDown)).EndInit();
            this.workPlaceDataPanel.ResumeLayout(false);
            this.workPlaceDataPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView workPlaceEmployeesListView;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.NumericUpDown pagingNumericUpDown;
        private System.Windows.Forms.Panel workPlaceDataPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.RadioButton surnameFilterRadioButton;
        private System.Windows.Forms.RadioButton specialtyFilterRadioButton;
        private System.Windows.Forms.RadioButton emailFilterRadioButton;
        private System.Windows.Forms.Label pagingLabel;
    }
}
