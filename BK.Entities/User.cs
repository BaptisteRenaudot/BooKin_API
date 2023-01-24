using System.Runtime.InteropServices.JavaScript;

namespace BK.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pseudo { get; set; }
    public string EmailAdress { get; set; }
    public string Password { get; set; }
    public DateTime RegisterAt { get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}