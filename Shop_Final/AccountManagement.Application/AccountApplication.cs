using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Application.Email;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication:IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IEmailService _emailService;
        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository, IEmailService emailService)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
            _emailService = emailService;
        } 

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile || x.Email == command.Email))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var account = new Account(command.Fullname, command.Username, password, command.Mobile, command.RoleId,
                picturePath,command.Email);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(command.Id);

            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository
                .Exists(x => (x.Username == command.Username || x.Mobile == command.Mobile || x.Email== command.Email) && x.Id !=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            
            account.Edit(command.Fullname, command.Username,
                 command.Mobile, command.RoleId, picturePath, command.Email);

            _accountRepository.SaveChanges();
            return operation.Succedded(); 
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMath);
            
            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var permissions = _roleRepository
                .Get(account.RoleId)
                .Permissions
                .Select(x => x.Code)
                .ToList();

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname
                , account.Username, permissions);

            _authHelper.Signin(authViewModel);
            return operation.Succedded();

        }

        public OperationResult ForgetPassword(AccountForgetPassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetByEmail(command.Email);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongEmail);

            bool includeLowercase = true;
            bool includeUppercase = true;
            bool includeNumeric = true;
            int lengthOfPassword = 10;
            string password = PasswordGenerator.GeneratePassword(includeLowercase, includeUppercase, includeNumeric, lengthOfPassword);

            while (!PasswordGenerator.PasswordIsValid(includeLowercase, includeUppercase, includeNumeric, password))
            {
                password = PasswordGenerator.GeneratePassword(includeLowercase, includeUppercase, includeNumeric, lengthOfPassword);
            }
            _emailService.SendEmail("بازیابی رمز عبور", $"کاربر گرامی {account.Fullname}<br/>رمز عبور جدید شما : {password} <br/> با تشکر <br/> شرکت ارتعاش الکترونیک آروج", $"{account.Email}");
            return operation.SuccessResetPass();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public void Logout()
        {
          _authHelper.SignOut();
        }
    }
}
