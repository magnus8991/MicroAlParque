using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestMicroAlParque
{
    public class RegistrarRestaurante_Propietario
    {
        public IWebDriver driver { get; set; }
        ChromeOptions options { get; set; }

        [SetUp]
        public void Setup()
        {
            options = new ChromeOptions();
            options.AddArgument("--ignore-certificate-errors");
            driver = new ChromeDriver(@"F:\Escritorio\chromedriver_win32", options);
            driver.Navigate().GoToUrl("https://localhost:5001/login/false");
        }

        [TestCase("1003258091", "Diego", "Mandon", "Arengas", "Masculino", 22, "HT65447755GH67", "Cataratas", "Principal", 
            "mz 8 cs 15 Villa Jaidith", "3015909205")]
        [TestCase("1003258091", "Juan Carlos", "Sanchez", "Pertuz", "Masculino", 22, "H6567", "Sicarare", "Principal",
            "mz 8 cs 15 Villa Jaidith", "30159005")]
        [TestCase("100325801899", "Juana", "De Arco", "Arengas", "Femenino", 22, "HT65445GH67", "El Pescadito", "Principal",
            "mz 8 cs 15 Villa Jaidith", "3015900563")]
        [Test]
        public void RegisterRestaurant(string cedula, string nombres, string primerApellido, string segundoApellido, string sexo, int edad,
            string nit, string nombre, string nombreSede, string direccion, string telefono)
        {
            IWebElement txtUsuario = driver.FindElement(By.Name("nombreUsuario"));
            txtUsuario.SendKeys("admin");
            IWebElement txtContrasena = driver.FindElement(By.Name("contrasena"));
            txtContrasena.SendKeys("11014221dM");
            IWebElement btnLogin = driver.FindElement(By.Name("btnLogin"));
            btnLogin.Click();
            IWebElement btnRestaurantes = driver.FindElement(By.Name("btnRestaurantes"));
            btnRestaurantes.Click();
            IWebElement btnAddRestaurante = driver.FindElement(By.ClassName("addRestaurante"));
            btnAddRestaurante.Click();
            IWebElement txtCedula = driver.FindElement(By.Name("identificacion"));
            txtCedula.SendKeys(cedula);
            IWebElement txtNombres = driver.FindElement(By.Name("nombres"));
            txtNombres.SendKeys(nombres); 
            IWebElement txtPrimerApellido = driver.FindElement(By.Name("primerApellido"));
            txtPrimerApellido.SendKeys(primerApellido);
            IWebElement txtSegundoApellido = driver.FindElement(By.Name("segundoApellido"));
            txtSegundoApellido.SendKeys(segundoApellido);
            IWebElement txtSexo = driver.FindElement(By.Name("sexo"));
            txtSexo.SendKeys(sexo);
            IWebElement txtEdad = driver.FindElement(By.Name("edad"));
            txtEdad.SendKeys(edad.ToString());
            IWebElement txtBtnRestaurante = driver.FindElement(By.Id("ngb-nav-1"));
            txtBtnRestaurante.Click();
            IWebElement txtNit = driver.FindElement(By.Name("NIT"));
            txtNit.SendKeys(nit);
            IWebElement txtNombreRestaurante = driver.FindElement(By.Name("nombre"));
            txtNombreRestaurante.SendKeys(nombre);
            IWebElement txtBtnSede = driver.FindElement(By.Name("addSede"));
            txtBtnSede.Click();
            IWebElement txtNombreSede = driver.FindElement(By.Name("nombreSede"));
            txtNombreSede.SendKeys(nombreSede);
            IWebElement txtDireccion = driver.FindElement(By.Name("direccion"));
            txtDireccion.SendKeys(direccion);
            IWebElement txtTelefono = driver.FindElement(By.Name("telefono"));
            txtTelefono.SendKeys(telefono);
            IWebElement btnAgregarSede = driver.FindElement(By.Name("agregar"));
            btnAgregarSede.Click();
            IWebElement btnAgregarRestaurante = driver.FindElement(By.Name("registrar"));
            btnAgregarRestaurante.Click();

        }
    }
}