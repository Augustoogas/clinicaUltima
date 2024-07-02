using Aplicacion.DTO;

namespace Aplicacion.Servicios
{
    public interface IDoctorServicio
    {
        List<DoctorDTO> ListarDoctores();
        void RegistrarDoctor(DoctorDTO doctorDTO);
        void ActualizarDoctor(Guid Id, DoctorDTO doctorDTO);
        void EliminarDoctor(Guid Id);
    }
}
