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
    public class Detalle_ComprasLogic
    {
        private Detalle_ComprasEntity Detalle_ComprasEntity;
        public Detalle_ComprasLogic(string StringConnection)
        {
            Detalle_ComprasEntity = new Detalle_ComprasEntity(StringConnection);
        }
        public async Task<BasicResponse<List<Detalle_Compras>>> GetListaDetalle_Compras()
        {
            BasicResponse<List<Detalle_Compras>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await Detalle_ComprasEntity.GetListaDetalle_Compras();
                respuesta.Message = "Lista de Detalle_Compras";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = null;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<Detalle_Compras>> AgregarDetalle_Compras(Detalle_Compras detalleCompra)
        {
            BasicResponse<Detalle_Compras> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await Detalle_ComprasEntity.AgregarDetalle_Compras(detalleCompra);
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

        public async Task<BasicResponse<Detalle_Compras>> GetDetalle_CompraId(int id)
        {
            BasicResponse<Detalle_Compras> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await Detalle_ComprasEntity.GetDetalle_CompraId(id);
                respuesta.Message = "Detalle_Compra";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<int>> ActualizarDetalle_Compra(Detalle_Compras detalleCompra)
        {
            BasicResponse<int> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await Detalle_ComprasEntity.ActualizarDetalle_Compra(detalleCompra);
                respuesta.Message = "Detalle_Compra Actualizado";
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
