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
    public class Detalle_VentasLogic
    {
        private Detalle_VentasEntity Detalle_VentasEntity;
        public Detalle_VentasLogic(string StringConnection)
        {
            Detalle_VentasEntity = new Detalle_VentasEntity(StringConnection);
        }
        public async Task<BasicResponse<List<Detalle_Ventas>>> GetListaDetalle_Ventas()
        {
            BasicResponse<List<Detalle_Ventas>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await Detalle_VentasEntity.GetListaDetalle_Ventas();
                respuesta.Message = "Lista de Detalle_Ventas";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = null;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<Detalle_Ventas>> AgregarDetalle_Venta(Detalle_Ventas detalleVentas)
        {
            BasicResponse<Detalle_Ventas> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await Detalle_VentasEntity.AgregarDetalle_Venta(detalleVentas);
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

        public async Task<BasicResponse<List<Detalle_Ventas>>> GetDetalle_VentaId(int id)
        {
            BasicResponse<List<Detalle_Ventas>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await Detalle_VentasEntity.GetDetallesByVentaId(id);
                respuesta.Message = "Detalle_Ventas obtenidos correctamente.";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }


        public async Task<BasicResponse<int>> ActualizarDetalle_Venta(Detalle_Ventas detalleVentas)
        {
            BasicResponse<int> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await Detalle_VentasEntity.ActualizarDetalle_Venta(detalleVentas);
                respuesta.Message = "Detalle_Venta Actualizado";
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
