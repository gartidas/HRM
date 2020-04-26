namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens
{
    partial class EquipmentScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.labelTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.equipmentListView = new System.Windows.Forms.ListView();
            this.doneButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 41);
            this.label1.TabIndex = 22;
            this.label1.Text = "Equipment";
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlPanel.Controls.Add(this.label4);
            this.controlPanel.Controls.Add(this.statusComboBox);
            this.controlPanel.Controls.Add(this.label3);
            this.controlPanel.Controls.Add(this.removeButton);
            this.controlPanel.Controls.Add(this.addButton);
            this.controlPanel.Controls.Add(this.labelTextBox);
            this.controlPanel.Controls.Add(this.label2);
            this.controlPanel.Location = new System.Drawing.Point(220, 538);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(700, 255);
            this.controlPanel.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(385, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 39);
            this.label4.TabIndex = 35;
            this.label4.Text = "Status:";
            // 
            // statusComboBox
            // 
            this.statusComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.statusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusComboBox.ForeColor = System.Drawing.Color.White;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(392, 44);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(285, 46);
            this.statusComboBox.TabIndex = 34;
            this.statusComboBox.SelectedIndexChanged += new System.EventHandler(this.statusComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 39);
            this.label3.TabIndex = 33;
            this.label3.Text = "Label:";
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeButton.ForeColor = System.Drawing.Color.White;
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.Location = new System.Drawing.Point(627, 157);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(50, 50);
            this.removeButton.TabIndex = 32;
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Location = new System.Drawing.Point(562, 157);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(50, 50);
            this.addButton.TabIndex = 31;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // labelTextBox
            // 
            this.labelTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.labelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTextBox.ForeColor = System.Drawing.Color.White;
            this.labelTextBox.Location = new System.Drawing.Point(35, 162);
            this.labelTextBox.Name = "labelTextBox";
            this.labelTextBox.Size = new System.Drawing.Size(355, 45);
            this.labelTextBox.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 41);
            this.label2.TabIndex = 19;
            this.label2.Text = "Equipment control";
            // 
            // equipmentListView
            // 
            this.equipmentListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.equipmentListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.equipmentListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.equipmentListView.ForeColor = System.Drawing.Color.White;
            this.equipmentListView.FullRowSelect = true;
            this.equipmentListView.GridLines = true;
            this.equipmentListView.HideSelection = false;
            this.equipmentListView.Location = new System.Drawing.Point(220, 101);
            this.equipmentListView.MultiSelect = false;
            this.equipmentListView.Name = "equipmentListView";
            this.equipmentListView.ShowItemToolTips = true;
            this.equipmentListView.Size = new System.Drawing.Size(700, 418);
            this.equipmentListView.TabIndex = 29;
            this.equipmentListView.UseCompatibleStateImageBehavior = false;
            this.equipmentListView.View = System.Windows.Forms.View.List;
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.doneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.doneButton.ForeColor = System.Drawing.Color.White;
            this.doneButton.Location = new System.Drawing.Point(936, 724);
            this.doneButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(200, 60);
            this.doneButton.TabIndex = 33;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(213, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(88, 39);
            this.errorLabel.TabIndex = 30;
            this.errorLabel.Text = "error";
            this.errorLabel.Visible = false;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailLabel.ForeColor = System.Drawing.Color.White;
            this.emailLabel.Location = new System.Drawing.Point(213, 59);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(99, 39);
            this.emailLabel.TabIndex = 32;
            this.emailLabel.Text = "email";
            this.emailLabel.Visible = false;
            // 
            // EquipmentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.equipmentListView);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.label1);
            this.Name = "EquipmentScreen";
            this.Size = new System.Drawing.Size(1156, 840);
            this.Load += new System.EventHandler(this.EquipmentScreen_Load);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView equipmentListView;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox labelTextBox;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label4;
    }
}
