using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    //classe responsavel pelo setup antes da execução, 
    //e limpeza de recursos (teardown) dos testes
    public class TesteFixtures : IDisposable
    {
        public IWebDriver Driver { get; set; }

        //setup - antes de iniciar o teste
        public TesteFixtures()
        {
            //cria instancia do webdriver
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel());

            //Aumenta o limite do 'aguardar' em 10 segundos
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //teardown - após executar teste, descartando os recursos utilizando IDisposable
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
