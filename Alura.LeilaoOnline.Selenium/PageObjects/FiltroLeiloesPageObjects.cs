using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPageObjects
    {
        private IWebDriver Driver;
        private string IdTermo, CssEmAndamento, CssBtnPesquisar;

        public FiltroLeiloesPageObjects(IWebDriver driver)
        {
            this.Driver = driver;
            IdTermo = "termo";
            CssEmAndamento = ".switch > label";
            CssBtnPesquisar = ".btn";
        }

        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            var selectWrapper = Driver.FindElement(By.ClassName("select-wrapper"));
            selectWrapper.Click();

            Thread.Sleep(2000);

            //seleciona por css
            var opcoes = selectWrapper
                .FindElements(By.CssSelector("li>span"))
                .ToList();

            //faz loop entre as opções clicando (deselecionando)
            opcoes.ForEach(o =>
            {
                o.Click();
            });

            Thread.Sleep(2000);

            //faz loop entre as categorias clicando (selecionando)
            categorias.ForEach(categ =>
            {
                opcoes
                    .Where(o => o.Text.Contains(categ))
                    .ToList()
                    .ForEach(o =>
                    {
                        o.Click();
                    });
            });

            //utiliza o 'tab' para sair da seleção do dropdown
            selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);

            //clica em uma das seleções do dropdown list
            Driver.FindElement(By.Id(IdTermo)).SendKeys(termo);

            //switch 'em andamento
            if (emAndamento)
            {
                Driver.FindElement(By.CssSelector(CssEmAndamento)).Click();
            }

            //confirma
            Driver.FindElement(By.CssSelector(CssBtnPesquisar)).Click();
        }
    }
}
