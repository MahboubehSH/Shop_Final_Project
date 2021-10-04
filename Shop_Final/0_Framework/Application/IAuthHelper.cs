namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        bool IsAuthenticated();
        void Signin(AuthViewModel account);
        void SignOut();
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();

    }
}