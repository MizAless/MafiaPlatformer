using System;
using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private int _additionalValue;
        [SerializeField] private float _additionalDelay;
        
        private Player _player;
        
        private bool _isPlaying = true;

        private int _value;
        
        public int Value => _value;

        public event Action<int> Changed;

        public void Init()
        {
            _isPlaying = true;
            _value = 0;

            StartCoroutine(StartScoring());
        }
        
        public void Stop()
        {
            _isPlaying = false;
        }

        private IEnumerator StartScoring()
        {
            var wait = new WaitForSeconds(_additionalDelay);

            while (_isPlaying)
            {
                _value += _additionalValue;
                Changed?.Invoke(_value);
                
                yield return wait;
            }
        }
    }
}