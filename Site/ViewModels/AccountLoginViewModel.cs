using System.ComponentModel.DataAnnotations;

namespace Site.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Kepping log...")]
        public bool KeepLog { get; set; }
    }
}