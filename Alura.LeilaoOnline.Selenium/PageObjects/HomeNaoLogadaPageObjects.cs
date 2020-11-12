using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class HomeNaoLogadaPageObjects
    {
        private IWebDriver driver;
        public MenuNaoLogadoPageObjects MenuNaoLogadoPageObjects { get; set; }

        public HomeNaoLogadaPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            MenuNaoLogadoPageObjects = new MenuNaoLogadoPageObjects(driver);
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }
    }
}
