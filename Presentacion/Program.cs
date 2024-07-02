using Aplicacion.DTO;
using Aplicacion.Servicios;
using Dominio.Value_Object;
using Persistencia_de_Datos;
using Dominio.Repositorios;
using System;
using _04_Persistencia_de_datos;
using _04_Persistencia_de_datos.MongoDBConnector;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear instancia del repositorio en memoria
            // var doctorRepositorio = new DoctorRepositorioEnMemoria();
            var doctorRepositorio = new DoctorRepositorioSQL();
           // var doctorRepositorio = new DoctorRepositorioMongoDB();



            // Crear instancia del servicio de doctores
            var doctorServicio = new DoctorServicio(doctorRepositorio);

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n==== Menú de Doctores ====");
                Console.WriteLine("1. Listar Doctores");
                Console.WriteLine("2. Registrar Doctor");
                Console.WriteLine("3. Actualizar Doctor");
                Console.WriteLine("4. Eliminar Doctor");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListarDoctores(doctorServicio);
                        break;
                    case "2":
                        RegistrarDoctor(doctorServicio);
                        break;
                    case "3":
                        ActualizarDoctor(doctorServicio);
                        break;
                    case "4":
                        EliminarDoctor(doctorServicio);
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        private static void ListarDoctores(IDoctorServicio doctorServicio)
        {
            Console.WriteLine("\n==== Lista de Doctores ====");
            var doctores = doctorServicio.ListarDoctores();
            foreach (var doctor in doctores)
            {
                Console.WriteLine($"ID: {doctor.Id}\nNombre: {doctor.Nombre}\nApellido: {doctor.Apellido}\nFecha de Ingreso: {doctor.FechaIngreso}\nEstado: {doctor.Estado}\n");
            }
        }

        private static void RegistrarDoctor(IDoctorServicio doctorServicio)
        {
            Console.WriteLine("\n==== Registrar Nuevo Doctor ====");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Fecha de Ingreso (yyyy-MM-dd): ");
            DateTime fechaIngreso;
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaIngreso))
            {
                Console.WriteLine("Formato de fecha incorrecto. Intente de nuevo.");
                Console.Write("Fecha de Ingreso (yyyy-MM-dd): ");
            }
            Console.Write("Estado (Activo/Inactivo): ");
            Estado.EstadoEnum estadoEnum;
            while (!Enum.TryParse(Console.ReadLine(), true, out estadoEnum) || !Enum.IsDefined(typeof(Estado.EstadoEnum), estadoEnum))
            {
                Console.WriteLine("Estado no válido. Intente de nuevo.");
                Console.Write("Estado (Activo/Inactivo): ");
            }
            Estado estado = new Estado(estadoEnum);

            DoctorDTO nuevoDoctor = new DoctorDTO(Guid.NewGuid(), nombre, apellido, fechaIngreso, estado);
            doctorServicio.RegistrarDoctor(nuevoDoctor);
            Console.WriteLine("Doctor registrado exitosamente.");
        }

        private static void ActualizarDoctor(IDoctorServicio doctorServicio)
        {
            Console.WriteLine("\n==== Actualizar Doctor ====");
            Console.Write("Ingrese el ID del doctor a actualizar: ");
            Guid id;
            while (!Guid.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID no válido. Intente de nuevo.");
                Console.Write("Ingrese el ID del doctor a actualizar: ");
            }

            Console.Write("Nuevo Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nuevo Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Nueva Fecha de Ingreso (yyyy-MM-dd): ");
            DateTime fechaIngreso;
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaIngreso))
            {
                Console.WriteLine("Formato de fecha incorrecto. Intente de nuevo.");
                Console.Write("Nueva Fecha de Ingreso (yyyy-MM-dd): ");
            }
            Console.Write("Nuevo Estado (Activo/Inactivo): ");
            Estado.EstadoEnum estadoEnum;
            while (!Enum.TryParse(Console.ReadLine(), true, out estadoEnum) || !Enum.IsDefined(typeof(Estado.EstadoEnum), estadoEnum))
            {
                Console.WriteLine("Estado no válido. Intente de nuevo.");
                Console.Write("Nuevo Estado (Activo/Inactivo): ");
            }
            Estado estado = new Estado(estadoEnum);

            DoctorDTO doctorActualizado = new DoctorDTO(id, nombre, apellido, fechaIngreso, estado);
            doctorServicio.ActualizarDoctor(id, doctorActualizado);
            Console.WriteLine("Doctor actualizado exitosamente.");
        }

        private static void EliminarDoctor(IDoctorServicio doctorServicio)
        {
            Console.WriteLine("\n==== Eliminar Doctor ====");
            Console.Write("Ingrese el ID del doctor a eliminar: ");
            Guid id;
            while (!Guid.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID no válido. Intente de nuevo.");
                Console.Write("Ingrese el ID del doctor a eliminar: ");
            }

            doctorServicio.EliminarDoctor(id);
            Console.WriteLine("Doctor eliminado exitosamente.");
        }
    }
}
