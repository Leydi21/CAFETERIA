using DataCafeteria;
using DtosCafeteria;
using DtoVende.DtoOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCafeteria
{
    public class UsuariosLogic
    {
        private UsuariosEntity UsuariosEntity;
        public UsuariosLogic(string StringConnection)
        {
            UsuariosEntity = new UsuariosEntity(StringConnection);
        }
        public async Task<BasicResponse<List<Usuarios>>> GetListaUsuarios()
        {
            BasicResponse<List<Usuarios>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await UsuariosEntity.GetListaUsuarios();
                respuesta.Message = "Lista de Usuarios";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = null;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<Usuarios>> AgregarUsuario(Usuarios usuario)
        {
            BasicResponse<Usuarios> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await UsuariosEntity.AgregarUsuario(usuario);
                respuesta.Message = "Registro exitoso";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = null;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<Usuarios>> GetUsuarioId(int id)
        {
            BasicResponse<Usuarios> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await UsuariosEntity.GetUsuarioId(id);
                respuesta.Message = "Usuario";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<int>> ActualizarUsuario(Usuarios usuario)
        {
            BasicResponse<int> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await UsuariosEntity.ActualizarUsuario(usuario);
                respuesta.Message = "Usuario Actualizado";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = 0;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }
    }
}