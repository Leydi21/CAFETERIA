using DtosCafeteria;
using LogicCafeteria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cafeteria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly string StringConnection;
        public ProductosController(IConfiguration config)
        {
            StringConnection = config.GetConnectionString("dbCon");
        }

        [HttpGet]
        public async Task<IActionResult> GetListaProductos()
        {
            ProductosLogic productosLogic = new(StringConnection);
            var respuesta = await productosLogic.GetListaProductos();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProducto(Productos producto)
        {
            ProductosLogic productoLogic = new(StringConnection);
            var respuesta = await productoLogic.AgregarProducto(producto);
            return Ok(respuesta);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetProductoId(int Id)
        {
            ProductosLogic productoLogic = new(StringConnection);
            var respuesta = await productoLogic.GetProductoId(Id);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarProducto(Productos producto)
        {
            ProductosLogic productoLogic = new(StringConnection);
            var respuesta = await productoLogic.ActualizarProducto(producto);
            return Ok(respuesta);
        }
    }
}
