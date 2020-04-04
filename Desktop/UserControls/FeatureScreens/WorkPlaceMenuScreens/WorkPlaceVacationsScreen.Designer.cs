namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    partial class WorkPlaceVacationsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPlaceVacationsScreen));
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vacationsCalendar = new Calendar.NET.Calendar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vacationsComboBox = new System.Windows.Forms.ComboBox();
            this.cancelVacationButton = new System.Windows.Forms.Button();
            this.approveVacationButton = new System.Windows.Forms.Button();
            this.employeeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.label4.Size = new System.Drawing.Size(169, 41);
            this.label4.TabIndex = 17;
            this.label4.Text = "Vacations";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.vacationsCalendar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 545);
            this.panel1.TabIndex = 18;
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
            this.vacationsCalendar.Location = new System.Drawing.Point(64, 59);
            this.vacationsCalendar.Name = "vacationsCalendar";
            this.vacationsCalendar.ShowArrowControls = true;
            this.vacationsCalendar.ShowDashedBorderOnDisabledEvents = true;
            this.vacationsCalendar.ShowDateInHeader = true;
            this.vacationsCalendar.ShowDisabledEvents = false;
            this.vacationsCalendar.ShowEventTooltips = true;
            this.vacationsCalendar.ShowTodayButton = true;
            this.vacationsCalendar.Size = new System.Drawing.Size(1037, 471);
            this.vacationsCalendar.TabIndex = 18;
            this.vacationsCalendar.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel2.Controls.Add(this.vacationsComboBox);
            this.panel2.Controls.Add(this.cancelVacationButton);
            this.panel2.Controls.Add(this.approveVacationButton);
            this.panel2.Controls.Add(this.employeeComboBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 551);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 289);
            this.panel2.TabIndex = 19;
            // 
            // vacationsComboBox
            // 
            this.vacationsComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.vacationsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vacationsComboBox.ForeColor = System.Drawing.Color.White;
            this.vacationsComboBox.FormattingEnabled = true;
            this.vacationsComboBox.Location = new System.Drawing.Point(491, 69);
            this.vacationsComboBox.Name = "vacationsComboBox";
            this.vacationsComboBox.Size = new System.Drawing.Size(436, 46);
            this.vacationsComboBox.TabIndex = 27;
            // 
            // cancelVacationButton
            // 
            this.cancelVacationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancelVacationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelVacationButton.ForeColor = System.Drawing.Color.White;
            this.cancelVacationButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelVacationButton.Image")));
            this.cancelVacationButton.Location = new System.Drawing.Point(1051, 133);
            this.cancelVacationButton.Name = "cancelVacationButton";
            this.cancelVacationButton.Size = new System.Drawing.Size(50, 50);
            this.cancelVacationButton.TabIndex = 26;
            this.cancelVacationButton.UseVisualStyleBackColor = false;
            this.cancelVacationButton.Click += new System.EventHandler(this.cancelVacationButton_Click);
            // 
            // approveVacationButton
            // 
            this.approveVacationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.approveVacationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.approveVacationButton.ForeColor = System.Drawing.Color.White;
            this.approveVacationButton.Image = ((System.Drawing.Image)(resources.GetObject("approveVacationButton.Image")));
            this.approveVacationButton.Location = new System.Drawing.Point(1051, 65);
            this.approveVacationButton.Name = "approveVacationButton";
            this.approveVacationButton.Size = new System.Drawing.Size(50, 50);
            this.approveVacationButton.TabIndex = 25;
            this.approveVacationButton.UseVisualStyleBackColor = false;
            this.approveVacationButton.Click += new System.EventHandler(this.approveVacationButton_Click);
            // 
            // employeeComboBox
            // 
            this.employeeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.employeeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeeComboBox.ForeColor = System.Drawing.Color.White;
            this.employeeComboBox.FormattingEnabled = true;
            this.employeeComboBox.Location = new System.Drawing.Point(25, 69);
            this.employeeComboBox.Name = "employeeComboBox";
            this.employeeComboBox.Size = new System.Drawing.Size(354, 46);
            this.employeeComboBox.TabIndex = 19;
            this.employeeComboBox.SelectedIndexChanged += new System.EventHandler(this.employeeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 41);
            this.label1.TabIndex = 18;
            this.label1.Text = "Vacations control";
            // 
            // WorkPlaceVacationsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WorkPlaceVacationsScreen";
            this.Size = new System.Drawing.Size(1200, 840);
            this.Load += new System.EventHandler(this.WorkPlaceVacationsScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Calendar.NET.Calendar vacationsCalendar;
        private System.Windows.Forms.ComboBox employeeComboBox;
        private System.Windows.Forms.Button cancelVacationButton;
        private System.Windows.Forms.Button approveVacationButton;
        private System.Windows.Forms.ComboBox vacationsComboBox;
    }
}
