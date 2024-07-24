using System.ComponentModel.DataAnnotations;

namespace DtosCafeteria
{
    public class Ventas
    {
        [Key]
        public int Venta_id { get; set; }
        public int Usuario_id { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
    }
}
