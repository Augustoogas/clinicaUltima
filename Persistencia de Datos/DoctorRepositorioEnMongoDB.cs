using Dominio.Entidades;
using Dominio.Repositorios;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace _04_Persistencia_de_datos.MongoDBConnector
{
    public class DoctorRepositorioMongoDB : DoctorRepositorio
    {
        private readonly IMongoCollection<Doctor> collection;

        public DoctorRepositorioMongoDB()
        {
            // Configurar la conexión a MongoDB
            MongoDBConnectionSingleton mongoSingleton = MongoDBConnectionSingleton.Instance("mongodb://localhost:27017", "Doctor");
            var client = mongoSingleton.GetClient();
            var database = mongoSingleton.GetDatabase();

            // Obtener la colección de doctores
            collection = database.GetCollection<Doctor>("doctor");
        }

        public void Editar(Doctor doctor, Guid id)
        {
            var filter = Builders<Doctor>.Filter.Eq(d => d.Id(), id);
            var update = Builders<Doctor>.Update
                .Set(d => d.Nombre, doctor.Nombre)
                .Set(d => d.Apellido, doctor.Apellido)
                .Set(d => d.FechaIngreso, doctor.FechaIngreso)
                .Set(d => d.GetEstado, doctor.GetEstado);

            collection.UpdateOne(filter, update);
        }

        public void Eliminar(Guid id)
        {
            var filter = Builders<Doctor>.Filter.Eq(d => d.Id(), id);
            collection.DeleteOne(filter);
        }

        public void Grabar(Doctor doctor)
        {
            collection.InsertOne(doctor);
        }

        public List<Doctor> Listar()
        {
            return collection.Find(_ => true).ToList();
        }
    }
}
