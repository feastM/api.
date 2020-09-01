using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkshopWebApi.Models;
using WorkshopWebApi.Providers;

namespace WorkshopWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IUserProvider _userProvider;



        public ProfileController(IUserProvider userProvider)
        {
            _userProvider = userProvider;


        }
        
        [HttpGet]
        [Authorize(Policy = Policies.User)]
        public IEnumerable<User> GetAllUsersProfile()
        {
            return _userProvider.GetAll();
        }
        [HttpPatch]
        [Route("{id}")]
        [Authorize(Policy = Policies.User)]
        public void UpdateUser(int id,[FromBody] User user)
        {
            _userProvider.UpdateUser(id,user);
        }

    }
}
