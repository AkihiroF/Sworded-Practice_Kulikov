using Code.Events;
using Scripts.Services;
using UnityEngine;

namespace Scripts.Core
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
            Debug.Log("stopGame");
            UnSubscribe();
            Time.timeScale = 0;
        }
    }
}