using Dominio.Entidades;
using Dominio.Value_Object;

namespace Aplicacion.DTO
{
    public class DoctorDTO
    {
        public DoctorDTO(Guid id, string nombre, string apellido, DateTime fechaIngreso, Estado estado)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaIngreso = fechaIngreso;
            Estado = estado.GetValor(); // Aquí accedemos al valor Enum dentro de Estado
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Estado.EstadoEnum Estado { get; set; }

        public static DoctorDTO FromDoctorEntity(Doctor doctor)
        {
            return new DoctorDTO(
                doctor.Id(), doctor.Nombre(), doctor.Apellido(), doctor.FechaIngreso(), doctor.GetEstado());
        }
    }
}