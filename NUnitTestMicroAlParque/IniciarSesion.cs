using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestMicroAlParque
{
    public class IniciarSesion
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

        [TestCase("admin", "11014221dM")]
        [TestCase("magnus8991", "1234")]
        [TestCase("", "11014221dM")]
        [Test]
        public void LoginTest(string usuario, string contrasena)
        { 
            IWebElement txtUsuario = driver.FindElement(By.Name("nombreUsuario"));
            txtUsuario.SendKeys(usuario);
            IWebElement txtContrasena = driver.FindElement(By.Name("contrasena"));
            txtContrasena.SendKeys(contrasena);
            IWebElement btnLogin = driver.FindElement(By.Name("btnLogin"));
            btnLogin.Click();

        }
    }
}