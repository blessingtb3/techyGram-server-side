using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GramAPI.Data;
using GramAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GramAPI.Controllers.v1
{
    [ApiVersion("1.0")] // specifying the api version
    [Route("api/v1/[controller]")] // route with version
    [ApiController]
    public class UserStoriesController : ControllerBase
    {
        private readonly AppDbContext _context; // db context
        public UserStoriesController(AppDbContext context)
        {
            _context = context; // db context injection
        }

        // GET: api/v1/userstories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStory>>> GetUserStories()
        {
            // Retrieve all user stories from the db 
            return await _context.UserStories.ToListAsync();
        }

        // GET: api/v1/userstories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStory>> GetUserStory(int id)
        {
            var userStory = await _context.UserStories.FindAsync(id);
            if (userStory == null)
            {
                return NotFound(); // returning 404 if not found
            }
            return userStory; // returning the found user story
        }

        // POST: api/v1/userstories 
        [HttpPost]
        public async Task<ActionResult<UserStory>> PostUserStory(UserStory userStory)
        {
            _context.UserStories.Add(userStory); // add new user story to the context
            await _context.SaveChangesAsync(); // save changes to the db
            return CreatedAtAction(nameof(GetUserStory), new { id = userStory.Id }, userStory); // return 201 created
        }

        // PUT: api/v1/userstories
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStory(int id, UserStory userStory)
        {
            if (id != userStory.Id)
            {
                return BadRequest(); // returning 400 if the id's don't mach
            }

            _context.Entry(userStory).State = EntityState.Modified; // mark the user story as modified
            await _context.SaveChangesAsync(); // save changes to the db
            return NoContent(); // returning 204 No Content
        }

        // DELETE: api/v1/userstories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStory(int id)
        {
            var userStory = await _context.UserStories.FindAsync(id); // find user story by ID
            if (userStory == null)
            {
                return NotFound(); // returning 404 if not found
            }

            _context.UserStories.Remove(userStory); // removing the user story
            await _context.SaveChangesAsync(); // save changes to the db
            return NoContent(); // return 204 no content
        }
    }
}