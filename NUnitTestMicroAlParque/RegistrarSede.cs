using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestMicroAlParque
{
    public class RegistrarSede
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

        [TestCase("Secundaria", "cra 24 #25-50 7 de Agosto", "3117951534")]
        [TestCase("Sede secundaria las casitas - Diego Mandon", "cra 24 #25-50 7 de Agosto", "3002834584")]
        [TestCase("Orcasitas", "calle 44 #27-30 Don Carmelo", "311795153434")]
        [Test]
        public void RegisterSede(string nombreSede, string direccion, string telefono)
        {
            IWebElement txtUsuario = driver.FindElement(By.Name("nombreUsuario"));
            txtUsuario.SendKeys("admin");
            IWebElement txtContrasena = driver.FindElement(By.Name("contrasena"));
            txtContrasena.SendKeys("11014221dM");
            IWebElement btnLogin = driver.FindElement(By.Name("btnLogin"));
            btnLogin.Click();
            IWebElement btnRestaurantes = driver.FindElement(By.Name("btnRestaurantes"));
            btnRestaurantes.Click();
            IWebElement btnSedes = driver.FindElement(By.Name("btnSedes"));
            btnSedes.Click();
            IWebElement btnAddSede = driver.FindElement(By.ClassName("addSede"));
            btnAddSede.Click();
            IWebElement txtNombreSede = driver.FindElement(By.Name("nombreSede"));
            txtNombreSede.SendKeys(nombreSede);
            IWebElement txtDireccion = driver.FindElement(By.Name("direccion"));
            txtDireccion.SendKeys(direccion);
            IWebElement txtTelefono = driver.FindElement(By.Name("telefono"));
            txtTelefono.SendKeys(telefono);
            IWebElement btnAgregarSede = driver.FindElement(By.Name("agregar"));
            btnAgregarSede.Click();

        }
    }
}