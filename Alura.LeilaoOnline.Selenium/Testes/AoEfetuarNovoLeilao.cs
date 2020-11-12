using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection ("Chrome Driver")]
    public class AoEfetuarNovoLeilao
    {
        private readonly IWebDriver driver;

        public AoEfetuarNovoLeilao(TesteFixtures fixtures)
        {
            this.driver = fixtures.Driver;
        }

        [Fact]
        public void DadoInsercaoDeUmNovoLeilaoComOsCamposPreenchidos()
        {
            //arranje
            //vindo do driver
            var loginPageObjects = new LoginPageObjects(driver);
            loginPageObjects.EfetuarLoginComEmailESenha("fulano@example.org", "123");

            var novoLeilaoPageObjects = new NovoLeilaoPageObjects(driver);
            novoLeilaoPageObjects.VisitarUsandoUrlPadrao();

            //act
            novoLeilaoPageObjects.PreencheFormularioNovoLeilao("Titulo Teste", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!", 
                "1000", "C:\\images\\imagem.jpg", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));
            novoLeilaoPageObjects.SubmeteFormulario();

            //assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
