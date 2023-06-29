using Code.Events;
using deVoid.Utils;
using UnityEngine;

namespace Code.Scripts.Core
{
    public class Game
    {
        public Game()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            Signals.Get<OnStartGame>().AddListener(StartGame);
            Signals.Get<OnStopGame>().AddListener(StopGame);
        }

        private void UnSubscribe()
        {
            Signals.Get<OnStartGame>().RemoveListener(StartGame);
            Signals.Get<OnStopGame>().RemoveListener(StopGame);
        }
        private void StartGame()
        {
            Time.timeScale = 1;
        }

        private void StopGame()
        {
            UnSubscribe();
            Time.timeScale = 0;
        }
    }
}