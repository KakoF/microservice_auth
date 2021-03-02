namespace apiAuth.Models
{
  public class UserModel
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Role { get; set; }

    public void IsValid()
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