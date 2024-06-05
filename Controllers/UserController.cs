using Microsoft.AspNetCore.Mvc;
using PeopleApi.Interfaces;
using PeopleApi.Models;

namespace PeopleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _user.GetAllUsers();
            return result;
        }

        //Get : api/Users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _user.GetUserById(id);
            if(user == null)
            {

                return NotFound();
            }
            return user;
        }

        //post: api/users
        [HttpPost]
        public async Task<ActionResult< User> > PostUser(User user)
        {
            await _user.CreateUser(user);
            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        //put : api/users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if(id!=user.ID)
            {
                return BadRequest();
            }
            await _user.UpdateUser(user);
            return CreatedAtAction("GetUser", new {id= user.ID }, user);
        }

        //delete : api/user/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _user.GetUserById(id);
            if(user ==null)
            {
                return NotFound();
            }
            await _user.DeleteUser(id);
            return user;
        }
    }
}
