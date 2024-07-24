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
    public class UsuariosEntity
    {
        private readonly ApplicationDbContext Context;

        public UsuariosEntity(string connectionString)
        {
            Context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), connectionString);
        }

        public async Task<Usuarios> AgregarUsuario(Usuarios usuario)
        {
            var usuarioNew = await this.Context.Usuarios.AddAsync(usuario);
            await this.Context.SaveChangesAsync();
            return usuarioNew.Entity;
        }
        public async Task<List<Usuarios>> GetListaUsuarios()
        {
            return await Context.Usuarios.ToListAsync();
        }

        public async Task<int> ActualizarUsuario(Usuarios usuario)
        {
            Context.Entry(usuario).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async Task<Usuarios> GetUsuarioId(int id)
        {
            var user = Context.Usuarios.FindAsync(id);
            return await user;
        }
    }
}