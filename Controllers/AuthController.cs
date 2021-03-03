using System;
using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.Services.Interfaces;
using apiAuth.utils;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
  private readonly IAutenticationService _service;
  public AuthController(IAutenticationService service)
  {
    _service = service;
  }

  [HttpPost]
  public async Task<ActionResult<dynamic>> Login([FromBody] AutenticationModel model)
  {
    try
    {
      model.IsCustomValid();
      var userAuth = _service.Login(model);
      var token = await Token.GenerateToken(model);
      return new { token = token };
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }

  }
}