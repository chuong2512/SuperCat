using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.ChuongScripts.Scripts.Runtime
{
    public class Spawner : Singleton<Spawner>
    {
        [SerializeField] private ScoreAddition _scoreAddition;
        [SerializeField] private List<GameObject> enemyCars;
        [SerializeField] private Transform spawnPositions;

        [SerializeField] private float _minY = 0, _maxY = 10;

        private float randomTime = 0f;
        private float elapsedTime = 0;

        private void Update()
        {
            if (elapsedTime < randomTime)
            {
                elapsedTime += Time.deltaTime;
                return;
            }

            Spawn();
            elapsedTime = 0f;
            randomTime = Random.Range(3f, 3.5f);
        }

        private void Spawn()
        {
            var spawnPos = SpawnPos();
            if (Random.Range(0, 100) >= 10)
            {
                var car = Instantiate(enemyCars[Random.Range(0, enemyCars.Count)]);
                car.transform.position = spawnPos;
                return;
            }

            var scoreAddition = Instantiate(_scoreAddition);
            scoreAddition.transform.position = spawnPos;
        }

        private Vector2 SpawnPos()
        {
            return new Vector2(spawnPositions.position.x, Random.Range(_minY, _maxY));
        }
    }
}