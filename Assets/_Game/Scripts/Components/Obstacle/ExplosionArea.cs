using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class ExplosionArea : MonoBehaviour
    {
        private Player _player;

        public event Action<FallingObstacleBody> Touched;

        public bool HavePlayer { get; private set; }

        public Player Player
        {
            get => _player;
            private set
            {
                _player = value;

                if (_player != null)
                    HavePlayer = true;
                else
                    HavePlayer = false;
            }
        }
        
        public void Init()
        {
            _player = null;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out FallingObstacleBody bomb))
                Touched?.Invoke(bomb);

            if (other.TryGetComponent(out Player player))
                Player = player;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player _))
                Player = null;
        }
    }
}