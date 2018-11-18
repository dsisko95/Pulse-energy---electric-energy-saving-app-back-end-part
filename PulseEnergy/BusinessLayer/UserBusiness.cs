using DataLayer;
using DataLayer.Models;

namespace BusinessLayer
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetUserLogin(string username, string password)
        {
            User user = this.userRepository.GetUserLogin(username, password);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public bool GetCheckUser(string username, string secQuestion)
        {
            User user = this.userRepository.GetCheckUser(username, secQuestion);
            if (user.Username != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateOwnerPasswordByUsername(User user)
        {
            bool result = false;
            if (this.userRepository.UpdateUserPassword(user) > 0)
            {
                result = true;
            }
            return result;
        }

        public bool UpdateUserLanguage(User user)
        {
            bool result = false;
            if (this.userRepository.UpdateUserLanguage(user) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdateUserCurrency(User user)
        {
            bool result = false;
            if (this.userRepository.UpdateUserCurrency(user) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}