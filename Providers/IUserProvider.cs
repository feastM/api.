using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopWebApi.Models;

namespace WorkshopWebApi.Providers
{
    public interface IUserProvider
    {
       // void CreateUsers();
        IEnumerable<User> GetAll();
        IEnumerable<Role> GetAllRoles();
        void AddUser(User user);
        void DeleteUser(int id);
        void UpdateUserAdmin(int id, User user);
        void UpdateUser(int id, User user);
        void UpdateRole(int id, Role role);
        void AddRole(int id, Role role);
        void DeleteRole(int id1, int id2);
        IEnumerable<User> SearchByInterval(DateTime startDate, DateTime endDate);
        IEnumerable<User> SearchByRole(string role);
    }
}
