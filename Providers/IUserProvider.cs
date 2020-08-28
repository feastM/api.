using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopWebApi.Models;

namespace WorkshopWebApi.Providers
{
    public interface IUserProvider
    {
        IEnumerable<User> GetAll();
        void AddUser(User user);
        void DeleteUser(int id);
        void UpdateUser(int id, User user);
        void UpdateRole(int id, User user);
        void AddRole(int id, Role role);
        void DeleteRole(int id1, int id2);
    }
}
