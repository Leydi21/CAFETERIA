using DtosCafeteria;
using LogicCafeteria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cafeteria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private readonly string StringConnection;
        public TipoProductoController(IConfiguration config)
        {
            StringConnection = config.GetConnectionString("dbCon");
        }

        [HttpGet]
        public async Task<IActionResult> GetListaTipoProducto()
        {
            TipoProductoLogic tipoProductoLogic = new(StringConnection);
            var respuesta = await tipoProductoLogic.GetListaTipoProducto();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarTipoProducto(TipoProducto tipoProducto)
        {
            TipoProductoLogic tipoProductoLogic = new(StringConnection);
            var respuesta = await tipoProductoLogic.AgregarTipoProducto(tipoProducto);
            return Ok(respuesta);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetTipoProductoId(int Id)
        {
            TipoProductoLogic tipoProductoLogic = new(StringConnection);
            var respuesta = await tipoProductoLogic.GetTipoProductoId(Id);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarTipoProducto(TipoProducto tipoProducto)
        {
            TipoProductoLogic tipoProductoLogic = new(StringConnection);
            var respuesta = await tipoProductoLogic.ActualizarTipoProducto(tipoProducto);
            return Ok(respuesta);
        }
    }
}
