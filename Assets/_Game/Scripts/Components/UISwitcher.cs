using _Game.Scripts.View;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private RectTransform _gameUI;
        [SerializeField] private RectTransform _gameOverScreen;
        [SerializeField] private ScoreView _gameOverScoreView;
        
        private Score _score;
        
        public void Init()
        {
            _score = ServiceLocator.GetInstance<Score>();
            
            EnableGameUI();
        }
        
        public void EnableGameOverScreen()
        {
            _gameUI.gameObject.SetActive(false);
            _gameOverScreen.gameObject.SetActive(true);
            _gameOverScoreView.UpdateView(_score.Value);
        }

        private void EnableGameUI()
        {
            _gameUI.gameObject.SetActive(true);
            _gameOverScreen.gameObject.SetActive(false);
        }
    }
}