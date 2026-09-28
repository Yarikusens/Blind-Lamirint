using BlindLamirint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlindLamirint
{
    internal class Game
    {
        static private Map map;
        private Player player;
        private Input input;
        private PlayerController playerController;
        static bool GameIsOver = false;
        public void Start()
        {
            Init();
            GameCycle();
        }
        private void Init()
        {
            map = new Map(StartGame.Start());
            player = new Player(map);
            playerController = new PlayerController(map, player);
            map.SetControllers(playerController);
            input = new Input();
        }
        private void GameCycle()
        {
            Smoke.Smoking(Map.ShowMap(map));
            while (!GameIsOver)
            {
                Console.Clear();
                Update();
                Thread.Sleep(750);
            }
        }
        private void Update()
        {
            input.TakeInput();
            playerController.Update(input);
            Smoke.Smoking(Map.ShowMap(map));
        }
    }
}
