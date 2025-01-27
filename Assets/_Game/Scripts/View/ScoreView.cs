using System;
using _Game.Scripts.Components;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.View
{
    public class ScoreView : MonoBehaviour, IDisposable
    {
        private const string Score = "Score:";

        [SerializeField] private Text _scoreText;

        private Score _score;

        public void Init()
        {
            _score = ServiceLocator.GetInstance<Score>();
            
            UpdateView(_score.Value);
            AddListeners();
        }

        public void Dispose()
        {
            RemoveListeners();
        }

        public void UpdateView(int value)
        {
            _scoreText.text = $"{Score} {value}";
        }

        private void AddListeners()
        {
            _score.Changed += UpdateView;
        }

        private void RemoveListeners()
        {
            _score.Changed -= UpdateView;
        }
    }
}