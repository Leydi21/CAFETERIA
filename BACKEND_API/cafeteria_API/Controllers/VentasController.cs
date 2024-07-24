using DtosCafeteria;
using LogicCafeteria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cafeteria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly string StringConnection;
        public VentasController(IConfiguration config)
        {
            StringConnection = config.GetConnectionString("dbCon");
        }

        [HttpGet]
        public async Task<IActionResult> GetListaVentas()
        {
            VentasLogic ventasLogic = new(StringConnection);
            var respuesta = await ventasLogic.GetListaVentas();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarVenta(Ventas venta)
        {
            VentasLogic ventaLogic = new(StringConnection);
            var respuesta = await ventaLogic.AgregarVenta(venta);
            return Ok(respuesta);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetVentaId(int Id)
        {
            VentasLogic ventaLogic = new(StringConnection);
            var respuesta = await ventaLogic.GetVentaId(Id);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarVenta(Ventas venta)
        {
            VentasLogic ventaLogic = new(StringConnection);
            var respuesta = await ventaLogic.ActualizarVenta(venta);
            return Ok(respuesta);
        }

        [HttpGet("GetByMonth/{year}/{month}")]
        public async Task<IActionResult> GetVentasPorMes(int year, int month)
        {
            VentasLogic ventaLogic = new(StringConnection);
            var respuesta = await ventaLogic.GetVentasPorMes(year, month);
            return Ok(respuesta);
        }

        [HttpGet("GetByWeek/{year}/{week}")]
        public async Task<IActionResult> GetVentasPorSemana(int year, int week)
        {
            VentasLogic ventaLogic = new(StringConnection);
            var respuesta = await ventaLogic.GetVentasPorSemana(year, week);
            return Ok(respuesta);
        }

    }
}
