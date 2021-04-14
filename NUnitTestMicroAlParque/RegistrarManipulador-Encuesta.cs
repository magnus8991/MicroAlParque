using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestMicroAlParque
{
    public class RegistrarManipulador_Encuesta
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

        [TestCase("1003258091", "Diego", "Mandon", "Arengas", "Masculino", 22, "Colombia", "Soltero", "Pregrado",
            "lorem ipsum lala sepe samalahalem", "lorem ipsum lala sepe samalahalem", "lorem ipsum lala sepe samalahalem")]
        [TestCase("1003258091", "Diego", "Mandon", "Perez", "Masculino", 22, "Colombia", "Soltero", "Pregrado",
            "lorem ipsum lala sepe samalahalem", "lorem ipsum lala sepe samalahalem", "lorem ipsum lala sepe samalahalem")]
        [TestCase("100325809163", "Diego", "Mandon", "Arengas", "Masculino", 23, "Colombia", "Soltero", "Pregrado",
            "lorem ipsum lala sepe samalahalem", "lorem ipsum lala sepe samalahalem", "lorem ipsum lala sepe samalahalem jejejjek " +
            "lorem ipsum lala sepe samalahalem jejejjek lorem ipsum lala sepe samalahalem jejejjek lorem ipsum lala sepe samalahalem jejejjek " +
            "lorem ipsum lala sepe samalahalem jejejjek lorem ipsum lala sepe samalahalem jejejjek lorem ipsum lala sepe samalahalem jejejjek ")]
        [Test]
        public void RegisterManipulador(string cedula, string nombres, string primerApellido, string segundoApellido, string sexo, int edad,
            string paisDeProcedencia, string estadoCivil, string nivelEducativo, string pregunta3, string pregunta4, string pregunta10)
        {
            driver.FindElement(By.Name("nombreUsuario")).SendKeys("admin");
            driver.FindElement(By.Name("contrasena")).SendKeys("11014221dM");
            driver.FindElement(By.Name("btnLogin")).Click();
            driver.FindElement(By.Name("btnRestaurantes")).Click();
            driver.FindElement(By.Name("btnSedes")).Click();
            driver.FindElement(By.Name("btnManipuladores")).Click();
            driver.FindElement(By.Name("AddManipulador")).Click();
            driver.FindElement(By.Name("identificacion")).SendKeys(cedula);
            driver.FindElement(By.Name("sexo")).SendKeys(sexo);
            driver.FindElement(By.Name("edad")).SendKeys(edad.ToString());
            driver.FindElement(By.Name("nombres")).SendKeys(nombres);
            driver.FindElement(By.Name("primerApellido")).SendKeys(primerApellido);
            driver.FindElement(By.Name("segundoApellido")).SendKeys(segundoApellido);
            driver.FindElement(By.Name("paisDeProcedencia")).SendKeys(paisDeProcedencia);
            driver.FindElement(By.Name("estadoCivil")).SendKeys(estadoCivil);
            driver.FindElement(By.Name("nivelEducativo")).SendKeys(nivelEducativo);
            driver.FindElement(By.Name("btnNext1")).Click();
            driver.FindElement(By.Name("pregunta3")).SendKeys(pregunta3);
            driver.FindElement(By.Name("pregunta4")).SendKeys(pregunta4);
            driver.FindElement(By.Id("mat-radio-2")).Click();
            driver.FindElement(By.Id("mat-radio-5")).Click();
            driver.FindElement(By.Id("mat-radio-8")).Click();
            driver.FindElement(By.Id("mat-radio-11")).Click();
            driver.FindElement(By.Name("btnNext2")).Click();
            driver.FindElement(By.Name("pregunta10")).SendKeys(pregunta10);
            driver.FindElement(By.Id("mat-radio-14")).Click();
            driver.FindElement(By.Id("mat-radio-17")).Click();
            driver.FindElement(By.Id("mat-radio-20")).Click();
            driver.FindElement(By.Id("mat-radio-23")).Click();
            driver.FindElement(By.Id("mat-radio-26")).Click();
            driver.FindElement(By.Name("btnNext3")).Click();
            driver.FindElement(By.Id("cdk-step-label-0-3")).Click();
            driver.FindElement(By.Id("mat-radio-29")).Click();
            driver.FindElement(By.Id("mat-radio-32")).Click();
            driver.FindElement(By.Id("mat-radio-35")).Click();
            driver.FindElement(By.Id("mat-radio-38")).Click();
            driver.FindElement(By.Name("registrarManipulador")).Click();

        }
    }
}