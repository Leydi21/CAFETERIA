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
    public class ProductosLogic
    {
        private ProductosEntity ProductosEntity;
        public ProductosLogic(string StringConnection)
        {
            ProductosEntity = new ProductosEntity(StringConnection);
        }
        public async Task<BasicResponse<List<Productos>>> GetListaProductos()
        {
            BasicResponse<List<Productos>> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await ProductosEntity.GetListaProductos();
                respuesta.Message = "Lista de Productos";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Body = null;
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }
        public async Task<BasicResponse<Productos>> AgregarProducto(Productos producto)
        {
            BasicResponse<Productos> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await ProductosEntity.AgregarProducto(producto);
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
        public async Task<BasicResponse<Productos>> GetProductoId(int id)
        {
            BasicResponse<Productos> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await ProductosEntity.GetProductoId(id);
                respuesta.Message = "Producto";
            }
            catch (Exception Ex)
            {
                respuesta.Status = "Error";
                respuesta.Message = Ex.Message;
            }
            return respuesta;
        }
        public async Task<BasicResponse<int>> ActualizarProducto(Productos producto)
        {
            BasicResponse<int> respuesta = new();
            try
            {
                respuesta.Status = "Ok";
                respuesta.Body = await ProductosEntity.ActualizarProducto(producto);
                respuesta.Message = "Producto Actualizado";
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
