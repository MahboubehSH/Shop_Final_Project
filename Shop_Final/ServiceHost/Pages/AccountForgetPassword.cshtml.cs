using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountManagement.Application.Contracts.Account;

namespace ServiceHost.Pages
{
    public class AccountForgetPasswordModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public AccountForgetPassword ForgetPassword { get; set; }

        [TempData] 
        public string ForgetPassMessage { get; set; }

        private readonly IAccountApplication _accountApplication;

        public AccountForgetPasswordModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostForgetPass(AccountForgetPassword command)
        {
            var result = _accountApplication.ForgetPassword(command);
            if (result.IsSuccedded)
            {
                ForgetPassMessage = result.Message;
                return Page();
            }
            ForgetPassMessage = result.Message;
            return Page();
        }
    }
}