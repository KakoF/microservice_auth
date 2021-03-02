using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apiAuth.Models;
using Microsoft.IdentityModel.Tokens;

namespace apiAuth.utils
{
  public class Token
  {
    public static async Task<string> GenerateToken(AutenticationModel user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(Startup.StaticConfig.GetSection("private_key_token").Value);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
              new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
              new Claim(ClaimTypes.Role, user.Role),
          }),
        Expires = System.DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return await Task.FromResult(tokenHandler.WriteToken(token));
    }
  }
}