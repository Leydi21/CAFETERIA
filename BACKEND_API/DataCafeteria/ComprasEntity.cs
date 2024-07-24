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
    public class ComprasEntity
    {
        private readonly ApplicationDbContext Context;

        public ComprasEntity(string connectionString)
        {
            Context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), connectionString);
        }

        public async Task<Compras> AgregarCompra(Compras compra)
        {
            var compraNew = await this.Context.Compras.AddAsync(compra);
            await this.Context.SaveChangesAsync();
            return compraNew.Entity;
        }
        public async Task<List<Compras>> GetListaCompras()
        {
            return await Context.Compras.ToListAsync();
        }

        public async Task<int> ActualizarCompra(Compras compra)
        {
            Context.Entry(compra).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async Task<Compras> GetCompraId(int id)
        {
            var compra = Context.Compras.FindAsync(id);
            return await compra;
        }
    }
}
