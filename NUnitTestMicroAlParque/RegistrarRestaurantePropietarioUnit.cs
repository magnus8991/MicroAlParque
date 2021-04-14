using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Entidad;
using MicroAlParque.Models;
using Logica;
using Datos;
using Microsoft.EntityFrameworkCore;

namespace NUnitTestMicroAlParque
{
    public class RegistrarRestaurantePropietarioUnit
    {
        public ServicioRestaurante servicio { get; set; }
        public Restaurante Restaurante { get; set; }
        public Propietario Propietario { get; set; }
        
        private readonly MicroAlParqueContext _context;
        public RegistrarRestaurantePropietarioUnit(MicroAlParqueContext context)
        {
            _context = context;
            servicio = new ServicioRestaurante(_context);
        }

        [SetUp]
        public void Setup()
        {
            Restaurante = new Restaurante();
            Propietario = new Propietario();
        }

        [TestCase("1065808199", "Eleacith", "Mandon", "Arengas", "Masculino", 26, "HT34422755GH", "Doña Juana")]
        [TestCase("1065808199", "Juan Carlos", "Sanchez", "Pertuz", "Masculino", 122, "H6567", "Sicarare")]
        [TestCase("106580819999", "Juana", "De Arco", "Arengas", "Femenino", 26, "HT65445GH67", "El Pescadito")]
        [Test]
        public void RegisterRestaurantUnit(string cedula, string nombres, string primerApellido, string segundoApellido, string sexo, int edad,
            string nit, string nombre)
        {
            Propietario = new Propietario
            {
                Identificacion = cedula,
                Nombres = nombres,
                PrimerApellido = primerApellido,
                SegundoApellido = segundoApellido,
                Edad = edad,
                Sexo = sexo
            };
            Restaurante = new Restaurante
            {
                NIT = nit,
                Nombre = nombre,
                Propietario = Propietario

            };
            var respuesta = servicio.Guardar(new Restaurante { NIT = Restaurante.NIT, Nombre = Restaurante.Nombre,
                Propietario = Restaurante.Propietario });
            Assert.AreEqual(false, respuesta.Error);
        }
    }
}