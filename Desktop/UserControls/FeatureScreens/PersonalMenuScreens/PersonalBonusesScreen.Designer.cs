namespace Desktop.UserControls.FeatureScreens.PersonalMenuScreens
{
    partial class PersonalBonusesScreen
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
            this.bonusesListView = new System.Windows.Forms.ListView();
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
            this.label4.Size = new System.Drawing.Size(152, 41);
            this.label4.TabIndex = 15;
            this.label4.Text = "Bonuses";
            // 
            // bonusesListView
            // 
            this.bonusesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bonusesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bonusesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bonusesListView.ForeColor = System.Drawing.Color.White;
            this.bonusesListView.GridLines = true;
            this.bonusesListView.HideSelection = false;
            this.bonusesListView.Location = new System.Drawing.Point(79, 87);
            this.bonusesListView.Name = "bonusesListView";
            this.bonusesListView.ShowItemToolTips = true;
            this.bonusesListView.Size = new System.Drawing.Size(1000, 500);
            this.bonusesListView.TabIndex = 17;
            this.bonusesListView.UseCompatibleStateImageBehavior = false;
            this.bonusesListView.View = System.Windows.Forms.View.List;
            // 
            // PersonalBonusesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.bonusesListView);
            this.Controls.Add(this.label4);
            this.Name = "PersonalBonusesScreen";
            this.Size = new System.Drawing.Size(1156, 840);
            this.Load += new System.EventHandler(this.BonusesScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView bonusesListView;
    }
}
