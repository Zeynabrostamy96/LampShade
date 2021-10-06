using _01_Farmework.Application;

namespace _01_Framework.Application
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void Signin(AuthViewModel account);
        string CurrentAcountRole();
        AuthViewModel CurrentAccountInfo();

    
    }
}
