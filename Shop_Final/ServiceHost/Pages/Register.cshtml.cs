using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class RegisterModel : PageModel
    {
        [TempData]
        public string RegisterMessage { get; set; }

        public RegisterAccount CommandRegisterAccount;

        private readonly IAccountApplication _accountApplication;

        public RegisterModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }
        
        public IActionResult OnPostRegister(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            if (result.IsSuccedded)
            {
                RegisterMessage = result.Message;
                return RedirectToPage("/Account");
            }
            else
            {
                RegisterMessage = result.Message;
                //return RedirectToPage("/Register");
                return Page();
            }
            
        }
    }
}