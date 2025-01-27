using System;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class Obstacle : MonoBehaviour, IDestroyable<Obstacle>, IDisposable
    {
        [SerializeField] private int _damage;
        
        [SerializeField] private float _startHeight;
        [SerializeField] private ExplosionArea _explodeArea;
        [SerializeField] private FallingObstacleBody _fallingObstacleBody;

        public event Action<Obstacle> Disabled;

        public void Init(Vector3 position)
        {
            transform.position = position;
            _fallingObstacleBody.Init(_startHeight);
            _explodeArea.Init();

            AddListeners();
        }

        private void AddListeners()
        {
            _explodeArea.Touched += OnTouched;
        }

        private void RemoveListeners()
        {
            _explodeArea.Touched -= OnTouched;
        }

        public void Dispose()
        {
            RemoveListeners();
        }

        private void OnTouched(FallingObstacleBody fallingObstacleBody)
        {
            if (fallingObstacleBody != _fallingObstacleBody)
                return;
            
            _fallingObstacleBody.Disable();
            
            if (_explodeArea.HavePlayer)
                _explodeArea.Player.TakeDamage(_damage);
            
            Disabled?.Invoke(this);
        }
    }
}