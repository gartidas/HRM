namespace Desktop.UserControls.FeatureScreens.PersonalMenuScreens
{
    partial class CorporateEventsScreen
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
            this.label4 = new System.Windows.Forms.Label();
            this.corporateEventsCalendar = new Calendar.NET.Calendar();
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
            this.label4.TabIndex = 14;
            this.label4.Text = "Corporate events";
            // 
            // corporateEventsCalendar
            // 
            this.corporateEventsCalendar.AllowEditingEvents = true;
            this.corporateEventsCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.corporateEventsCalendar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.corporateEventsCalendar.CalendarDate = new System.DateTime(2020, 3, 23, 15, 6, 2, 867);
            this.corporateEventsCalendar.CalendarView = Calendar.NET.CalendarViews.Month;
            this.corporateEventsCalendar.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.corporateEventsCalendar.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.corporateEventsCalendar.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.corporateEventsCalendar.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.corporateEventsCalendar.DimDisabledEvents = true;
            this.corporateEventsCalendar.HighlightCurrentDay = true;
            this.corporateEventsCalendar.LoadPresetHolidays = true;
            this.corporateEventsCalendar.Location = new System.Drawing.Point(45, 78);
            this.corporateEventsCalendar.Name = "corporateEventsCalendar";
            this.corporateEventsCalendar.ShowArrowControls = true;
            this.corporateEventsCalendar.ShowDashedBorderOnDisabledEvents = true;
            this.corporateEventsCalendar.ShowDateInHeader = true;
            this.corporateEventsCalendar.ShowDisabledEvents = false;
            this.corporateEventsCalendar.ShowEventTooltips = true;
            this.corporateEventsCalendar.ShowTodayButton = true;
            this.corporateEventsCalendar.Size = new System.Drawing.Size(1061, 694);
            this.corporateEventsCalendar.TabIndex = 15;
            this.corporateEventsCalendar.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // CorporateEventsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.corporateEventsCalendar);
            this.Controls.Add(this.label4);
            this.Name = "CorporateEventsScreen";
            this.Size = new System.Drawing.Size(1156, 840);
            this.Load += new System.EventHandler(this.CorporateEventsScreen_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Calendar.NET.Calendar corporateEventsCalendar;
    }
}
