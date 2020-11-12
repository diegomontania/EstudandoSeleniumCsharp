using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPageObjects
    {
        private readonly IWebDriver Driver;
        private string IdMeuPerfil, IdLinkLogout;

        public MenuLogadoPageObjects(IWebDriver driver)
        {
            this.Driver = driver;
            IdMeuPerfil = "meu-perfil";
            IdLinkLogout = "logout";
        }

        //Padrão Criacional Builder
        //https://www.gofpatterns.com/creational-patterns/creational-patterns/builder-pattern.php

        //API da classe Actions
        //https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_Interactions_Actions.htm

        public void EfetuarLogout()
        {
            //metodo utiliza '.MoveToElement' para interagir com elementos que requerem
            //interação antes de serem utilizados

            /*coloca resolução maior para encontrar elementos corretamente*/
            Driver.Manage().Window.Size = new System.Drawing.Size(1500, 1060);

            var linkMeuPerfil = Driver.FindElement(By.Id(IdMeuPerfil));
            var linkLogout = Driver.FindElement(By.Id(IdLinkLogout));

            //cria uma acao para performar em cima desse campo
            IAction acaoLogout = new Actions(Driver)
                .MoveToElement(linkMeuPerfil) /*move para elemento de perfil*/
                .MoveToElement(linkLogout)    /*move para elemento de logout*/
                .Click()
                .Build();

            acaoLogout.Perform(); /*executa a acao*/

            /*reseta para resolução inicial*/
            Driver.Manage().Window.Size = new System.Drawing.Size(1107, 1060);
        }
    }
}
