using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class DatosRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<DatosCopago> _datos = new List<DatosCopago>();
        public DatosRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(DatosCopago datos)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Datos (IdPaciente,ValorServicio,SalarioTrabajador, Copago) 
                                        values (@IdPaciente,@ValorServicio,@SalarioTrabajador,@Copago)";
                command.Parameters.AddWithValue("@IdPaciente", datos.IdPaciente);
                command.Parameters.AddWithValue("@ValorServicio", datos.ValorServicio);
                command.Parameters.AddWithValue("@SalarioTrabajador", datos.SalarioTrabajador);
                command.Parameters.AddWithValue("@Copago", datos.Copago);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<DatosCopago> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<DatosCopago> listaDatos = new List<DatosCopago>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Datos ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DatosCopago datos = DataReaderMapToDatos(dataReader);
                        listaDatos.Add(datos);
                    }
                }
            }
            return listaDatos;
        }

        private DatosCopago DataReaderMapToDatos(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            DatosCopago datos = new DatosCopago();
            datos.IdPaciente= (string)dataReader["IdPaciente"];
            datos.ValorServicio = Convert.ToDouble(dataReader["ValorServicio"]);
            datos.SalarioTrabajador = (decimal)dataReader["SalarioTrabajador"];
            datos.Copago = Convert.ToDouble(dataReader["Copago"]);
            return datos;
        }
    }
}
