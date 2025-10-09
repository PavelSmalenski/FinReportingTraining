using System.ComponentModel.DataAnnotations;

namespace FinDatabase.Entities;

public class User
{
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
}