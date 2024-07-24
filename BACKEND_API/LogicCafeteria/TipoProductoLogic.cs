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
    public class TipoProductoLogic
    {
        private TipoProductoEntity TipoProductoEntity;
        public TipoProductoLogic(string StringConnection)
        {
            TipoProductoEntity = new TipoProductoEntity(StringConnection);
        }
        public async Task<BasicResponse<List<TipoProducto>>> GetListaTipoProducto()
        {
            BasicResponse<List<TipoProducto>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await TipoProductoEntity.GetListaTipoProducto();
                respuesta.Message = "Lista de TipoProducto";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = null;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }
        public async Task<BasicResponse<TipoProducto>> AgregarTipoProducto(TipoProducto tipoProducto)
        {
            BasicResponse<TipoProducto> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await TipoProductoEntity.AgregarTipoProducto(tipoProducto);
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
        public async Task<BasicResponse<TipoProducto>> GetTipoProductoId(int id)
        {
            BasicResponse<TipoProducto> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await TipoProductoEntity.GetTipoProductoId(id);
                respuesta.Message = "TipoProducto";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }
        public async Task<BasicResponse<int>> ActualizarTipoProducto(TipoProducto tipoProducto)
        {
            BasicResponse<int> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await TipoProductoEntity.ActualizarTipoProducto(tipoProducto);
                respuesta.Message = "TipoProducto Actualizado";
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
