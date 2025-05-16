namespace GramAPI.Models
{
    //represents a user story in the app 
    public class UserStory
    {
        /// user properties for user story
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
    }
}