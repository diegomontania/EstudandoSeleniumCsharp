using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TesteFixtures fixtures)
        {
            this.driver = fixtures.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //arranje - efetua login
            var loginPageObjects = new LoginPageObjects(driver);
            loginPageObjects.EfetuarLoginComEmailESenha("fulano@example.org", "123");

            var detalhePageObjects = new DetalheLeilaoPageObjects(driver);
            detalhePageObjects.VisitarLeilao(1);        /*em andamento*/

            //act
            detalhePageObjects.OfertarLance(300);

            //assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7)); /*criando wait explicito para este caso*/
            
            //aguarda X segundos se texto da página irá receber o valor de 300
            bool aguardaAparecerValorNaTela = wait.Until( drv => detalhePageObjects.LanceAtual == 300);

            Assert.True(aguardaAparecerValorNaTela);

        }
    }
}
