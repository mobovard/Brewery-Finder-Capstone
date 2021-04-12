using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDAO userDAO;


        public UserController(IUserDAO _userDAO)
        {
            userDAO = _userDAO;
        }
        [HttpGet("/users")]
        public ActionResult<List<User>> UserList()
        {

            IList<User> users = userDAO.GetUsers();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
