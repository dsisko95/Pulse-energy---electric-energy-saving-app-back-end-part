using DataLayer.Models;

namespace BusinessLayer
{
    public interface IUserBusiness
    {
        User GetUserLogin(string username, string password);

        bool GetCheckUser(string username, string secQuestion);

        bool UpdateOwnerPasswordByUsername(User user);

        bool UpdateUserLanguage(User user);

        bool UpdateUserCurrency(User user);
    }
}