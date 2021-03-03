using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using apiAuth.utils.validation;

namespace apiAuth.Models
{
  public class AutenticationModel : IValidatableObject
  {

    public int Id { get; set; }
    [Required(ErrorMessage = "Email é requerido")]
    //[CustomName("K")]
    [EmailAddress(ErrorMessage = "Email não é válido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Senha é requerida")]
    [MinLength(5, ErrorMessage = "Senha é no mínimo 5 caracteres")]
    public string Senha { get; set; }
    public string Role { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Senha))
        yield return new ValidationResult(
          "Email e Senha devem ser preenchidos",
          new[] { nameof(Email), nameof(Senha) }
        );
    }

    public void IsCustomValid()
    {
      GetUser();
      GetRole();
      GetId();
    }
    private void GetUser()
    {
      if (this.Email != "admin@admin.com" && this.Email != "guest@guest.com")
      {
        throw new System.Exception("Usuário Inválido");
      }
      if (this.Senha != "123456")
      {
        throw new System.Exception("Senha Inválida");
      }
    }
    private void GetRole()
    {
      this.Role = this.Email == "admin@admin.com" ? "admin" : "guest";
    }
    private void GetId()
    {
      this.Id = this.Email == "admin@admin.com" ? 1 : 2;
    }
  }
}