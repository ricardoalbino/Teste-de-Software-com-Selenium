using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Selenium.Tests.Testes
{
    [TestFixture]
   public class UsuarioSystemTest
    {
        [Test]
        public void deveCadastrarUsuario()
        {
            
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://localhost:63883/Usuarios/Index");

            // clique no link - Novo Usuario para levar para pagina de cadastro
            driver.FindElement(By.LinkText("Novo Usuario")).Click();

            // encontrando ambos elementos na pagina
            IWebElement campoNome = driver.FindElement(By.Name("nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("email"));
            IWebElement btnSalvar = driver.FindElement(By.Name("btnSalvar"));

            campoNome.SendKeys("Cadu Albino");
            campoEmail.SendKeys("cadu@hotmail.com");

            btnSalvar.Click();

           
            //Teste Unitario - NUnit
            bool encontrouNome = driver.PageSource.Contains("Cadu Albino");
            bool encontrouEmail = driver.PageSource.Contains("cadu@hotmail.com");

            Assert.IsTrue(encontrouNome);
            Assert.IsTrue(encontrouEmail);

            

            driver.Close();
            driver.FindElement(By.LinkText("Lista de Usuarios")).Click();


        }
    }
}
