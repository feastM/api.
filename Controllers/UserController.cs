using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkshopWebApi.Models;
using WorkshopWebApi.Providers;

namespace WorkshopWebApi.Controllers
{
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        

        public UsersController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
          
        }
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userProvider.GetAll();
        }

        [HttpDelete]
        [Route("(id)")]
        public IEnumerable<User> DeleteUser(int id)
        {
            _userProvider.DeleteUser(id);
            return _userProvider.GetAll();

        }
        [HttpPost]
        public void AddUser([FromBody]User user)
        {
            _userProvider.AddUser(user);
        }
        [HttpPut]
        [Route("{id}")]
        public void UpdateUser(int id,[FromBody] User user)
        {
            _userProvider.UpdateUser(id,user);
        }

        [HttpPut]
        [Route("{id}/{roles}")]
        public void UpdateRole(int id,[FromBody] Role role)
        {
            _userProvider.AddRole(id,role);
        }
        [HttpDelete]
        [Route("{id1}/roles/{id2}")]
        public void DeleteRole(int id1, int id2)
        {
            _userProvider.DeleteRole(id1, id2);
        }
    }
}