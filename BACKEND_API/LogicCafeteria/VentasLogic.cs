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
    public class VentasLogic
    {
        private VentasEntity VentasEntity;
        public VentasLogic(string StringConnection)
        {
            VentasEntity = new VentasEntity(StringConnection);
        }
        public async Task<BasicResponse<List<Ventas>>> GetListaVentas()
        {
            BasicResponse<List<Ventas>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await VentasEntity.GetListaVentas();
                respuesta.Message = "Lista de Ventas";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = null;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }
        public async Task<BasicResponse<Ventas>> AgregarVenta(Ventas venta)
        {
            BasicResponse<Ventas> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await VentasEntity.AgregarVenta(venta);
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
        public async Task<BasicResponse<Ventas>> GetVentaId(int id)
        {
            BasicResponse<Ventas> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await VentasEntity.GetVentaId(id);
                respuesta.Message = "Venta";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }
        public async Task<BasicResponse<int>> ActualizarVenta(Ventas venta)
        {
            BasicResponse<int> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await VentasEntity.ActualizarVenta(venta);
                respuesta.Message = "Venta Actualizada";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = 0;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<List<Ventas>>> GetVentasPorMes(int year, int month)
        {
            BasicResponse<List<Ventas>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await VentasEntity.GetVentasPorMes(year, month);
                respuesta.Message = "Ventas del mes obtenidas correctamente.";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

        public async Task<BasicResponse<List<Ventas>>> GetVentasPorSemana(int year, int week)
        {
            BasicResponse<List<Ventas>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await VentasEntity.GetVentasPorSemana(year, week);
                respuesta.Message = "Ventas de la semana obtenidas correctamente.";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }

    }
}
