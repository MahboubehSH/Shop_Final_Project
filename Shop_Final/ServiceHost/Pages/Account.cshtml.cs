using _0_Framework.Application;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }
        
        //public OperationResult Result;
        //public string LoginMessage => (string)TempData[nameof(LoginMessage)];

        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
            //Result = new OperationResult();
        }

        public IActionResult OnGet()
        {
            return Page();
            //LoginMessage = (string)TempData["LoginMessage"];
        }

        public IActionResult OnPostLogin(Login command)
        {
          var result = _accountApplication.Login(command);
            if (result.IsSuccedded)
                return RedirectToPage("/Index");

            LoginMessage = result.Message;
            //LoginMessage = ".نام کاربری یا رمز عبور اشتباه است";
            //TempData["LoginMessage"] = result.Message;
            //TempData.Keep("LoginMessage");
            //return RedirectToPage("/Account") ;
            return Page();
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetGoToRegister()
        {
            return RedirectToPage("/Register");
        }
    }
}