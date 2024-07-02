using Aplicacion.DTO;
using Dominio.Entidades;
using Dominio.Repositorios;
using Dominio.Value_Object;

namespace Aplicacion.Servicios
{
    public class DoctorServicio : IDoctorServicio
    {
        private readonly DoctorRepositorio _doctorRepositorio;

        public DoctorServicio(DoctorRepositorio doctorRepositorio)
        {
            _doctorRepositorio = doctorRepositorio;
        }

        public List<DoctorDTO> ListarDoctores()
        {
            var doctores = _doctorRepositorio.Listar();
            return doctores.Select(DoctorDTO.FromDoctorEntity).ToList();
        }

        public void RegistrarDoctor(DoctorDTO doctorDTO)
        {
            var doctor = new Doctor(
                doctorDTO.Id, doctorDTO.Nombre, doctorDTO.Apellido, doctorDTO.FechaIngreso, new Estado(doctorDTO.Estado));
            _doctorRepositorio.Grabar(doctor);
        }

        public void ActualizarDoctor(Guid id, DoctorDTO doctorDTO)
        {
            var doctor = _doctorRepositorio.Listar().FirstOrDefault(d => d.Id() == id);
            if (doctor != null)
            {
                doctor.ActualizarNombre(doctorDTO.Nombre);
                doctor.ActualizarApellido(doctorDTO.Apellido);
                doctor.ActualizarFechaIngreso(doctorDTO.FechaIngreso);
                doctor.ActualizarEstado(new Estado(doctorDTO.Estado));
                _doctorRepositorio.Editar(doctor, id);
            }
            else
            {
                throw new InvalidOperationException($"Doctor con ID {id} no encontrado");
            }
        }

        public void EliminarDoctor(Guid id)
        {
            _doctorRepositorio.Eliminar(id);
        }
    }
}