using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestMicroAlParque
{
    public class ActualizarRestaurante
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

        [TestCase("Restaurante Cataratas")]
        [TestCase("Restaurante Internacional - Cataratas del paraiso")]
        [TestCase("Darko")]
        [Test]
        public void ModifyRestaurant(string nombre)
        {
            IWebElement txtUsuario = driver.FindElement(By.Name("nombreUsuario"));
            txtUsuario.SendKeys("admin");
            IWebElement txtContrasena = driver.FindElement(By.Name("contrasena"));
            txtContrasena.SendKeys("11014221dM");
            IWebElement btnLogin = driver.FindElement(By.Name("btnLogin"));
            btnLogin.Click();
            IWebElement btnRestaurantes = driver.FindElement(By.Name("btnRestaurantes"));
            btnRestaurantes.Click();
            IWebElement btnAddRestaurante = driver.FindElement(By.Name("modifyRestaurante"));
            btnAddRestaurante.Click();
            IWebElement txtNombreRestaurante = driver.FindElement(By.Name("nombre"));
            txtNombreRestaurante.Clear();
            txtNombreRestaurante.SendKeys(nombre);
            IWebElement btnEditarRestaurante = driver.FindElement(By.Name("editarRestaurante"));
            btnEditarRestaurante.Click();

        }
    }
}