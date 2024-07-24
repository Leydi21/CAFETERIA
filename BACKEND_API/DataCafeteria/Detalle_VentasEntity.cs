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
    public class Detalle_VentasEntity
    {
        private readonly ApplicationDbContext Context;

        public Detalle_VentasEntity(string connectionString)
        {
            Context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), connectionString);
        }

        public async Task<Detalle_Ventas> AgregarDetalle_Venta(Detalle_Ventas detalleVenta)
        {
            var detalleVentaNew = await this.Context.Detalle_Ventas.AddAsync(detalleVenta);
            await this.Context.SaveChangesAsync();
            return detalleVentaNew.Entity;
        }
        public async Task<List<Detalle_Ventas>> GetListaDetalle_Ventas()
        {
            return await Context.Detalle_Ventas.ToListAsync();
        }
        public async Task<int> ActualizarDetalle_Venta(Detalle_Ventas detalleVenta)
        {
            Context.Entry(detalleVenta).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async Task<List<Detalle_Ventas>> GetDetallesByVentaId(int ventaId)
        {
            var detallesVenta = await Context.Detalle_Ventas.Where(dv => dv.Venta_id == ventaId).ToListAsync();
            return detallesVenta;
        }


    }
}
