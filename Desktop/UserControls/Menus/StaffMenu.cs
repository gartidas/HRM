﻿using Desktop.Forms;
using System.Windows.Forms;

namespace Desktop.UserControls.Menus
{
    public partial class StaffMenu : UserControl
    {
        public StaffMenu()
        {
            InitializeComponent();
        }

        private void CandidatesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(14);
        }

        private void LoadScreen(int screenNumber)
        {
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
            {
                if (MainFormStateSingleton.Instance.ScreenHidden)
                    MainFormStateSingleton.Instance.ScreenOpened = screenNumber;

                if (MainFormStateSingleton.Instance.ScreenOpened == screenNumber)
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                else
                {
                    MainFormStateSingleton.Instance.ScreenOpened = screenNumber;
                    MainFormStateSingleton.Instance.ScreensChanging = true;
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                }
            }
        }
    }
}
