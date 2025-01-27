using System;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class PlayerInput : MonoBehaviour
    {
        private const string Vertical = nameof(Vertical);
        private const string Horizontal = nameof(Horizontal);

        public event Action<Vector2> Moved;

        private void Update()
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vertical));
            direction.Normalize();

            if (direction != Vector2.zero)
                Moved?.Invoke(direction);
        }
    }
}