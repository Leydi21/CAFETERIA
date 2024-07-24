using DtosCafeteria;
using LogicCafeteria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cafeteria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_ComprasController : ControllerBase
    {
        private readonly string StringConnection;
        public Detalle_ComprasController(IConfiguration config)
        {
            StringConnection = config.GetConnectionString("dbCon");
        }

        [HttpGet]
        public async Task<IActionResult> GetListaDetalle_Compras()
        {
            Detalle_ComprasLogic detalleCompraLogic = new(StringConnection);
            var respuesta = await detalleCompraLogic.GetListaDetalle_Compras();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarDetalle_Compras(Detalle_Compras detalleCompra)
        {
            Detalle_ComprasLogic detalleCompraLogic = new(StringConnection);
            var respuesta = await detalleCompraLogic.AgregarDetalle_Compras(detalleCompra);
            return Ok(respuesta);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetDetalle_CompraId(int Id)
        {
            Detalle_ComprasLogic detalleCompraLogic = new(StringConnection);
            var respuesta = await detalleCompraLogic.GetDetalle_CompraId(Id);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarDetalle_Compra(Detalle_Compras detalleCompra)
        {
            Detalle_ComprasLogic detalleCompraLogic = new(StringConnection);
            var respuesta = await detalleCompraLogic.ActualizarDetalle_Compra(detalleCompra);
            return Ok(respuesta);
        }
    }
}
