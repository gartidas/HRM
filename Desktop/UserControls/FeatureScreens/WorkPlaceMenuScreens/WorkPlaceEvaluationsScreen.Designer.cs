namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    partial class WorkPlaceEvaluationsScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.evaluationsListView = new System.Windows.Forms.ListView();
            this.employeeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.legendPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(196, 41);
            this.label1.TabIndex = 19;
            this.label1.Text = "Evaluations";
            // 
            // evaluationsListView
            // 
            this.evaluationsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.evaluationsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.evaluationsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.evaluationsListView.ForeColor = System.Drawing.Color.White;
            this.evaluationsListView.GridLines = true;
            this.evaluationsListView.HideSelection = false;
            this.evaluationsListView.Location = new System.Drawing.Point(180, 147);
            this.evaluationsListView.Name = "evaluationsListView";
            this.evaluationsListView.ShowItemToolTips = true;
            this.evaluationsListView.Size = new System.Drawing.Size(781, 465);
            this.evaluationsListView.TabIndex = 20;
            this.evaluationsListView.UseCompatibleStateImageBehavior = false;
            this.evaluationsListView.View = System.Windows.Forms.View.List;
            // 
            // employeeComboBox
            // 
            this.employeeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.employeeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeeComboBox.ForeColor = System.Drawing.Color.White;
            this.employeeComboBox.FormattingEnabled = true;
            this.employeeComboBox.Location = new System.Drawing.Point(180, 95);
            this.employeeComboBox.Name = "employeeComboBox";
            this.employeeComboBox.Size = new System.Drawing.Size(781, 46);
            this.employeeComboBox.TabIndex = 21;
            this.employeeComboBox.SelectedIndexChanged += new System.EventHandler(this.employeeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(173, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 39);
            this.label2.TabIndex = 29;
            this.label2.Text = "Employee:";
            // 
            // legendPanel
            // 
            this.legendPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.legendPanel.Controls.Add(this.label5);
            this.legendPanel.Controls.Add(this.label6);
            this.legendPanel.Controls.Add(this.label7);
            this.legendPanel.Controls.Add(this.label8);
            this.legendPanel.Controls.Add(this.label3);
            this.legendPanel.Controls.Add(this.label4);
            this.legendPanel.Controls.Add(this.label9);
            this.legendPanel.Location = new System.Drawing.Point(180, 618);
            this.legendPanel.Name = "legendPanel";
            this.legendPanel.Size = new System.Drawing.Size(781, 184);
            this.legendPanel.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(448, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 39);
            this.label5.TabIndex = 24;
            this.label5.Text = "High";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(448, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 39);
            this.label6.TabIndex = 25;
            this.label6.Text = "Medium";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.SeaGreen;
            this.label7.Location = new System.Drawing.Point(448, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 39);
            this.label7.TabIndex = 26;
            this.label7.Text = "Low";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 41);
            this.label8.TabIndex = 23;
            this.label8.Text = "Legend";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(193, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 39);
            this.label3.TabIndex = 17;
            this.label3.Text = "High";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(193, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 39);
            this.label4.TabIndex = 18;
            this.label4.Text = "Medium";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.IndianRed;
            this.label9.Location = new System.Drawing.Point(193, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 39);
            this.label9.TabIndex = 19;
            this.label9.Text = "Low";
            // 
            // WorkPlaceEvaluationsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.legendPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.employeeComboBox);
            this.Controls.Add(this.evaluationsListView);
            this.Controls.Add(this.label1);
            this.Name = "WorkPlaceEvaluationsScreen";
            this.Size = new System.Drawing.Size(1200, 840);
            this.Load += new System.EventHandler(this.WorkPlaceEvaluationsScreen_Load);
            this.legendPanel.ResumeLayout(false);
            this.legendPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView evaluationsListView;
        private System.Windows.Forms.ComboBox employeeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel legendPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
    }
}
