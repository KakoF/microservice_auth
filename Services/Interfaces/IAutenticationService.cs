using apiAuth.Models;
namespace apiAuth.Services.Interfaces
{
  public interface IAutenticationService
  {
    AutenticationModel Login(AutenticationModel model);
  }
}