using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    //responsavel por facilitar a alteração de ids dos campos, 
    //facilitando a alteração caso seja necessário nem novos testes
    public class RegistroPageObjects
    {
        private IWebDriver driver;
        private string IdNome, IdEmail, IdPassword, 
            IdConfirmPassword, IdBtnRegistro, IdMensagemErro;


        public RegistroPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            IdNome = "Nome";
            IdEmail = "Email";
            IdPassword = "Password";
            IdConfirmPassword = "ConfirmPassword";
            IdBtnRegistro = "btnRegistro";
            IdMensagemErro = "Email-error";
        }

        public void VisitarUsandoUrlPadrao()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void PreencheFormulario(string nome, string email, string senha, string confirmaSenha)
        {
            driver.FindElement(By.Id(IdNome)).SendKeys(nome);
            driver.FindElement(By.Id(IdEmail)).SendKeys(email);
            driver.FindElement(By.Id(IdPassword)).SendKeys(senha);
            driver.FindElement(By.Id(IdConfirmPassword)).SendKeys(confirmaSenha);
            driver.FindElement(By.Id(IdBtnRegistro)).Click();
        }

        public string EmailMensagemDeErro()
        {
            return driver.FindElement(By.Id(IdMensagemErro)).Text;
        }
    }
}
