using Server.Entities;
using Server.Repositories;

namespace Server.Services;

public class UserService
{
  private readonly UserRepository _userRepo;

  public UserService(UserRepository userRepo)
  {
    _userRepo = userRepo;
  }

  public List<User> GetUsers()
  {
    return _userRepo.GetUsers();
  }

  public User? GetUser(int id)
  {
    return _userRepo.GetUser(id);
  }

  public User AddUser(User user)
  {
    return _userRepo.AddUser(user);
  }

  public User? UpdateUser(User user)
  {
    return _userRepo.UpdateUser(user);
  }

  public void DeleteUser(int id)
  {
    _userRepo.DeleteUser(id);
  }

}