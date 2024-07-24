using DtosCafeteria;
using LogicCafeteria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cafeteria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly string StringConnection;
        public ComprasController(IConfiguration config)
        {
            StringConnection = config.GetConnectionString("dbCon");
        }

        [HttpGet]
        public async Task<IActionResult> GetListaCompras()
        {
            ComprasLogic comprasLogic = new(StringConnection);
            var respuesta = await comprasLogic.GetListaCompras();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCompra(Compras compra)
        {
            ComprasLogic comprasLogic = new(StringConnection);
            var respuesta = await comprasLogic.AgregarCompra(compra);
            return Ok(respuesta);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetCompraId(int Id)
        {
            ComprasLogic comprasLogic = new(StringConnection);
            var respuesta = await comprasLogic.GetCompraId(Id);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCompra(Compras compra)
        {
            ComprasLogic compraLogic = new(StringConnection);
            var respuesta = await compraLogic.ActualizarCompra(compra);
            return Ok(respuesta);
        }
    }
}
