using System;
using System.Collections.Generic;
using _Game.Scripts.Components;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.View
{
    public class HealthView : MonoBehaviour, IDisposable
    {
        [SerializeField] private RectTransform _heartsContainer;
        [SerializeField] private Image _heartImage;

        private Health _health;
        private Stack<Image> _heartStack = new Stack<Image>();
        
        private int _previousHealth;

        public void Init()
        {
            _health = ServiceLocator.GetInstance<Player>().Health;
            _previousHealth = _health.CurrentValue;

            for (int i = 0; i < _health.CurrentValue; i++)
                _heartStack.Push(Instantiate(_heartImage, _heartsContainer));

            AddListeners();
        }

        public void Dispose()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _health.Changed += UpdateView;
        }

        private void RemoveListeners()
        {
            _health.Changed -= UpdateView;
        }

        private void UpdateView(int value)
        {
            int delta = _previousHealth - value;

            if (delta > 0)
                RemoveHearts(delta);
            else
                AddHearts(-delta);

            _previousHealth = value;
        }

        private void AddHearts(int count)
        {
            for (int i = 0; i < count; i++)
                _heartStack.Push(Instantiate(_heartImage, _heartsContainer));
        }

        private void RemoveHearts(int count)
        {
            for (int i = 0; i < count; i++)
                Destroy(_heartStack.Pop().gameObject);
        }
    }
}