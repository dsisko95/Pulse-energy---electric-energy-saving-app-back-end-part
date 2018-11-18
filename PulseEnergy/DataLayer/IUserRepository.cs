using DataLayer.Models;

namespace DataLayer
{
    public interface IUserRepository
    {
        User GetUserLogin(string username, string password);

        User GetCheckUser(string username, string secQuestion);

        int UpdateUserPassword(User user);

        int UpdateUserLanguage(User user);

        int UpdateUserCurrency(User user);
    }
}