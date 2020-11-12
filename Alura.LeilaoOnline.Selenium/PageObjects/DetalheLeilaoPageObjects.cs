using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPageObjects
    {
        private IWebDriver driver;
        private string IdInputValor, IdBtnOfertar, IdLanceAtual;

        public DetalheLeilaoPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            IdInputValor = "Valor";
            IdBtnOfertar = "btnDarLance";
            IdLanceAtual = "lanceAtual";
        }

        public double LanceAtual
        {
            get
            {
                var valorTexto = driver.FindElement(By.Id(IdLanceAtual)).Text;
                var valor = double.Parse(valorTexto, System.Globalization.NumberStyles.Currency);
                return Convert.ToDouble(valor);
            }
        }

        public void VisitarLeilao(int idLeilao)
        {
            driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}");
        }

        public void OfertarLance(double valor)
        {
            driver.FindElement(By.Id(IdInputValor)).Clear();
            driver.FindElement(By.Id(IdInputValor)).SendKeys(valor.ToString());
            driver.FindElement(By.Id(IdBtnOfertar)).Click();
        }
    }
}
