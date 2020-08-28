using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WorkshopWebApi.Models;

namespace WorkshopWebApi.Providers
{
    public class UserProvider : IUserProvider
    {
        List<User> Users;
        

        public  UserProvider()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Id = 1,Name = "Alex", 
                    BirthDate = new DateTime(1997,11,28),
                    Role = new List<Role>()
                    {
                        new Role()
                        {
                            Id = 1, 
                            Type="Admin"
                        }

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

        public void UpdateUser(int id,User user)
        {
            var userToBeUpdate = Users.First(user => user.Id == id);
            userToBeUpdate.Name = user.Name;
            userToBeUpdate.BirthDate = user.BirthDate;
            userToBeUpdate.Role = user.Role;
        }

        public void DeleteUser(int id)
        {
            Users = Users.Where(user => user.Id != id).ToList();
        }

        public void UpdateRole(int id,User user)
        {
            var userRoleToBeUpdate = Users.First(user => user.Id == id);
            userRoleToBeUpdate.Role = user.Role;
        }

        public void AddRole(int id, Role role)
        {
            var userRoleToBeAdded = Users.First(user => user.Id == id);
           userRoleToBeAdded.Role.Add(role);
        }
        public void DeleteRole(int id1,int id2)
        {
            var userRoleToBeDeleted = Users.First(role => role.Id == id1);
            userRoleToBeDeleted.Role = userRoleToBeDeleted.Role.Where(user => user.Id != id2).ToList();
            //Users = Users.Where(user => user.Id != id).ToList();
        }
    }
}
