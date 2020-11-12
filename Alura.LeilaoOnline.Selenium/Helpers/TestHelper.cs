using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    //classe responsavel por conter métodos que são auxiliares ao testes ou seja, pequenas dependencias
    public static class TestHelper
    {
        public static string PastaDoExecutavel()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
