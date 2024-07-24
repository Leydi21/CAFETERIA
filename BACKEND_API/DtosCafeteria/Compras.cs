using System.ComponentModel.DataAnnotations;

namespace DtosCafeteria
{
    public class Compras
    {
        [Key]
        public int Compra_id { get; set; }
        public int Usuario_id { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
    }
}
