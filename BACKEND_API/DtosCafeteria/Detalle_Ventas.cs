using System.ComponentModel.DataAnnotations;

namespace DtosCafeteria
{
    public class Detalle_Ventas
    {
        [Key]
        public int DetalleVenta_id { get; set; }
        public int Venta_id { get; set; }
        public int Producto_id { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_unitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
