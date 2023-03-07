using System.ComponentModel.DataAnnotations;

namespace FileworxWebApp.Models
{
    public class LoginModel
    {
        
        [Required(ErrorMessage ="Login Name is Required")]
        public string userName { get; set; }

        [Required]
        public string Password { get; set; }
    
        public LoginModel() { }
        public LoginModel(string userName, string password)
        {
            this.userName= userName;
            this.Password= password;
        }
    
    }
}
