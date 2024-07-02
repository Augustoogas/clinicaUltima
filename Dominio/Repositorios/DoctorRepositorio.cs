using Dominio.Entidades;

namespace Dominio.Repositorios
{
    public interface DoctorRepositorio
    {
        List<Doctor> Listar();
        void Grabar(Doctor doctor);
        void Editar(Doctor doctor, Guid id);
        void Eliminar(Guid id);
    }
}
