using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WorkshopWebApi.Models;

namespace WorkshopWebApi.Providers
{
    public class UserProvider : IUserProvider
    {
        List<User> Users;
        

       

        public UserProvider()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Id = 1, Name = "Alex",
                    BirthDate = new DateTime(1997, 11, 28),
                    Role = new Role()
                    {
                        Id = 1,
                        UserType = "Admin"
                    }

                },
                new User()
                {
                    Id = 2,Name = "Alexandru",
                    BirthDate = new DateTime(1990,11,28),
                    Role = new Role()
                    {
                        Id = 1,
                        UserType = "User"
                    }

                }

            };
            

        }
        public IEnumerable<User> GetAll()
        {

            return Users;
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void UpdateUserAdmin(int id,User user)
        {
            var userToBeUpdate = Users.First(user => user.Id == id);
            userToBeUpdate.Name = user.Name;
            userToBeUpdate.BirthDate = user.BirthDate;
            userToBeUpdate.Role = user.Role;
        }

        public void UpdateUser(int id, User user)
        {
            var userToBeUpdate = Users.First(user => user.Id == id);
            userToBeUpdate.Name = user.Name;
            userToBeUpdate.BirthDate = user.BirthDate;
        }

        public void DeleteUser(int id)
        {
            Users = Users.Where(user => user.Id != id).ToList();
        }

        public void UpdateRole(int id,Role role)
        {
            var userRoleToBeUpdate = Users.First(user => user.Id == id);
            userRoleToBeUpdate.Role = role;
        }

        public void AddRole(int id, Role role)
        {
            var userRoleToBeAdded = Users.First(user => user.Id == id);
           userRoleToBeAdded.Role = role;
        }
        public void DeleteRole(int id1,int id2)
        {
            var userRoleToBeDeleted = Users.First(user => user.Id == id1);
             if(userRoleToBeDeleted.Role.Id == id2)
            {
                userRoleToBeDeleted.Role = null;
            }
            
           // userRoleToBeDeleted.Role = null;
        }
        public IEnumerable<Role> GetAllRoles()
        {
            List<Role> role = new List<Role>();
            foreach (User Role in Users)
            {
                Role _role = Role.Role;
                role.Add(_role);
            }
            return role;

        }

        public IEnumerable<User> SearchByInterval(DateTime startDate, DateTime endDate)
        {
            var user = Users.Where(user => user.BirthDate > startDate && user.BirthDate < endDate);

            return user;
        }

        public IEnumerable<User> SearchByRole(string role)
        {
            var user = Users.Where(user => user.Role.UserType == role);

            return user;

        }

    }

}
