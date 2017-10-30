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
            //GameServices.Export();
            /*
             * Console.WriteLine("Importando datos.");
            GameServices.Import();
            Console.WriteLine("Games:\n");
            */
            /*foreach (Game game in GameServices.Games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("Players:\n");
            foreach (Player player in GameServices.Players)
            {
                Console.WriteLine(player);
            }*/

            
            GameServices.Console();

            
            

            
        }
    }
}
