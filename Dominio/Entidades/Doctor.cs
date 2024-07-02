using Dominio.Value_Object;

namespace Dominio.Entidades
{
    public class Doctor
    {
        private Identificador id;
        private Nombre nombre;
        private Apellido apellido;
        private FechaIngreso fechaIngreso;
        private Estado estado;

        public Doctor(Guid id, string nombre, string apellido, DateTime fechaIngreso, Estado estado)
        {
            this.id = new Identificador(id);
            this.nombre = new Nombre(nombre);
            this.apellido = new Apellido(apellido);
            this.fechaIngreso = new FechaIngreso(fechaIngreso);
            this.estado = estado;
        }

        public Guid Id()
        {
            return this.id.GetValor();
        }

        public string Nombre()
        {
            return this.nombre.GetValor();
        }

        public string Apellido()
        {
            return this.apellido.GetValor();
        }

        public DateTime FechaIngreso()
        {
            return this.fechaIngreso.GetValor();
        }

        public Estado GetEstado()
        {
            return this.estado;
        }

        public void ActualizarNombre(string nombre)
        {
            this.nombre = new Nombre(nombre);
        }

        public void ActualizarApellido(string apellido)
        {
            this.apellido = new Apellido(apellido);
        }

        public void ActualizarFechaIngreso(DateTime fecha)
        {
            this.fechaIngreso = new FechaIngreso(fecha);
        }

        public void ActualizarEstado(Estado nuevoEstado)
        {
            this.estado = nuevoEstado;
        }

        public void Borrar()
        {
            this.estado = new Estado(Estado.EstadoEnum.Inactivo);
        }
    }
}