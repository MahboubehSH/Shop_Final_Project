using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class AccountForgetPassword
    {
        [Display(Name = "پست الکترونبک")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نیست")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد")]
        public string Email { get; set; }
    }
}
