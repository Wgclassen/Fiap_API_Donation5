using Fiap.Api.Donation5.Models;
using Fiap.Api.Donation5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Fiap.Api.Donation5.ViewModel;
using Fiap.Api.Donation5.Services;
using Fiap.Api.Donation5.Repository;

namespace Fiap.Api.Donation5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly AuthTokenService _authTokenService;

    public UsuarioController(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _authTokenService = new AuthTokenService(configuration);
    }

    [HttpGet]
    public async Task<ActionResult<IList<UsuarioModel>>> GetAll()
    {
        var usuarios = await _usuarioRepository.FindAllAsync();

        if (usuarios == null || usuarios.Count == 0)
        {
            return NoContent();
        } else
        {
            return Ok(usuarios);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> GetById(int id)
    {
        var usuario = await _usuarioRepository.FindByIdAsync(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> Post([FromBody] UsuarioModel usuarioModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuarioId = await _usuarioRepository.InsertAsync(usuarioModel);
        usuarioModel.UsuarioId = usuarioId;

        return CreatedAtAction(nameof(GetById), new { id = usuarioId }, usuarioModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UsuarioModel usuarioModel)
    {
        if (id != usuarioModel.UsuarioId)
            return BadRequest("ID da URL diferente do corpo da requisição.");

        await _usuarioRepository.UpdateAsync(usuarioModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var usuario = await _usuarioRepository.FindByIdAsync(id);
        if (usuario == null)
            return NotFound();

        _usuarioRepository.DeleteAsync(id);
        return NoContent();
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<LoginResponseViewModel>> Login([FromBody] LoginRequestViewModel loginRequest)
    {
        if (ModelState.IsValid)
        {
            var usuario = await _usuarioRepository.FindByEmailAndSenhaAsync(loginRequest.EmailUsuario, loginRequest.Senha);

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