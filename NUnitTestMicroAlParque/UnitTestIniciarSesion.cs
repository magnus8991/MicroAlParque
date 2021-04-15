using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestMicroAlParque
{
    public class UnitTestIniciarSesion
    {
        public IWebDriver webDriver { get; set; }
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver(@"D:\Descargas\chromedriver");
            webDriver.Navigate().GoToUrl("https://localhost:44376/");
        }

        [TestCase("","")]
        [Test]
        public void inicioSesionTest(string nombreUsuario, string contrasena)
        {
            IWebElement inputUsuario = webDriver.FindElement(By.Name("nombreUsuario"));
            IWebElement inputConstrasena = webDriver.FindElement(By.Name("contrasena"));
            inputUsuario.SendKeys(nombreUsuario);
            inputConstrasena.SendKeys(contrasena);
            IWebElement btnIniciarSesion = webDriver.FindElement(By.Name("btnIniciarSesion"));

            Assert.Pass();
        }
    }
}