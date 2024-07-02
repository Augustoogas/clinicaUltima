namespace Dominio.Value_Object
{
    public class Identificador
    {
        private Guid valor;
        public Identificador(Guid valor)
        {
            this.valor = valor;

        }
        public Guid GetValor()
        {
            return this.valor;
        }
    }
}
