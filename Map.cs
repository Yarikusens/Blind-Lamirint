using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindLamirint
{
    internal class Map
    {
        static string defaultMap =
            "###########\n" +
            "#$      # #\n" +
            "####### # #\n" +
            "#     # # #\n" +
            "# ### # # #\n" +
            "# #   #   #\n" +
            "# # ##### #\n" +
            "# #     # #\n" +
            "# ##### # #\n" +
            "#    F#   #\n" +
            "###########";
        public enum FieldObjects
        {
            Wall,
            Player,
            Finish,
            EmptyCell
        }
        private PlayerController playerController;
        public FieldObjects[,] field;
        public int width;
        public int height;
        public Map(string input)
        {
            if (input == "default")
            {
                field = CreatingMap(defaultMap);
            }
            else
            {
                field = CreatingMap(File.ReadAllText(input));
            }
            width = FindWidth(field);
            height = FindHeight(field);
        }
        private FieldObjects[,] CreatingMap(string choice)
        {
            choice = choice.Replace("\r", "");
            string[] fieldSplit = choice.Split('\n');


            FieldObjects[,] result = new FieldObjects[fieldSplit.Length, fieldSplit[0].Length];
            for (int i = 0; i < fieldSplit.Length; i++)
            {
                for (int j = 0; j < fieldSplit[0].Length; j++)
                {
                    result[i, j] = fieldSplit[i][j] switch
                    {
                        ' ' => FieldObjects.EmptyCell,
                        '#' => FieldObjects.Wall,
                        '$' => FieldObjects.Player,
                        'F' => FieldObjects.Finish,
                        _ => FieldObjects.EmptyCell
                    };
                }
            }
            return result;
        }
        private int FindWidth(FieldObjects[,] field) => field.GetLength(1);
        private int FindHeight(FieldObjects[,] field) => field.GetLength(0);
        static public string ShowMap(Map map)
        {
            string result = "";
            for (int i = 0; i < map.height; i++)
            {
                for (int j = 0; j < map.width; j++)
                {
                    result += map.field[i, j] switch
                    {
                        FieldObjects.EmptyCell => ' ',
                        FieldObjects.Wall => '#',
                        FieldObjects.Player => '$',
                        FieldObjects.Finish => 'F'
                    };
                }
                result += '\n';
            }
            return result;
        }
        public (bool, bool) IsAvalable(int x, int y)
        {
            bool result;
            bool win;
            try
            {
                result = field[x, y] == FieldObjects.EmptyCell;
                win = field[x, y] == FieldObjects.Finish;
            }
            catch
            {
                result = false;
                win = false;
            }
            return (result, win);
        }
        public void SetControllers(PlayerController player) => playerController = player;
        private void InitField() => field = new FieldObjects[width, height];
        public void UpdatePlayerPosition(Player player)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (field[i, j] == FieldObjects.Player)
                        field[i, j] = FieldObjects.EmptyCell;
                }
            }
            int x, y;
            (x, y) = player.GetCords();
            field[x, y] = FieldObjects.Player;
        }
    }
}
