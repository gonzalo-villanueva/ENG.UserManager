using System.ComponentModel.DataAnnotations;

namespace ENG.UserManager.Domain.Models;

public class UserCreateModel
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public DateTime? BirthDate { get; set; }
}