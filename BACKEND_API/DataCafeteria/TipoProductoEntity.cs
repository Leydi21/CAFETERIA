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
    public class TipoProductoEntity
    {
        private readonly ApplicationDbContext Context;
        public TipoProductoEntity(string connectionString)
        {
            Context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), connectionString);
        }
        public async Task<TipoProducto> AgregarTipoProducto(TipoProducto tipoProducto)
        {
            var tipoProductoNew = await this.Context.TipoProducto.AddAsync(tipoProducto);
            await this.Context.SaveChangesAsync();
            return tipoProductoNew.Entity;
        }
        public async Task<List<TipoProducto>> GetListaTipoProducto()
        {
            return await Context.TipoProducto.ToListAsync();
        }
        public async Task<int> ActualizarTipoProducto(TipoProducto tipoProducto)
        {
            Context.Entry(tipoProducto).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }
        public async Task<TipoProducto> GetTipoProductoId(int id)
        {
            var tipoProducto = Context.TipoProducto.FindAsync(id);
            return await tipoProducto;
        }
    }
}
