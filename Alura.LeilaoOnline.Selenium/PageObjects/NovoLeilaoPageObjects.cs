using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPageObjects
    {
        private readonly IWebDriver driver;
        private string IdTitulo, IdDescricao, IdCategoria, xPathSelecionaAutomoveis,
            IdValorInicial, IdUploadImagem, IdInicioPregao, IdFinalPregao, xPathBtnConfirmaLeilao;

        public NovoLeilaoPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            IdTitulo = "Titulo";
            IdDescricao = "Descricao";
            IdCategoria = "Categoria";
            xPathSelecionaAutomoveis = "//option[. = 'Automóveis']";
            IdValorInicial = "ValorInicial";
            IdUploadImagem = "ArquivoImagem";
            IdInicioPregao = "InicioPregao";
            IdFinalPregao = "TerminoPregao";
            xPathBtnConfirmaLeilao = "//button[@type='submit']";
        }

        public void VisitarUsandoUrlPadrao()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormularioNovoLeilao(string titulo, 
            string descricao, string valorInicial, string caminhoImagem,
            DateTime inicioPregao, DateTime finalPregao)
        {
            driver.FindElement(By.Id(IdTitulo)).SendKeys(titulo);
            driver.FindElement(By.Id(IdDescricao)).SendKeys(descricao);
            driver.FindElement(By.Id(IdCategoria)).Click();
            driver.FindElement(By.XPath(xPathSelecionaAutomoveis)).Click();
            driver.FindElement(By.Id(IdValorInicial)).SendKeys(valorInicial);
            driver.FindElement(By.Id(IdUploadImagem)).SendKeys(caminhoImagem);
            driver.FindElement(By.Id(IdInicioPregao)).SendKeys(inicioPregao.ToString("dd/MM/yyyy"));
            driver.FindElement(By.Id(IdFinalPregao)).SendKeys(finalPregao.ToString("dd/MM/yyyy")) ;
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(By.XPath(xPathBtnConfirmaLeilao)).Click();
        }
    }
}
