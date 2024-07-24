using DtosCafeteria;
using LogicCafeteria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cafeteria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_VentasController : ControllerBase
    {
        private readonly string StringConnection;
        public Detalle_VentasController(IConfiguration config)
        {
            StringConnection = config.GetConnectionString("dbCon");
        }

        [HttpGet]
        public async Task<IActionResult> GetListaDetalle_Ventas()
        {
            Detalle_VentasLogic detalleVentasLogic = new(StringConnection);
            var respuesta = await detalleVentasLogic.GetListaDetalle_Ventas();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarDetalle_Venta(Detalle_Ventas detalleVentas)
        {
            Detalle_VentasLogic detalleVentasLogic = new(StringConnection);
            var respuesta = await detalleVentasLogic.AgregarDetalle_Venta(detalleVentas);
            return Ok(respuesta);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetDetalle_VentaId(int Id)
        {
            Detalle_VentasLogic detalleVentasLogic = new(StringConnection);
            var respuesta = await detalleVentasLogic.GetDetalle_VentaId(Id);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarDetalle_Venta(Detalle_Ventas detalleVentas)
        {
            Detalle_VentasLogic detalleVentasLogic = new(StringConnection);
            var respuesta = await detalleVentasLogic.ActualizarDetalle_Venta(detalleVentas);
            return Ok(respuesta);
        }
    }
}
