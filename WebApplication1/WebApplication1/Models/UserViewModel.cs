using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserViewModel
    {
		[Required]
		[MaxLength(25)]
		public string? UserName { get; set; } = "";
        [Required]
        [MinLength(8)]
        public string? Password { get; set; } = "";
		[Required]
		[MinLength(8)]
		public string? ConfirmPassword { get; set; } = "";
		[Required]
		[MinLength(8)]
		[MaxLength(80)]
		public string? Adress { get; set; } = "";
        public UserViewModel()
        {

        }
        public UserViewModel(string userName, string password, string confirmPassword, string adress)
        {
            UserName = userName;
            Password = password;
            ConfirmPassword = confirmPassword;
            Adress = adress;
        }


    }
}