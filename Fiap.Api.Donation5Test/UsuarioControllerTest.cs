using Fiap.Api.Donation5.Controllers;
using Fiap.Api.Donation5.Models;
using Fiap.Api.Donation5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Fiap.Api.Donation5Test
{
    public class UsuarioControllerTest : BaseTest
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IConfiguration> _configuration;

        public UsuarioControllerTest()
        {
            _configuration = new Mock<IConfiguration>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
        }

        [Fact]
        public async Task GetUsuarioResultOkWithUsuarios()
        {
            var usuarios = new List<UsuarioModel>
            {
                new UsuarioModel { UsuarioId = 1, NomeUsuario = "Usuario 1" },
                new UsuarioModel { UsuarioId = 2, NomeUsuario = "Usuario 2" }
            };

            _usuarioRepository.Setup( r => r.FindAllAsync() ).ReturnsAsync( usuarios );

            var controller = new UsuarioController(_usuarioRepository.Object, _configuration.Object);
            var getResult = await controller.GetAll();

            var resultType = Assert.IsType<OkObjectResult>(getResult.Result);
            var resultValue = Assert.IsType<List<UsuarioModel>>(resultType.Value);

            Assert.Equal(2, resultValue.Count());
            Assert.Equal("Usuario 1", resultValue[0].NomeUsuario);
            Assert.Equal("Usuario 2", resultValue[1].NomeUsuario);
        }

        [Fact]
        public async Task GetUsuarioResultOkWith3Usuarios()
        {
            var usuarios = new List<UsuarioModel>
            {
                new UsuarioModel { UsuarioId = 1, NomeUsuario = "Usuario 1" },
                new UsuarioModel { UsuarioId = 2, NomeUsuario = "Usuario 2" },
                new UsuarioModel { UsuarioId = 3, NomeUsuario = "Usuario 3" }
            };

            _usuarioRepository.Setup(r => r.FindAllAsync()).ReturnsAsync(usuarios);

            var controller = new UsuarioController(_usuarioRepository.Object, _configuration.Object);
            var getResult = await controller.GetAll();

            var resultType = Assert.IsType<OkObjectResult>(getResult.Result);
            var resultValue = Assert.IsType<List<UsuarioModel>>(resultType.Value);

            Assert.Equal(3, resultValue.Count());
            Assert.Equal("Usuario 1", resultValue[0].NomeUsuario);
            Assert.Equal("Usuario 2", resultValue[1].NomeUsuario);
            Assert.Equal("Usuario 3", resultValue[2].NomeUsuario);
        }

        [Fact]
        public async Task GetUsuarioResultNoContent()
        {
            _usuarioRepository.Setup(r => r.FindAllAsync()).ReturnsAsync(new List<UsuarioModel>());

            var controller = new UsuarioController(_usuarioRepository.Object, _configuration.Object);
            var getResult = await controller.GetAll();

            var resultType = Assert.IsType<NoContentResult>(getResult.Result);
        }
    }
}
