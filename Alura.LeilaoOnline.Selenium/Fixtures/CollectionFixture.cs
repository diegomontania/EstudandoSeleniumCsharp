using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    //IClassFixture indica que a classe 'TesteFixtures' é uma classe de configuração 
    //para TODOS OS TESTES DA MESMA CLASSE

    //ICollectionFixture indica que a classe 'TesteFixtures' é uma classe 
    //de configuração compartilhada para TODOS OS TESTES DE CLASSES DIFERENTES

    //BDD usaria ICollectionFixture para testes de UI

    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture : ICollectionFixture<TesteFixtures>
    {

    }
}
