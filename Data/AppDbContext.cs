using Microsoft.EntityFrameworkCore;
using GramAPI.Models;

namespace GramAPI.Data
{
    // Db context for the app
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //DbSet for user stories 
        public DbSet<UserStory> UserStories { get; set; }

        //DbSet for user posts
        public DbSet<UserPost> UserPosts { get; set; }
    }
}