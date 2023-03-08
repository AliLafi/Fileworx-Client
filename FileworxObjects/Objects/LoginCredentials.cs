namespace FileworxObjects.Objects
{
    public class LoginCredentials
    {
        public string userName { get; set; }
        public string password { get; set; }

        public LoginCredentials(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public LoginCredentials() 
        { 
        }
    }
}
