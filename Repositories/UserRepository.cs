using Server.Entities;
using Server.Data;

namespace Server.Repositories;

public class UserRepository
{
  private readonly ServerDbContext _context;

  public UserRepository(ServerDbContext context)
  {
    _context = context;
  }

  public List<User> GetUsers()
  {
    return _context.Users.ToList();
  }

  public User? GetUser(int id)
  {
    return _context.Users.FirstOrDefault(u => u.Id == id);
  }

  public User AddUser(User user)
  {
    _context.Users.Add(user);
    _context.SaveChanges();
    return user;
  }

  public User? UpdateUser(User user)
  {
    var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
    if (existingUser == null)
    {
      return null;
    }
    existingUser.Name = user.Name;
    existingUser.Email = user.Email;
    existingUser.Password = user.Password;
    existingUser.Role = user.Role;
    existingUser.Address = user.Address;
    _context.SaveChanges();
    return existingUser;
  }

  public void DeleteUser(int id)
  {
    var user = _context.Users.FirstOrDefault(u => u.Id == id);
    if (user != null)
    {
      _context.Users.Remove(user);
      _context.SaveChanges();
    }
  }
}