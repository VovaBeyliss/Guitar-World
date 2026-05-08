namespace GuitarWorld.Models;

public class User {
    public int Id { get; set; }
    public string Userame { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}