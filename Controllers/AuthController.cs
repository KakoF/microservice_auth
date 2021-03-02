using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.utils;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{

  [HttpPost]
  public async Task<ActionResult<dynamic>> Login([FromBody] AutenticationModel model)
  {
    try
    {
      model.IsValid();
      var token = await Token.GenerateToken(model);
      return new { token = token };
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }

  }
}