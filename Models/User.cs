using System.ComponentModel.DataAnnotations;

namespace GramAPI.Models;

public class User
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public byte[] PasswordHash { get; set; } = new byte[0];
    
    public byte[] PasswordSalt { get; set; } = new byte[0];
}
