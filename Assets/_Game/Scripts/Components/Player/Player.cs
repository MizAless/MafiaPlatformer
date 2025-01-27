using System;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _startHealth;
        
        private PlayerInput _playerInput;

        public Health Health { get; private set; }
        public Mover Mover { get; private set; }

        public void Init()
        {
            Mover = new Mover(transform, _speed);
            Health = new Health(_startHealth);
            _playerInput = ServiceLocator.GetInstance<PlayerInput>();

            AddListeners();
        }
        
        public void Reset()
        {
            Mover.Reset();
            Health.Reset();
        }
        
        public void TakeDamage(int damage)
        {
            Health.TakeDamage(damage);
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _playerInput.Moved += Mover.Move;
        }

        private void RemoveListeners()
        {
            _playerInput.Moved -= Mover.Move;
        }
    }
}