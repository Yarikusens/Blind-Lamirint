using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindLamirint
{
    internal class StartGame
    {
        static public string Start()
        {
            Console.Write("Введіть карту, на якій бажаєте грати (default або шлях до файлу з картою): ");
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }
    }
}
