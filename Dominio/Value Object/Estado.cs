namespace Dominio.Value_Object
{
    public class Estado
    {
        public enum EstadoEnum
        {
            Activo,
            Inactivo
        }

        private EstadoEnum valor;

        public Estado(EstadoEnum valor)
        {
            this.valor = valor;
        }

        public EstadoEnum GetValor()
        {
            return this.valor;
        }
    }
}