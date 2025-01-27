using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class ObstacleSpawner : Spawner<Obstacle>
    {
        [SerializeField] private Vector2 _spawnRange;
        [SerializeField] private float _cooldown;

        private Coroutine _spawnCoroutine;

        public override void Init()
        {
            base.Init();
            _spawnCoroutine = StartCoroutine(StartSpawning());
        }

        public override Obstacle Spawn()
        {
            var obstacle = base.Spawn();
            var randomPosition = new Vector2(transform.position.x + Random.Range(-_spawnRange.x, _spawnRange.x),
                transform.position.y + Random.Range(-_spawnRange.y, _spawnRange.y));

            obstacle.Init(randomPosition);
            return obstacle;
        }
        
        public void StopSpawning()
        {
            StopCoroutine(_spawnCoroutine);
        }

        private IEnumerator StartSpawning()
        {
            var wait = new WaitForSeconds(_cooldown);

            while (enabled)
            {
                Spawn();
                yield return wait;
            }
        }
    }
}