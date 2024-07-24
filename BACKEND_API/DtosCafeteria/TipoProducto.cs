using System.ComponentModel.DataAnnotations;

namespace DtosCafeteria
{
    public class TipoProducto
    {
        [Key]
        public int TipoProducto_id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
