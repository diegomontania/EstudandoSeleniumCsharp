using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaMobile : IDisposable /*implementa IDisposable*/
    {
        private readonly IWebDriver driver;

        public AoNavegarParaMobile()
        {
            //cria 'options' e 'deviceSettings' para setar o modo mobile e passa no construtor
            //quando o teste for gerado, iniciará o navegador em modo "mobile"

            //cria o devicessetings, ou seja, responsável pelas configurações do 'emulador mobile'
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 400;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";

            //seta as opções do emulador mobile no chrome driver e habilita o emulador
            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);

            //adiciona ao construtor da classe as options que por sua vez adicionam o deviceSettings
            //responsavel pelo emulador
            this.driver = new ChromeDriver(TestHelper.PastaDoExecutavel(), options);
        }

        [Fact]
        public void DadoALargura400DeveMostrarMenuMobile()
        {
            //arrange
            var homeNaoLogadaPageObjects = new HomeNaoLogadaPageObjects(driver);

            //act
            homeNaoLogadaPageObjects.Visitar();

            //assert
            Assert.True(homeNaoLogadaPageObjects.MenuNaoLogadoPageObjects.MenuMobileVisivel);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
