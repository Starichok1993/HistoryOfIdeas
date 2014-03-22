using System;
using System.Linq;
using System.Web.Helpers;
using HistoryOfIdeas.BLL.Interface.Services;
using HistoryOfIdeas.DAL.Entity;
using HistoryOfIdeas.DAL.Interface.Repositories;

namespace HistoryOfIdeas.BLL.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryable<User> Users
        {
            get { return _userRepository.All; }
        }

        public void CreateUser(User user)
        {
            _userRepository.InsertOrUpdate(user);
            _userRepository.Save();
        }

        public void EditUser(User user)
        {
            _userRepository.InsertOrUpdate(user);
            _userRepository.Save();
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
            _userRepository.Save();
        }


        public User GetUserById(int userId)
        {
            return _userRepository.Find(userId);
        }


        public bool IsUserValid(string email, string password)
        {
            bool isValid = false;

            try
            {
                User user = GetUserByEmail(email);

                //check if user exist in database
                if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                {
                    isValid = true;
                }
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }

        public User GetUserByEmail(string email)
        {
            User user;
            try
            {
                 user =
                    _userRepository.All.FirstOrDefault(u => u.Email == email);
            }
            catch (Exception e)
            {
                //var list = _userRepository.All.ToList();
                Console.WriteLine(e.Message);
                user = null;
            }
            return user;
        }
    }
}
