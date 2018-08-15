using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Tests.Testes
{
    [TestFixture]
   public class UsuarioSystemTest
    {
        
        [Test]
        public void deveCadastrarUsuario()
        {
            //Caminho Feliz
            var driver = new ChromeDriver();
           
            driver.Navigate().GoToUrl("http://localhost:63883/Usuarios/Index");
            
            // clique no link - Novo Usuario para levar para pagina de cadastro
            driver.FindElement(By.LinkText("Novo Usuario")).Click();

            // encontrando ambos elementos na pagina
            IWebElement campoNome = driver.FindElement(By.Name("nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("email"));
            IWebElement btnSalvar = driver.FindElement(By.Name("btnSalvar"));

            campoNome.SendKeys("Ricardo Albino");
            campoEmail.SendKeys("ric@hotmail.com");

            btnSalvar.Click();

           
            //Teste Unitario - NUnit
            bool encontrouNome = driver.PageSource.Contains("Ricardo Albino");
            bool encontrouEmail = driver.PageSource.Contains("ric@hotmail.com");

            Assert.IsTrue(encontrouNome);
            Assert.IsTrue(encontrouEmail);

            driver.Close();
          
        }
       
        [Test]
        public void deveAlterarUsuario()
        {
            //Caminho Feliz
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://localhost:63883/Usuarios/Index");

            // clique no link - Editar

            int posicao = 1;
            driver.FindElements(By.LinkText("Editar"))[posicao].Click();
            

            // encontrando ambos elementos na pagina
            IWebElement campoNome = driver.FindElement(By.Name("nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("email"));

            //Limpando campos
            campoNome.Clear();
            campoEmail.Clear();

            campoNome.SendKeys("Fabio Albino");
            campoEmail.SendKeys("fabio@hotmail.com");

            campoEmail.Submit();

          

            //Teste Unitario - NUnit
            bool encontrouNome = driver.PageSource.Contains("Fabio Albino");
            bool encontrouEmail = driver.PageSource.Contains("fabio@hotmail.com");

            Assert.IsTrue(encontrouNome);
            Assert.IsTrue(encontrouEmail);

            driver.Close();

        }

        [Test]
        public void deveExcluirUsuario()
        {
            //Caminho Feliz
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://localhost:63883/Usuarios/Index");

            int posicao = 1;
            driver.FindElements(By.LinkText("Deletar"))[posicao].Click();

            //Deleta usuario
            driver.FindElement(By.TagName("form")).Submit();


            //Teste Unitario - NUnit
            bool encontrouNome = driver.PageSource.Contains("Fabio Albino");
            bool encontrouEmail = driver.PageSource.Contains("fabio@hotmail.com");

            Assert.IsFalse(encontrouNome);
            Assert.IsFalse(encontrouEmail);

            driver.Close();

        }
    }
}
