using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlindLamirint.Map;

namespace BlindLamirint
{
    internal class Player
    {
        private Map field;
        private int x;
        private int y;
        public Player(Map field)
        {
            this.field = field;
            for (int i = 0; i < field.height; i++)
            {
                for (int j = 0; j < field.width; j++)
                {
                    if (field.field[i,j] == FieldObjects.Player)
                    {
                        this.x = j;
                        this.y = i;
                    }
                }
            }
        }
        public void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
            field.UpdatePlayerPosition(this);
        }
        public (int, int) GetCords() => (x, y);
        public void Win()
        {
            Console.Clear();
            Console.Write("\r\n_________          _______    _______  _        ______  \r\n\\__   __/|\\     /|(  ____ \\  (  ____ \\( (    /|(  __  \\ \r\n   ) (   | )   ( || (    \\/  | (    \\/|  \\  ( || (  \\  )\r\n   | |   | (___) || (__      | (__    |   \\ | || |   ) |\r\n   | |   |  ___  ||  __)     |  __)   | (\\ \\) || |   | |\r\n   | |   | (   ) || (        | (      | | \\   || |   ) |\r\n   | |   | )   ( || (____/\\  | (____/\\| )  \\  || (__/  )\r\n   )_(   |/     \\|(_______/  (_______/|/    )_)(______/ \r\n                                                        \r\n");
            while (true)
            {
                // стоп гра
            }
        }
    }
}
