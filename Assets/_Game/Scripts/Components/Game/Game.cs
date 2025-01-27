using System;
using _Game.Scripts.View;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Components
{
    public class Game : MonoBehaviour, IDisposable
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private ScoreView _gameOverScoreView;
        
        private GameOverLogic _gameOverLogic;
        private Score _score;
        private UISwitcher _uiSwitcher;
        private ObstacleSpawner _obstacleSpawner;
        private Player _player;

        public void Init()
        {
            _gameOverLogic = ServiceLocator.GetInstance<GameOverLogic>();
            _score = ServiceLocator.GetInstance<Score>();
            _uiSwitcher = ServiceLocator.GetInstance<UISwitcher>();
            _obstacleSpawner = ServiceLocator.GetInstance<ObstacleSpawner>();
            _player = ServiceLocator.GetInstance<Player>();
            
            
            AddListeners();
        }

        private void Restart()
        {
            _player.Reset();
            _uiSwitcher.Init();
            _score.Init();
            _obstacleSpawner.Init();
        }

        private void AddListeners()
        {
            _gameOverLogic.GameOver += OnGameOver;
            
            _restartButton.onClick.AddListener(Restart);
        }

        private void RemoveListeners()
        {
            _gameOverLogic.GameOver -= OnGameOver;
            
            _restartButton.onClick.RemoveListener(Restart);
        }

        public void Dispose()
        {
            RemoveListeners();
        }

        private void OnGameOver()
        {   
            _score.Stop();
            _uiSwitcher.EnableGameOverScreen();
            _obstacleSpawner.StopSpawning();
            _player.Mover.Stun();
        }
    }
}