using System;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class GameOverLogic : MonoBehaviour, IDisposable
    {
        private Player _player;
        
        public event Action GameOver;

        public void Init()
        {
            _player = ServiceLocator.GetInstance<Player>();
            
            AddListeners();
        }

        public void Dispose()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _player.Health.Died += StopGame;
        }

        private void RemoveListeners()
        {
            _player.Health.Died -= StopGame;
        }

        private void StopGame()
        {
            GameOver?.Invoke();
        }
    }
}