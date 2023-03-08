using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly UserService _userService;

  public UserController(UserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public ActionResult<List<User>> GetUsers()
  {
    return _userService.GetUsers();
  }

  [HttpGet("{id}")]
  public ActionResult<User> GetUser(int id)
  {
    var user = _userService.GetUser(id);
    if (user == null)
    {
      return NotFound();
    }
    return user;
  }

  [HttpPost]
  public ActionResult<User> AddUser(User user)
  {
    _userService.AddUser(user);
    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
  }

  [HttpPut("{id}")]
  public ActionResult<User> UpdateUser(int id, User user)
  {
    if (id != user.Id)
    {
      return BadRequest();
    }
    var existingUser = _userService.GetUser(id);
    if (existingUser == null)
    {
      return NotFound();
    }
    return _userService.UpdateUser(user);
  }

  [HttpDelete("{id}")]
  public ActionResult DeleteUser(int id)
  {
    var user = _userService.GetUser(id);
    if (user == null)
    {
      return NotFound();
    }
    _userService.DeleteUser(id);
    return NoContent();
  }
}