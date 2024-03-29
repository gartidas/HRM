﻿using Desktop.Models;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.Menus
{
    public partial class PersonalMenu : UserControl
    {
        private ToolTip _toolTip = new ToolTip();

        public PersonalMenu(string email, string role)
        {
            InitializeComponent();
            emailLabel.Text = email;
            roleLabel.Text = role;
            _toolTip.SetToolTip(personalDataButton, "Personal data");
            _toolTip.SetToolTip(changePasswordButton, "Change password");
            _toolTip.SetToolTip(vacationsButton, "Vacations");
            _toolTip.SetToolTip(corporateEventsButton, "Corporate Events");
            _toolTip.SetToolTip(evaluationsButton, "Evaluations");
            _toolTip.SetToolTip(bonusesButton, "Bonuses");
            _toolTip.SetToolTip(equipmentButton, "Equipment");

            if (CurrentUser.User.Role == Role.SysAdmin)
            {
                personalDataButton.Enabled = false;
                vacationsButton.Enabled = false;
                evaluationsButton.Enabled = false;
                bonusesButton.Enabled = false;
                equipmentButton.Enabled = false;
            }

            if (CurrentUser.User.Role != Role.Employee)
                corporateEventsButton.Enabled = false;
        }

        private void personalDataButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.PersonalDataScreen);
        }

        private void changePasswordButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.PersonalChangePasswordScreen);
        }

        private void vacationsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.PersonalVacationsScreen);
        }

        private void corporateEventsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.PersonalCorporateEventsScreen);
        }

        private void evaluationsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.PersonalEvaluationsScreen);
        }

        private void bonusesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.PersonalBonusesScreen);
        }

        private void equipmentButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.PersonalEquipmentScreen);
        }
    }
}
