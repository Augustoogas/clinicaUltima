using Dominio.Entidades;
using Dominio.Repositorios;
namespace Persistencia_de_Datos
{
        public class DoctorRepositorioEnMemoria : DoctorRepositorio 
        {
            private List<Doctor> doctores = new List<Doctor>();

            public List<Doctor> Listar()
            {
                return this.doctores;
            }

            public void Grabar(Doctor doctor)
            {
                this.doctores.Add(doctor);
            }

            public void Editar(Doctor doctor, Guid id)
            {
            int posicionObjeto = doctores.FindIndex(d => d.Id() == id);

            if (posicionObjeto >= 0)
                {
                doctores[posicionObjeto].ActualizarNombre(doctor.Nombre());
                doctores[posicionObjeto].ActualizarApellido(doctor.Apellido());
                doctores[posicionObjeto].ActualizarFechaIngreso(doctor.FechaIngreso());
                doctores[posicionObjeto].ActualizarEstado(doctor.GetEstado());
                }
            }

        public void Eliminar(Guid id)
        {
            int posicionObjeto = doctores.FindIndex(d => d.Id() == id);
            if (posicionObjeto >= 0)
            {
                // Eliminación lógica
                doctores[posicionObjeto].Borrar();
            
                //  Eliminación Física  
                //  doctores.RemoveAt(posicionObjeto);
            }
        }
    }
}