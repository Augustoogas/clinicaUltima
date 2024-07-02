using Dominio.Entidades;

namespace Dominio.Repositorios
{
    public interface DoctorRepositorio
    {
        List<Doctor> listar();
        void grabar(Doctor doctor);
        void editar(Doctor doctor, Guid id);gc
        void eliminar(Guid id);
    }
}
