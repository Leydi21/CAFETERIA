using DtosCafeteria;
using LogicCafeteria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cafeteria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly string StringConnection;
        public UsuariosController(IConfiguration config)
        {
            StringConnection = config.GetConnectionString("dbCon");
        }

        [HttpGet]
        public async Task<IActionResult> GetListaUsuarios()
        {
            UsuariosLogic usuariosLogic = new(StringConnection);
            var respuesta = await usuariosLogic.GetListaUsuarios();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarUsuario(Usuarios usuario)
        {
            UsuariosLogic usuarioLogic = new(StringConnection);
            var respuesta = await usuarioLogic.AgregarUsuario(usuario);
            return Ok(respuesta);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetUsuarioId(int Id)
        {
            UsuariosLogic usuariosLogic = new(StringConnection);
            var respuesta = await usuariosLogic.GetUsuarioId(Id);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario(Usuarios usuario)
        {
            UsuariosLogic usuariosLogic = new(StringConnection);
            var respuesta = await usuariosLogic.ActualizarUsuario(usuario);
            return Ok(respuesta);
        }
    }
}
