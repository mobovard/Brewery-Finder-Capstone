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

            IList<ReturnUser> users = userDAO.GetReturnUserList();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPut("/users/{user_id}")]

        public ActionResult<ReturnUser> UpdateUser(int user_id,int active,string role)
        {
            ReturnUser returnUser = null;

            if (HttpContext.User.IsInRole("Admin"))
            {
                
                returnUser = userDAO.UpdateUserAdmin(active,role, user_id);
            }
            else
            {
                //Existing method works for basic user (has the active filter)

                int.TryParse(User.FindFirst("sub")?.Value, out user_id);
                //user_id = 2; 
                returnUser = userDAO.UpdateUserUser(active,user_id);
            }
            if (returnUser != null)
            {
                return Ok(returnUser);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

