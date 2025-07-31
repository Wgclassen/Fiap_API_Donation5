using Fiap.Api.Donation5.Data;
using Fiap.Api.Donation5.Models;
using Fiap.Api.Donation5.Repository.Interfaces;
using Fiap.Api.Donation5.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;
using Fiap.Api.Donation5.ViewModel;
using Fiap.Api.Donation5.Services;

namespace Fiap.Api.Donation5.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly AuthTokenService _authTokenService;

    public UsuarioController(DataContext dataContext, IConfiguration configuration)
    {
        _usuarioRepository = new UsuarioRepository(dataContext);
        _authTokenService = new AuthTokenService(configuration);
    }

    [HttpGet]
    public ActionResult<IList<UsuarioModel>> GetAll()
    {
        var usuarios = _usuarioRepository.FindAll();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public ActionResult<UsuarioModel> GetById(int id)
    {
        var usuario = _usuarioRepository.FindById(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuarioId = _usuarioRepository.Insert(usuarioModel);
        usuarioModel.UsuarioId = usuarioId;

        return CreatedAtAction(nameof(GetById), new { id = usuarioId }, usuarioModel);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UsuarioModel usuarioModel)
    {
        if (id != usuarioModel.UsuarioId)
            return BadRequest("ID da URL diferente do corpo da requisição.");

        _usuarioRepository.Update(usuarioModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = _usuarioRepository.FindById(id);
        if (usuario == null)
            return NotFound();

        _usuarioRepository.Delete(id);
        return NoContent();
    }

    [HttpPost]
    [Route("Login")]
    public ActionResult<LoginResponseViewModel> Login([FromBody] LoginRequestViewModel loginRequest)
    {
        if (ModelState.IsValid)
        {
            var usuario = _usuarioRepository.FindByEmailAndSenha(loginRequest.EmailUsuario, loginRequest.Senha);

            if (usuario != null)
            {
                var loginResponse = new LoginResponseViewModel();
                loginResponse.NomeUsuario = usuario.NomeUsuario;
                loginResponse.Token = _authTokenService.GenerateToken(usuario.EmailUsuario, usuario.UsuarioId, usuario.Regra);

                return Ok(loginResponse);
            }
            else
            {
                return Unauthorized();
            }
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
}