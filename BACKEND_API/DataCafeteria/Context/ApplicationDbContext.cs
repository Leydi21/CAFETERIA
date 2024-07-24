using DtosCafeteria;
using Microsoft.EntityFrameworkCore;

namespace DataCafeteria.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, string connectionString) :
            base(options) => this._connectionString = connectionString;

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Detalle_Compras> Detalle_Compras { get; set; }
        public DbSet<Detalle_Ventas> Detalle_Ventas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
