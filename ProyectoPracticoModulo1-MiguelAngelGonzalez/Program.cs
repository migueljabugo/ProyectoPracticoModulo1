using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticoModulo1_MiguelAngelGonzalez
{
    class Program
    {
        static void Main(string[] args)
        {
            GameServices.TestData();
            Console.WriteLine("Exportando datos.");
            GameServices.Export();

            Console.WriteLine("Importando datos. \nFalta importar la ultima linea.");
            GameServices.Import();


            Console.ReadLine();
        }
    }
}
