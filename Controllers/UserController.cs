using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using WorkshopWebApi.Models;
using WorkshopWebApi.Providers;

namespace WorkshopWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserProvider _userProvider;
        


        public UsersController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        

        }

      
        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public IEnumerable<User> GetAllUsers()
        {
            return _userProvider.GetAll();
        }

        [HttpDelete]
        [Authorize(Policy = Policies.Admin)]
        [Route("{id}")]
        public IEnumerable<User> DeleteUser(int id)
        {
            _userProvider.DeleteUser(id);
            return _userProvider.GetAll();

        }
        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        public void AddUser([FromBody]User user)
        {
            _userProvider.AddUser(user);
        }
        [HttpPut]
        [Authorize(Policy = Policies.Admin)]
        [Route("{id}")]
        public void UpdateUserAdmin(int id,[FromBody] User user)
        {
            _userProvider.UpdateUserAdmin(id,user);
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        [Route("{id}/{roles}")]
        public void AddRole(int id,[FromBody] Role role)
        {
            _userProvider.AddRole(id,role);
        }
        [HttpDelete]
        [Authorize(Policy = Policies.Admin)]
        [Route("{id1}/roles/{id2}")]
        public void DeleteRole(int id1, int id2)
        {
            _userProvider.DeleteRole(id1, id2);
        }
        [HttpGet]
        [Route("{id}/{roles}")]
        [Authorize(Policy = Policies.Admin)]
        public IEnumerable<Role> GetAllUsersRole()
        {
            return _userProvider.GetAllRoles();
        }
        [HttpPatch]
        [Route("{id}")]
        [Authorize(Policy = Policies.User)]
        public void UpdateUser(int id, [FromBody] User user)
        {
            _userProvider.UpdateUser(id, user);
        }
        [HttpGet("{startDate},{endDate}")]
        [Route("getdate")]
        [Authorize(Policy = Policies.Admin)]
        public IEnumerable<User> SearchByInterval([FromQuery]DateTime startDate,[FromQuery] DateTime endDate)
        {
            return _userProvider.SearchByInterval(startDate,endDate);
        }
        [HttpGet("{role}")]
        [Route("get")]
        [Authorize(Policy = Policies.Admin)]
        public IEnumerable<User> SearchByRole([FromQuery] string role)
        {
            return _userProvider.SearchByRole(role);
        }

    }
}