using DataCafeteria.Context;
using DtosCafeteria;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCafeteria
{
    public class ProductosEntity
    {
        private readonly ApplicationDbContext Context;

        public ProductosEntity(string connectionString)
        {
            Context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), connectionString);
        }

        public async Task<Productos> AgregarProducto(Productos producto)
        {
            var productoNew = await this.Context.Productos.AddAsync(producto);
            await this.Context.SaveChangesAsync();
            return productoNew.Entity;
        }
        public async Task<List<Productos>> GetListaProductos()
        {
            return await Context.Productos.ToListAsync();
        }
        public async Task<int> ActualizarProducto(Productos producto)
        {
            Context.Entry(producto).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }
        public async Task<Productos> GetProductoId(int id)
        {
            var producto = Context.Productos.FindAsync(id);
            return await producto;
        }
    }
}
