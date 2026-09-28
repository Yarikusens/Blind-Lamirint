using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlindLamirint.Input;

namespace BlindLamirint
{
    internal class PlayerController
    {
        private Player player;
        private Map field;
        public PlayerController(Map field, Player player)
        {
            this.field = field;
            this.player = player;
        }
        public void Update(Input input)
        {
            CheckInput(input);
        }
        private void CheckInput(Input input)
        {
            (Comands comand, int value) = input.GetComand();
            switch (comand)
            {
                case Comands.MoveX:
                    Move(value, 0);
                    break;
                case Comands.MoveY:
                    Move(0, value);
                    break;
            }
        }

        private void Move(int dx, int dy)
        {
            int x, y;
            (x, y) = player.GetCords();
            bool canMove, win;
            (canMove, win) = CanMove(x + dx, y + dy);
            if (canMove)
                player.Move(dx, dy);
            else if (win)
                player.Win();
        }

        private (bool, bool) CanMove(int x, int y)
        {
            return field.IsAvalable(x, y);
        }
    }
}
