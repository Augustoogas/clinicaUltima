
using Dominio.Entidades;
using Dominio.Repositorios;
using Dominio.Value_Object;
using Persistencia_de_Datos.SQLConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _04_Persistencia_de_datos
{
    public class DoctorRepositorioSQL : DoctorRepositorio
    {
        private SqlConnection connection;

        public DoctorRepositorioSQL()
        {
            SQLConnectionSingleton dbSingleton = SQLConnectionSingleton.Instance(
                    "GCX-PC",
                    "Prueba",
                    "True"
                );

            this.connection = dbSingleton.GetConnection();
        }

        public void Editar(Doctor doctor, Guid id)
        {
            using (SqlCommand comando = new SqlCommand(
              "UPDATE Doctor SET nombre=@nombre, apellido=@apellido, fechaIngreso=@fechaIngreso, estado=@estado WHERE id=@id",
              this.connection
            ))
            {
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", doctor.Nombre());
                comando.Parameters.AddWithValue("@apellido", doctor.Apellido());
                comando.Parameters.AddWithValue("@fechaIngreso", doctor.FechaIngreso());
                comando.Parameters.AddWithValue("@estado", doctor.GetEstado().GetValor().ToString());
                comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(Guid id)
        {
            using (SqlCommand comando = new SqlCommand(
              "DELETE FROM Doctor WHERE id=@id",
              this.connection
            ))
            {
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
        }

        public void Grabar(Doctor doctor)
        {
            using (SqlCommand comando = new SqlCommand(
               "INSERT INTO Doctor (id, nombre, apellido, fechaIngreso, estado) VALUES (@id, @nombre, @apellido, @fechaIngreso, @estado)",
               this.connection
            ))
            {
                comando.Parameters.AddWithValue("@id", doctor.Id());
                comando.Parameters.AddWithValue("@nombre", doctor.Nombre());
                comando.Parameters.AddWithValue("@apellido", doctor.Apellido());
                comando.Parameters.AddWithValue("@fechaIngreso", doctor.FechaIngreso());
                comando.Parameters.AddWithValue("@estado", doctor.GetEstado().GetValor().ToString());
                comando.ExecuteNonQuery();
            }
        }

        public List<Doctor> Listar()
        {
            List<Doctor> doctores = new List<Doctor>();
            using (SqlCommand command = new SqlCommand(
                "SELECT id, nombre, apellido, fechaIngreso, estado FROM Doctor",
                this.connection
            ))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid id = reader.GetGuid(0);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        DateTime fechaIngreso = reader.GetDateTime(3);
                        Estado.EstadoEnum estado = (Estado.EstadoEnum)Enum.Parse(typeof(Estado.EstadoEnum), reader.GetString(4));

                        Doctor doctor = new Doctor(id, nombre, apellido, fechaIngreso, new Estado(estado));
                        doctores.Add(doctor);
                    }
                }
            }
            return doctores;
        }
    }
}
