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
    public class ComprasLogic
    {
        private ComprasEntity ComprasEntity;
        public ComprasLogic(string StringConnection)
        {
            ComprasEntity = new ComprasEntity(StringConnection);
        }
        public async Task<BasicResponse<List<Compras>>> GetListaCompras()
        {
            BasicResponse<List<Compras>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await ComprasEntity.GetListaCompras();
                respuesta.Message = "Lista de Compras";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = null;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<Compras>> AgregarCompra(Compras compras)
        {
            BasicResponse<Compras> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await ComprasEntity.AgregarCompra(compras);
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

        public async Task<BasicResponse<Compras>> GetCompraId(int id)
        {
            BasicResponse<Compras> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await ComprasEntity.GetCompraId(id);
                respuesta.Message = "Compra";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<int>> ActualizarCompra(Compras compras)
        {
            BasicResponse<int> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await ComprasEntity.ActualizarCompra(compras);
                respuesta.Message = "Compra Actualizada";
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
