
/* using Dominio.Entidades;
using Persistencia_de_Datos.SQLConnector;
using System.Data.SqlClient;

namespace Persistencia_de_Datos
{
    public class DoctorRepositorioSQL
    {
        private SqlConnection connection;

        public DoctorRepositorioSQL()
        {
            SQLConnectionSingleton dbSingleton = SQLConnectionSingleton.Instance(
                    "GCX-PC",
                    "Prueba",
                    "False"
                );
            this.connection = dbSingleton.GetConnection();
        }

        public void editar(Doctor doctor, Guid id)
        {
            using (SqlCommand comando = new SqlCommand(
              "update Doctor set nombre=@nombre,apellido=@apellido,fechaIngreso=@fechaIngreso where id=@id",
              this.connection
          ))
            {
                comando.Parameters.AddWithValue("@id", doctor.Id());
                comando.Parameters.AddWithValue("@nombre", doctor.Nombre());
                comando.Parameters.AddWithValue("@apellido", doctor.Apellido());
                comando.Parameters.AddWithValue("@fechaIngreso", doctor.FechaIngreso());
                comando.ExecuteNonQuery();
            }
        }

        public void eliminar(Guid id, Doctor doctor)
        {
            using (SqlCommand comando = new SqlCommand(
              "delete from Doctor whre id=@id",
              this.connection
          ))
            {
                comando.Parameters.AddWithValue("@id", doctor.Id());
                comando.ExecuteNonQuery();
            }

        }

        public void grabar(Doctor doctor)
        {
            using (SqlCommand comando = new SqlCommand(
               "INSERT INTO Doctor (id, nombre,apellido, fechaIngreso) VALUES (@id, @nombre,@apellido, @fechaIngreso)",
               this.connection
           ))
            {
                comando.Parameters.AddWithValue("@id", doctor.Id());
                comando.Parameters.AddWithValue("@nombre", doctor.Nombre());
                comando.Parameters.AddWithValue("@apellido", doctor.Apellido());
                comando.Parameters.AddWithValue("@fechaIngreso", doctor.FechaIngreso());
                comando.ExecuteNonQuery();
            }
        }

        public List<Doctor> listar()
        {
            List<Doctor> doctores = new List<Doctor>();
            using (SqlCommand command = new SqlCommand(
                "SELECT id, nombre, apellido, fechaIngreso FROM Doctor",
                this.connection
            ))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid id = reader.GetGuid(0);
                        String nombre = reader.GetString(1);
                        String email = reader.GetString(2);
                        String apellido = reader.GetString(3);
                        DateTime fechaIngreso = reader.GetDateTime(4);

                        Doctor doctor = new Doctor(id, nombre, apellido, fechaIngreso);
                        doctores.Add(doctor);
                    }
                }
            }
            return doctores;
        }
    }
}