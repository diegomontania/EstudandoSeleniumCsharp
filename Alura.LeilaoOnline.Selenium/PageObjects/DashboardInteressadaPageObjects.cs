using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPageObjects
    {
        private readonly IWebDriver Driver;

        public FiltroLeiloesPageObjects Filtro { get; }

        public MenuLogadoPageObjects MenuLogado { get; }

        public DashboardInteressadaPageObjects(IWebDriver driver)
        {
            this.Driver = driver;
            Filtro = new FiltroLeiloesPageObjects(driver);
            MenuLogado = new MenuLogadoPageObjects(driver);
        }

    }
}
