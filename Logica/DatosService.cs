using Datos;
using Entity;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class DatosService
    {
        private readonly ConnectionManager _conexion;
        private readonly DatosRepository _repositorio;

        public DatosService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new DatosRepository(_conexion);
        }

        public GuardarDatosResponse Guardar(DatosCopago datos)
        {
            try
            { 

                if(datos.ValorServicio < 0 || datos.SalarioTrabajador < 0){

                    return new GuardarDatosResponse("Error. Ni el valor del servicio ni el salario pueden ser menores de cero");

                }else{

                datos.CalcularCopago();
                _conexion.Open();
                _repositorio.Guardar(datos);
                _conexion.Close();
                return new GuardarDatosResponse(datos);
                }
            }
            catch (Exception e)
            {
                return new GuardarDatosResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<DatosCopago> ConsultarTodos()
        {
            _conexion.Open();
            List<DatosCopago> listadatos = _repositorio.ConsultarTodos();
            _conexion.Close();
            return listadatos;
        }
    }

    public class GuardarDatosResponse 
    {
        public GuardarDatosResponse(DatosCopago datos)
        {
            Error = false;
            DatosCopago = datos;
        }
        public GuardarDatosResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public DatosCopago DatosCopago { get; set; }
    }
}
