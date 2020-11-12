using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPageObjects
    {
        private readonly IWebDriver driver;
        private string classMenuMobile;

        public bool MenuMobileVisivel 
        {
            get 
            {
                var elemento = driver.FindElement(By.ClassName(classMenuMobile));
                return elemento.Displayed;
            }
        }

        public MenuNaoLogadoPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            classMenuMobile = "sidenav-trigger";
        }
    }
}
