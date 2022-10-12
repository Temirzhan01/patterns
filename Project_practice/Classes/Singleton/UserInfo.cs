namespace Project_practice.Classes.Singleton
{
    public static class UserInfo
    {
        private static string login;
        private static string password;
        public static string Login
        {
            get { return login; }
            set { login = value; }
        }
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }


    }
}
