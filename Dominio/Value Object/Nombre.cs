namespace Dominio.Value_Object
{
    public class Nombre
    {
        private string valor;
        public Nombre(string valor)
        {
            this.valor = valor;
            this.debeContenerNombre(valor);
        }
        private void debeContenerNombre(string valor)
        {
            if (valor == "")
            {
                throw new Exception("El nombre debe tener un valor, no puede estar vacío.");
            }
            if (valor.Length < 2)
            {
                throw new Exception("El nombre debe tener al menos 2 caracteres.");
            }
            if (valor.Length > 50)
            {
                throw new Exception("El nombre no puede tener más de 50 caracteres.");
            }
        }
        public string GetValor()
        {
            return this.valor;
        }
    }
}
