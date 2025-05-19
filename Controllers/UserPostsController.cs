using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GramAPI.Data;
using GramAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GramAPI.Controllers.v1
{
    [ApiVersion("1.0")] // specifying the api version
    [Route("api/v1/[controller]")] // route with version
    [ApiController]
    public class UserPostsController : ControllerBase
    {
        private readonly AppDbContext _context; // db context

        public UserPostsController(AppDbContext context)
        {
            _context = context; // injecting the db context
        }

        // GET: api/v1/userposts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPost>>> GetUserPosts()
        {
            // retrieve all user posts from the db
            return await _context.UserPosts.ToListAsync();
        }

        // GET: api/v1/userposts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPost>> GetUserPost(int id)
        {
            var userPost = await _context.UserPosts.FindAsync(id); // finding a user by their id
            if (userPost == null)
            {
                return NotFound(); // returning 404 if not found
            }
            return userPost; // returning the requested user post
        }

        //  POST: api/v1/userposts
        [HttpPost]
        public async Task<ActionResult<UserPost>> PostUserPost(UserPost userPost)
        {
            _context.UserPosts.Add(userPost); // add new user post to the context
            await _context.SaveChangesAsync(); // save changes to the  db
            return CreatedAtAction(nameof(GetUserPost), new { id = userPost.Id }, userPost); // returning 201 created
        }

        // PUT: api/v1/userposts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPost(int id, UserPost userPost)
        {
            if (id != userPost.Id)
            {
                return BadRequest(); //returning 400 if id's do not match
            }

            _context.Entry(userPost).State = EntityState.Modified; // mark the user post as modified
            await _context.SaveChangesAsync(); // saving changes to the db
            return NoContent(); // returning 204 no content   
        }

        // DELETE: api/v1/userposts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPost(int id)
        {
            var userPost = await _context.UserPosts.FindAsync(id); // fining the user post by their id
            if (userPost == null)
            {
                return NotFound();
            }

            _context.UserPosts.Remove(userPost); // removing the user post
            await _context.SaveChangesAsync(); // save changes to the db
            return NoContent(); // return 204 no content
        }
    }
}