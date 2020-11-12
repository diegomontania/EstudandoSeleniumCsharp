using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private readonly IWebDriver driver;

        public AoEfetuarLogin(TesteFixtures fixtures)
        {
            this.driver = fixtures.Driver;
        }

        [Fact]
        public void DadoInsercaoDeLoginESenhaNoFormularioDeLogin()
        {
            //arranje
            //vindo do driver
            var loginPageObjects = new LoginPageObjects(driver);
            loginPageObjects.VisitarUsandoUrlPadrao();

            //act
            loginPageObjects.PreencheLogin("fulano@example.org", "123");
            loginPageObjects.SubmeteFormulario();

            //assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Theory]
        [InlineData("", "123")]
        [InlineData("diego", "")]
        [InlineData("diego@email.com", "")]
        public void DadoCredenciaisInvalidasDeLoginESenhaNoFormularioDeLoginDeveContinuarNaMesmaPagina(string emailLogin, string senha)
        {
            //arranje
            //vindo do driver
            var loginPageObjects = new LoginPageObjects(driver);
            loginPageObjects.VisitarUsandoUrlPadrao();

            //act
            loginPageObjects.PreencheLogin(emailLogin, senha);
            loginPageObjects.SubmeteFormulario();

            //assert
            Assert.DoesNotContain("Dashboard", driver.Title);
        }
    }
}
