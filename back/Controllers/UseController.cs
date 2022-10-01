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
