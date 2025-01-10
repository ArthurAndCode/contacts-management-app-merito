using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; // Hash hasła
    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    
    [NotMapped]
    public string ConfirmPassword { get; set; }
}
