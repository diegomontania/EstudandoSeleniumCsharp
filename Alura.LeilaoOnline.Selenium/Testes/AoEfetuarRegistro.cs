using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private readonly IWebDriver driver;

        public AoEfetuarRegistro(TesteFixtures fixtures)
        {
            driver = fixtures.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arange - dado chrome aberto, página inicial do sistema de leilões
            //dado de registro válido
            var registroPageObjects = new RegistroPageObjects(driver);
            registroPageObjects.VisitarUsandoUrlPadrao();

            //act - efetuo o registro
            registroPageObjects.PreencheFormulario("diego", "diego@diego.com.br", "123", "123");

            //assert - ser direcionado para uma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("diego", "", "123")]
        [InlineData("diego", "a", "1")]
        [InlineData("a", "", "")]
        public void DadoInformacoesInvalidasDeveContinuarNaHome(string nome, string email, string senha)
        {
            //arange - dado chrome aberto, página inicial do sistema de leilões
            //dado de registro válido
            var registroPageObjects = new RegistroPageObjects(driver);
            registroPageObjects.VisitarUsandoUrlPadrao();

            //act - efetuo o registro
            registroPageObjects.PreencheFormulario(nome, email, senha, senha);

            //assert - ser direcionado para uma página de agradecimento
            Assert.Contains("Registre-se", driver.PageSource);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arange
            var registroPageObjects = new RegistroPageObjects(driver);
            registroPageObjects.VisitarUsandoUrlPadrao();

            //act
            registroPageObjects.PreencheFormulario("", "diego", "", "");

            //Assert
            Assert.Equal("Please enter a valid email address.", registroPageObjects.EmailMensagemDeErro());  /*checa se o elemento está sendo exibido*/
        }
    }
}
