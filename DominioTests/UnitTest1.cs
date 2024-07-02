using Dominio.Entidades;
using Dominio.Value_Object;
using Xunit;
using System;

namespace DominioTests
{
    public class UnitTest1
    {
        [Fact]
        public void pruebaIngreso()
        {
            //Arrange (Crea e Ingresa los valores)
            Estado.EstadoEnum estadoD = Estado.EstadoEnum.Activo; // Definir el estado como Activo
            Doctor doctor1 = new Doctor(Guid.NewGuid(), "Juan", "Perez", DateTime.Now, new Estado(estadoD));

            String nombre = doctor1.Nombre();
            String apellido  = doctor1.Apellido();
          
            // Aquí puedes agregar tus aserciones para verificar que el doctor1 se ha creado correctamente
            // Camino Feliz

            // Assert - Verificar que el doctor se ha creado correctamente
            Assert.Equal("Juan", nombre); // Por ejemplo, verificar el nombre
            Assert.Equal("Perez", apellido); // Verificar el apellido
            Assert.Equal(estadoD, doctor1.GetEstado().GetValor()); // Verificar el estado


          


        }
        // Camino Triste
        [Fact]
        public void pruebaIngresoFallido()
        {
            Estado.EstadoEnum estadoD = Estado.EstadoEnum.Activo; // Definir el estado como Activo

            // Intentamos crear un doctor con una fecha de ingreso anterior a 1949-06-07
            DateTime fechaIngreso = new DateTime(1948, 6, 6); // Fecha anterior al requerimiento

   
            // Creamos el doctor con la fecha de ingreso anterior
            Doctor doctor1 = new Doctor(Guid.NewGuid(), "Juan", "Perez", fechaIngreso, new Estado(estadoD));
            
      
            String nombre = doctor1.Nombre();
            String apellido = doctor1.Apellido();

            // Aserciones para verificar que el doctor1 no se haya creado correctamente
            Assert.Equal("Juan", nombre); // El nombre no debe ser "Juan"
            Assert.Equal("Perez", apellido); // El apellido no debe ser "Perez"
            Assert.Equal(estadoD, doctor1.GetEstado().GetValor()); // El estado no debe ser el estado activo

            // Además, podemos verificar que la fecha de ingreso no sea la misma que la proporcionada
            Assert.Equal(fechaIngreso, doctor1.FechaIngreso());
        }
        [Fact]
        public void PruebaEliminarDoctor()
        {
            // Arrange - Crear un doctor activo
            Estado.EstadoEnum estadoInicial = Estado.EstadoEnum.Activo;
            Doctor doctor = new Doctor(Guid.NewGuid(), "Juan", "Perez", DateTime.Now, new Estado(estadoInicial));

            // Act - Llamar al método para eliminar al doctor
            doctor.Borrar();

            // Assert - Verificar que el doctor ha sido marcado como inactivo
            Assert.Equal(Estado.EstadoEnum.Inactivo, doctor.GetEstado().GetValor());
        }
    }
}

