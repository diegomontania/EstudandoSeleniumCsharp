using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPageObjects
    {
        private readonly IWebDriver driver;
        private string IdEmailLogin, IdSenha, IdBtnLogin;

        public LoginPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            IdEmailLogin = "Login";
            IdSenha = "Password";
            IdBtnLogin = "btnLogin";
        }

        public void EfetuarLoginComEmailESenha(string emailLogin, string senha)
        {
            VisitarUsandoUrlPadrao();
            PreencheLogin(emailLogin, senha);
            SubmeteFormulario();
        }

        public void VisitarUsandoUrlPadrao()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencheLogin(string emailLogin, string senha)
        {
            driver.FindElement(By.Id(IdEmailLogin)).SendKeys(emailLogin);
            driver.FindElement(By.Id(IdSenha)).SendKeys(senha);
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(By.Id(IdBtnLogin)).Click();
        }
    }
}
