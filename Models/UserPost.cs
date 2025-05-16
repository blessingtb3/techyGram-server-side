namespace GramAPI.Models
{
    // Represents a user post in the app
    public class UserPost
    {
        /// User post properties
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
        public int Bookmarks { get; set; }
        public string Image { get; set; } //user post image path
        public string ProfileImage { get; set; } //user profile image path 
    }
}