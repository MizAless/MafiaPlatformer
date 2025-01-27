using System;
using UnityEngine;

namespace _Game.Scripts.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingObstacleBody : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Init(float startHeight)
        {
            gameObject.SetActive(true);
            _rigidbody.velocity = Vector2.zero;
            transform.position += Vector3.up * startHeight;
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}