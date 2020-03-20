﻿namespace Desktop.Models
{
    class CurrentUser
    {
        private CurrentUser() { }
        private static CurrentUser _currentUser = new CurrentUser();

        public static CurrentUser User
        {
            get
            {
                if (_currentUser is null)
                    return new CurrentUser();
                return _currentUser;
            }
        }

        public string Token { get; set; }
        public string Email { get; set; }
        public Role? Role { get; set; }

        public void ClearUser()
        {
            _currentUser.Token = "";
            _currentUser.Email = "";
            _currentUser.Role = null;
        }
    }
}
