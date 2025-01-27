using _Game.Scripts.Components;
using _Game.Scripts.View;
using UnityEngine;
using UnityEngine.Serialization;

public class GameInitialaizer : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Player _player;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private Score _score;
    [SerializeField] private GameOverLogic gameOverLogic;
    [SerializeField] private UISwitcher _uiSwitcher;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private ScoreView _scoreView;

    private void Start()
    {
        InstallBindings();

        _player.Init();
        _score.Init();
        _uiSwitcher.Init();
        _game.Init();
        _obstacleSpawner.Init();
        _healthView.Init();
        _scoreView.Init();
        gameOverLogic.Init();
    }

    private void InstallBindings()
    {
        ServiceLocator.Init();
        ServiceLocator.Register<PlayerInput>(_playerInput);
        ServiceLocator.Register<Player>(_player);
        ServiceLocator.Register<Score>(_score);
        ServiceLocator.Register<GameOverLogic>(gameOverLogic);
        ServiceLocator.Register<Game>(_game);
        ServiceLocator.Register<UISwitcher>(_uiSwitcher);
        ServiceLocator.Register<ObstacleSpawner>(_obstacleSpawner);
    }
}