using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    //Collection é utilizado para compartilhar o mesmo recurso/setup entre várias classes de teste.
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private readonly IWebDriver driver;

        //setup do teste
        public AoNavegarParaHome(TesteFixtures fixtures)
        {
            //fazendo a mesma instancia do chrome ser utilizado por multiplos testes
            driver = fixtures.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arranje
            //vindo do driver

            //act
            var registroPageObjects = new RegistroPageObjects(driver);
            registroPageObjects.VisitarUsandoUrlPadrao();

            //assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arranje
            //vindo do fixtures.Driver

            //act
            var registroPageObjects = new RegistroPageObjects(driver);
            registroPageObjects.VisitarUsandoUrlPadrao();

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagensDeErro()
        {
            //arranje
            //vindo do fixtures.Driver

            //act
            var registroPageObjects = new RegistroPageObjects(driver);
            registroPageObjects.VisitarUsandoUrlPadrao();

            //assert
            var form = driver.FindElement(By.TagName("form")); /*pega tag de form*/
            var spans = form.FindElements(By.TagName("span")); /*pega todos os elementos de span*/

            //faz loop para verificar se não estão sendo exibidos
            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}
