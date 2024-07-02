namespace Dominio.Value_Object
{
    public class FechaIngreso
    {
        private DateTime valor;

        public FechaIngreso(DateTime valor)
        {
            this.valor = valor;
            this.debeContenerFechaIngreso(valor);
        }

        private void debeContenerFechaIngreso(DateTime valor)
        {
            DateTime fechaMinima = new DateTime(1950, 1, 1);

            if (valor < fechaMinima)
            {
                throw new ArgumentException($"La fecha de ingreso no puede ser anterior a {fechaMinima.ToShortDateString()}.");
            }

            if (valor > DateTime.Now)
            {
                throw new ArgumentException("La fecha de ingreso no puede ser una fecha futura.");
            }
        }
        public DateTime GetValor()
        {
            return this.valor;
        }
    }
}
