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
    public class Detalle_ComprasEntity
    {
        private readonly ApplicationDbContext Context;

        public Detalle_ComprasEntity(string connectionString)
        {
            Context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), connectionString);
        }

        public async Task<Detalle_Compras> AgregarDetalle_Compras(Detalle_Compras detalleCompra)
        {
            var detalleCompraNew = await this.Context.Detalle_Compras.AddAsync(detalleCompra);
            await this.Context.SaveChangesAsync();
            return detalleCompraNew.Entity;
        }
        public async Task<List<Detalle_Compras>> GetListaDetalle_Compras()
        {
            return await Context.Detalle_Compras.ToListAsync();
        }

        public async Task<int> ActualizarDetalle_Compra(Detalle_Compras detalleCompra)
        {
            Context.Entry(detalleCompra).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async Task<Detalle_Compras> GetDetalle_CompraId(int id)
        {
            var detalleCompra = Context.Detalle_Compras.FindAsync(id);
            return await detalleCompra;
        }
    }
}
