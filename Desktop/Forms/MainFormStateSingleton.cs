﻿using Desktop.UserControls.FeatureScreens;
using Desktop.UserControls.Menus;
using System;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public class MainFormStateSingleton
    {
        private static MainFormStateSingleton _instance;

        public static MainFormStateSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainFormStateSingleton();
                return _instance;
            }
        }

        #region ScreenState
        public Timer ScreenTimer { get; set; }
        public bool ScreensChanging { get; set; }
        public bool ScreenHidden { get; set; }
        public bool ScreenMoving { get; set; }
        public int ScreenOpened { get; set; }
        public int ScreenWidth { get; set; }
        public Panel ScreenPanel { get; set; }
        public PersonalDataScreen PersonalDataScreen { get; set; }
        public ChangePasswordScreen ChangePasswordScreen { get; set; }
        #endregion

        #region MenuState
        public Timer MenuTimer { get; set; }
        public bool MenusChanging { get; set; }
        public bool MenuHidden { get; set; }
        public bool MenuMoving { get; set; }
        public int MenuOpened { get; set; }
        public int MenuWidth { get; set; }
        public bool MenuClosing { get; set; }
        public Panel MenuPanel { get; set; }
        public PersonalMenu PersonalMenu { get; set; }
        public WorkPlaceMenu WorkPlaceMenu { get; set; }
        public StaffMenu StaffMenu { get; set; }
        #endregion

        public MainFormStateSingleton()
        {
            ScreenTimer = new Timer();
            MenuTimer = new Timer();
            MenuTimer.Interval = 30;
            ScreenTimer.Interval = 10;
            MenuTimer.Tick += new EventHandler(menuTimer_Tick);
            ScreenTimer.Tick += new EventHandler(screenTimer_Tick);
            ScreensChanging = false;
            ScreenHidden = true;
            ScreenMoving = false;
            MenusChanging = false;
            MenuHidden = true;
            MenuMoving = false;
            MenuClosing = false;
        }

        private void menuTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            MenuMoving = true;

            if (MenuHidden)
            {
                switch (MenuOpened)
                {
                    case 1:
                        MenuPanel.Controls.Add(PersonalMenu);
                        break;
                    case 2:
                        MenuPanel.Controls.Add(WorkPlaceMenu);
                        break;
                    case 3:
                        MenuPanel.Controls.Add(StaffMenu);
                        break;
                    default:
                        break;
                }

                if (MenuPanel.Width >= MenuWidth)
                {
                    MenuTimer.Stop();
                    MenuHidden = false;
                    MenuMoving = false;
                    return;
                }

                MenuPanel.Width += 10;
            }
            else
            {
                if (MenuPanel.Width <= 0)
                {
                    MenuTimer.Stop();
                    MenuHidden = true;
                    MenuMoving = false;
                    MenuPanel.Controls.Clear();

                    if (MenusChanging)
                    {
                        MenusChanging = false;
                        MenuTimer.Start();
                    }
                    return;
                }

                MenuPanel.Width -= 10;
            }
        }

        private void screenTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            ScreenMoving = true;

            if (ScreenHidden)
            {
                switch (ScreenOpened)
                {
                    case 1:
                        ScreenPanel.Controls.Add(PersonalDataScreen);
                        break;
                    case 2:
                        ScreenPanel.Controls.Add(ChangePasswordScreen);
                        break;
                    case 3:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    case 4:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    case 5:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    case 6:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    case 7:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    default:
                        break;
                }
                ScreenPanel.Width += 10;

                if (ScreenPanel.Width >= ScreenWidth)
                {
                    ScreenTimer.Stop();
                    ScreensChanging = false;
                    ScreenHidden = false;
                    ScreenMoving = false;
                    return;
                }
            }
            else
            {
                ScreenPanel.Width -= 10;

                if (ScreenPanel.Width <= 0)
                {
                    ScreenTimer.Stop();
                    ScreenHidden = true;
                    ScreenMoving = false;
                    ScreenPanel.Controls.Clear();

                    if (ScreensChanging)
                    {
                        ScreenTimer.Start();
                    }
                    if (MenuClosing)
                    {
                        MenuClosing = false;
                        MenuTimer.Start();
                    }
                    return;
                }
            }
        }
    }
}
