using System.ComponentModel.DataAnnotations;

namespace DtosCafeteria
{
    public class Detalle_Compras
    {
        [Key]
        public int DetalleCompra_id { get; set; }
        public int Compra_id { get; set; }
        public int Producto_id { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_unitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
