using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private readonly IWebDriver driver;

        public AoFiltrarLeiloes(TesteFixtures fixtures)
        {
            this.driver = fixtures.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaAoEfetuarLoginDeveMostrarPainelDeResultado()
        {
            //arranje - efetua login
            var loginPageObjects = new LoginPageObjects(driver);
            loginPageObjects.EfetuarLoginComEmailESenha("fulano@example.org", "123");

            //act
            var dashboardInteressadaPageObjects = new DashboardInteressadaPageObjects(driver);
            dashboardInteressadaPageObjects.Filtro.PesquisarLeiloes(new List<string> { "Arte", "Coleções"}, "", true);

            //assert
            Assert.Contains("Resultado da pesquisa", driver.PageSource);
        }
    }
}
