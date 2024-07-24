using System.ComponentModel.DataAnnotations;

namespace DtosCafeteria
{
    public class Productos
    {
        [Key]
        public int Producto_id { get; set; }
        public int TipoProducto_id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Sabor { get; set; }
        public string Tamanio { get; set; }
        public string Unidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
    }
}
