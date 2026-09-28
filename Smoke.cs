using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindLamirint
{
    internal class Smoke
    {
        static public void Smoking(string map)
        {
            string smokedMap = "";
            int playerX, playerY;
            (playerX, playerY) = FindPlayer(map);
            string[] mapSplited = map.Split('\n');
            for (int i = 0; i < mapSplited.Length; i++)
            {
                for (int j = 0; j < mapSplited[i].Length; j++)
                {
                    if ((i + 1 == playerY || i == playerY || i - 1 == playerY) && (j + 1 == playerX || j == playerX || j - 1 == playerX))
                        smokedMap += mapSplited[i][j];
                    else
                        smokedMap += " ";
                }
                smokedMap += '\n';
            }
            Console.Write(smokedMap);
        }
        static private (int, int) FindPlayer(string map)
        {
            int x = 0, y = 0;
            string[] mapSplited = map.Split('\n');
            for (int i = 0; i < mapSplited.Length; i++)
            {
                for (int j = 0; j < mapSplited[i].Length; j++)
                {
                    if (mapSplited[i][j] == '$')
                    {
                        x = j;
                        y = i;
                        break;
                    }
                }
            }
            return (x, y);
        }
    }
}
