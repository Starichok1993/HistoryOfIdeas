using System;
using System.Collections.Generic;
using System.Linq;
using HistoryOfIdeas.DAL.Entity;

namespace HistoryOfIdeas.BLL.Interface.Services
{
    public interface IUserService
    {
        IQueryable<User> Users { get; }
        void CreateUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);

        bool IsUserValid(string email, string password);

        User GetUserByEmail(string email);
    }
}
