using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class Mover
    {
        private const float VerticalMultiplier = 0.5f;

        private Transform _transform;
        private Vector2 _speed;
        
        private bool _canMove;

        public Mover(Transform transform, float speed)
        {
            _canMove = true;
            
            _transform = transform;
            _speed = new Vector2(speed, speed * VerticalMultiplier);
        }
        
        public void Reset()
        {
            _canMove = true;
        }

        public void Move(Vector2 direction)
        {
            if (!_canMove)
                return;
            
            Vector3 movement = new Vector3(
                direction.x * _speed.x,
                direction.y * _speed.y
                , 0
            ) * Time.deltaTime;

            _transform.position += movement;
        }
        
        public void Stun()
        {
            _canMove = false;
        }
    }
}