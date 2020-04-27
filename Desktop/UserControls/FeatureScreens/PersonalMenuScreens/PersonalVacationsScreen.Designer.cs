namespace Desktop.UserControls.FeatureScreens.PersonalMenuScreens
{
    partial class PersonalVacationsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalVacationsScreen));
            this.planVacationPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.vacationDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cancelVacationButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.planVacationButton = new System.Windows.Forms.Button();
            this.planVacationTextBox = new System.Windows.Forms.TextBox();
            this.vacationsPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.vacationsCalendar = new Calendar.NET.Calendar();
            this.vacationsCountLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.planVacationPanel.SuspendLayout();
            this.vacationsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // planVacationPanel
            // 
            this.planVacationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.planVacationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planVacationPanel.Controls.Add(this.vacationsCountLabel);
            this.planVacationPanel.Controls.Add(this.label5);
            this.planVacationPanel.Controls.Add(this.label3);
            this.planVacationPanel.Controls.Add(this.vacationDateTimePicker);
            this.planVacationPanel.Controls.Add(this.cancelVacationButton);
            this.planVacationPanel.Controls.Add(this.errorLabel);
            this.planVacationPanel.Controls.Add(this.label2);
            this.planVacationPanel.Controls.Add(this.label1);
            this.planVacationPanel.Controls.Add(this.planVacationButton);
            this.planVacationPanel.Controls.Add(this.planVacationTextBox);
            this.planVacationPanel.Location = new System.Drawing.Point(0, 559);
            this.planVacationPanel.Name = "planVacationPanel";
            this.planVacationPanel.Size = new System.Drawing.Size(1156, 281);
            this.planVacationPanel.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(583, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 41);
            this.label3.TabIndex = 24;
            this.label3.Text = "Date:";
            // 
            // vacationDateTimePicker
            // 
            this.vacationDateTimePicker.CalendarForeColor = System.Drawing.Color.White;
            this.vacationDateTimePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.vacationDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.DimGray;
            this.vacationDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.White;
            this.vacationDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vacationDateTimePicker.Location = new System.Drawing.Point(583, 159);
            this.vacationDateTimePicker.Name = "vacationDateTimePicker";
            this.vacationDateTimePicker.Size = new System.Drawing.Size(399, 36);
            this.vacationDateTimePicker.TabIndex = 23;
            // 
            // cancelVacationButton
            // 
            this.cancelVacationButton.BackColor = System.Drawing.Color.White;
            this.cancelVacationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelVacationButton.ForeColor = System.Drawing.Color.White;
            this.cancelVacationButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelVacationButton.Image")));
            this.cancelVacationButton.Location = new System.Drawing.Point(1046, 173);
            this.cancelVacationButton.Name = "cancelVacationButton";
            this.cancelVacationButton.Size = new System.Drawing.Size(50, 50);
            this.cancelVacationButton.TabIndex = 22;
            this.cancelVacationButton.UseVisualStyleBackColor = false;
            this.cancelVacationButton.Click += new System.EventHandler(this.cancelVacationButton_ClickAsync);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(346, 65);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(88, 39);
            this.errorLabel.TabIndex = 21;
            this.errorLabel.Text = "error";
            this.errorLabel.Visible = false;
            this.errorLabel.TextChanged += new System.EventHandler(this.errorLabel_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 41);
            this.label2.TabIndex = 20;
            this.label2.Text = "Reason:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 41);
            this.label1.TabIndex = 13;
            this.label1.Text = "Vacations planner";
            // 
            // planVacationButton
            // 
            this.planVacationButton.BackColor = System.Drawing.Color.White;
            this.planVacationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.planVacationButton.ForeColor = System.Drawing.Color.White;
            this.planVacationButton.Image = ((System.Drawing.Image)(resources.GetObject("planVacationButton.Image")));
            this.planVacationButton.Location = new System.Drawing.Point(1046, 117);
            this.planVacationButton.Name = "planVacationButton";
            this.planVacationButton.Size = new System.Drawing.Size(50, 50);
            this.planVacationButton.TabIndex = 2;
            this.planVacationButton.UseVisualStyleBackColor = false;
            this.planVacationButton.Click += new System.EventHandler(this.planVacationButton_ClickAsync);
            // 
            // planVacationTextBox
            // 
            this.planVacationTextBox.BackColor = System.Drawing.Color.White;
            this.planVacationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.planVacationTextBox.ForeColor = System.Drawing.Color.Black;
            this.planVacationTextBox.Location = new System.Drawing.Point(3, 117);
            this.planVacationTextBox.Multiline = true;
            this.planVacationTextBox.Name = "planVacationTextBox";
            this.planVacationTextBox.Size = new System.Drawing.Size(515, 115);
            this.planVacationTextBox.TabIndex = 1;
            // 
            // vacationsPanel
            // 
            this.vacationsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.vacationsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vacationsPanel.Controls.Add(this.label4);
            this.vacationsPanel.Controls.Add(this.vacationsCalendar);
            this.vacationsPanel.Location = new System.Drawing.Point(0, 0);
            this.vacationsPanel.Name = "vacationsPanel";
            this.vacationsPanel.Size = new System.Drawing.Size(1156, 553);
            this.vacationsPanel.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 41);
            this.label4.TabIndex = 14;
            this.label4.Text = "Vacations";
            // 
            // vacationsCalendar
            // 
            this.vacationsCalendar.AllowEditingEvents = true;
            this.vacationsCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.vacationsCalendar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vacationsCalendar.CalendarDate = new System.DateTime(2020, 3, 23, 15, 6, 2, 867);
            this.vacationsCalendar.CalendarView = Calendar.NET.CalendarViews.Month;
            this.vacationsCalendar.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.vacationsCalendar.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.vacationsCalendar.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.vacationsCalendar.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.vacationsCalendar.DimDisabledEvents = true;
            this.vacationsCalendar.HighlightCurrentDay = true;
            this.vacationsCalendar.LoadPresetHolidays = true;
            this.vacationsCalendar.Location = new System.Drawing.Point(59, 68);
            this.vacationsCalendar.Name = "vacationsCalendar";
            this.vacationsCalendar.ShowArrowControls = true;
            this.vacationsCalendar.ShowDashedBorderOnDisabledEvents = true;
            this.vacationsCalendar.ShowDateInHeader = true;
            this.vacationsCalendar.ShowDisabledEvents = false;
            this.vacationsCalendar.ShowEventTooltips = true;
            this.vacationsCalendar.ShowTodayButton = true;
            this.vacationsCalendar.Size = new System.Drawing.Size(1037, 471);
            this.vacationsCalendar.TabIndex = 13;
            this.vacationsCalendar.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // vacationsCountLabel
            // 
            this.vacationsCountLabel.AutoSize = true;
            this.vacationsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vacationsCountLabel.ForeColor = System.Drawing.Color.White;
            this.vacationsCountLabel.Location = new System.Drawing.Point(840, -1);
            this.vacationsCountLabel.Name = "vacationsCountLabel";
            this.vacationsCountLabel.Size = new System.Drawing.Size(161, 39);
            this.vacationsCountLabel.TabIndex = 33;
            this.vacationsCountLabel.Text = "vacations";
            this.vacationsCountLabel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(583, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 41);
            this.label5.TabIndex = 32;
            this.label5.Text = "Free vacations:";
            // 
            // PersonalVacationsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.vacationsPanel);
            this.Controls.Add(this.planVacationPanel);
            this.Name = "PersonalVacationsScreen";
            this.Size = new System.Drawing.Size(1156, 840);
            this.Load += new System.EventHandler(this.VacationsScreen_LoadAsync);
            this.planVacationPanel.ResumeLayout(false);
            this.planVacationPanel.PerformLayout();
            this.vacationsPanel.ResumeLayout(false);
            this.vacationsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel planVacationPanel;
        private System.Windows.Forms.TextBox planVacationTextBox;
        private System.Windows.Forms.Button planVacationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel vacationsPanel;
        private System.Windows.Forms.Label label4;
        private Calendar.NET.Calendar vacationsCalendar;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.DateTimePicker vacationDateTimePicker;
        private System.Windows.Forms.Button cancelVacationButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label vacationsCountLabel;
        private System.Windows.Forms.Label label5;
    }
}
