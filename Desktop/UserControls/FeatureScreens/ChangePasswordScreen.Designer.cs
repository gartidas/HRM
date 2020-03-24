namespace Desktop.UserControls.FeatureScreens
{
    partial class ChangePasswordScreen
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
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.showCheckBox = new System.Windows.Forms.CheckBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.confirmPasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(313, 409);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.PasswordChar = '*';
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(418, 45);
            this.confirmPasswordTextBox.TabIndex = 1;
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newPasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.newPasswordTextBox.Location = new System.Drawing.Point(313, 287);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.PasswordChar = '*';
            this.newPasswordTextBox.Size = new System.Drawing.Size(418, 45);
            this.newPasswordTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(313, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "New password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(313, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirm password:";
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.changePasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changePasswordButton.ForeColor = System.Drawing.Color.White;
            this.changePasswordButton.Location = new System.Drawing.Point(762, 514);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(187, 76);
            this.changePasswordButton.TabIndex = 5;
            this.changePasswordButton.Text = "Change password";
            this.changePasswordButton.UseVisualStyleBackColor = false;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_ClickAsync);
            // 
            // showCheckBox
            // 
            this.showCheckBox.AutoSize = true;
            this.showCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showCheckBox.ForeColor = System.Drawing.Color.White;
            this.showCheckBox.Location = new System.Drawing.Point(762, 384);
            this.showCheckBox.Name = "showCheckBox";
            this.showCheckBox.Size = new System.Drawing.Size(149, 24);
            this.showCheckBox.TabIndex = 6;
            this.showCheckBox.Text = "Show password";
            this.showCheckBox.UseVisualStyleBackColor = true;
            this.showCheckBox.CheckedChanged += new System.EventHandler(this.showCheckBox_CheckedChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(18, 677);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(88, 39);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "error";
            this.errorLabel.Visible = false;
            this.errorLabel.TextChanged += new System.EventHandler(this.errorLabel_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(313, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "Current password:";
            // 
            // currentPasswordTextBox
            // 
            this.currentPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currentPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentPasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.currentPasswordTextBox.Location = new System.Drawing.Point(313, 172);
            this.currentPasswordTextBox.Name = "currentPasswordTextBox";
            this.currentPasswordTextBox.PasswordChar = '*';
            this.currentPasswordTextBox.Size = new System.Drawing.Size(418, 45);
            this.currentPasswordTextBox.TabIndex = 8;
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
            this.label4.Size = new System.Drawing.Size(294, 41);
            this.label4.TabIndex = 13;
            this.label4.Text = "Change password";
            // 
            // ChangePasswordScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentPasswordTextBox);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.showCheckBox);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Name = "ChangePasswordScreen";
            this.Size = new System.Drawing.Size(1200, 840);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.CheckBox showCheckBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox currentPasswordTextBox;
        private System.Windows.Forms.Label label4;
    }
}
