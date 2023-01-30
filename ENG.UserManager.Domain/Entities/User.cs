using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ENG.UserManager.Domain.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [Required]
    public string? Id { get; set; } = ObjectId.GenerateNewId().ToString();
    [Required]
    public string? UserName { get; set; }
    [Required]
    public DateTime? BirthDate { get; set; }
    [Required]
    public bool? Active { get; set; } = true;

}
