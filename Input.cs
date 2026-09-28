using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindLamirint
{
    enum Comands
    {
        None,
        MoveX,
        MoveY,
    }
    internal class Input
    {
        private ConsoleKeyInfo? lastInput;

        public void TakeInput()
        {
            if (Console.KeyAvailable)
                lastInput = Console.ReadKey(true);
            else
                lastInput = null;
        }

        public ConsoleKeyInfo? GetLastInput()
        {
            return lastInput;
        }

        public (Comands, int) GetComand()
        {
            return lastInput?.Key switch
            {
                ConsoleKey.A => (Comands.MoveY, -1),
                ConsoleKey.D => (Comands.MoveY, 1),
                ConsoleKey.W => (Comands.MoveX, -1),
                ConsoleKey.S => (Comands.MoveX, 1),
                _ => (Comands.None, 0)
            };
        }
    }
}
