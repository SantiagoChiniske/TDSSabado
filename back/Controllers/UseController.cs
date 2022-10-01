using Microsoft.AspNetCore.Mvc;
using dto;


namespace back.Controllers;

using Model;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("Login")]
    public IActionResult Login()
    {
       throw new NotImplementedException(); 
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody]UsuarioDTO user)
    {
    using TDSabadoContext context = new TDSabadoContext();
    Usuario usuario = new Usuario();
    usuario.Nome = user.Name;
    usuario.DataNascimento = user.BirthDate;
    usuario.UserId = user.UserId;
    usuario.Senha = user.Password;

    List<string> errors = new List<string>();
    if(usuario.Nome.Length<5){
        errors.Add("O nome do usuário precisa conter ao menos 5 letras.");
    }

    if( context.Usuarios
    .Where(u => u.UserId == user.UserId)
    .Any()){
        errors.Add("Seu nome de Usuário já está em uso!");
    }


    if(errors.Count>0)
    {
        return this.BadRequest(errors);
    }


    // var query2 =
    // from u in context.Usuarios
    // where u.Nome == user.UserId
    // select u;

    context.Add(usuario);
    context.SaveChanges();

    return Ok();

    
    }

    [HttpPost("update")]
    public  IActionResult UpdateName()
    {
        throw new NotImplementedException();
    }
}
