using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private readonly IWebDriver driver;

        public AoEfetuarLogout(TesteFixtures fixtures)
        {
            this.driver = fixtures.Driver;
        }

        [Fact]
        public void DadoLogoutValidoDeveIrParaHomeNaoLogada()
        {
            //arranje - efetua login
            var loginPageObjects = new LoginPageObjects(driver);
            loginPageObjects.EfetuarLoginComEmailESenha("fulano@example.org", "123");

            //act - efetuar logout
            var logoutPageObjects = new DashboardInteressadaPageObjects(driver);
            logoutPageObjects.MenuLogado.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
