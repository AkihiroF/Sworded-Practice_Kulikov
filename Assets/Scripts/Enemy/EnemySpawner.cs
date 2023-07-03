using System.Collections.Generic;
using Code.Events;
using DG.Tweening;
using Scripts.Enemy;
using Scripts.Services;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> pointsSpawn;
        [SerializeField] private List<GameObject> enemies;
        [SerializeField] private float timeSpawn;
        [SerializeField] private int countEnemiesInWave;
        [Inject] private EnemyPool enemyPool;

        [Inject] private DiContainer _diContainer;

        private Tween _tweenWait;

        private void Awake()
        {
            Signals.Get<OnStartGame>().AddListener(DoSpawn);
            Signals.Get<OnStopGame>().AddListener(StopSpawn);
        }

        private void StartSpawn()
        {
            var time = 0;
            _tweenWait = DOTween.To(() => time, x => time = x, 1, timeSpawn)
                .OnComplete(DoSpawn);
        }

        private void DoSpawn()
        {
            for (int i = 0; i < countEnemiesInWave; i++)
            {
                var enemy = enemyPool.GetEnemy();
                if(enemy == null)
                {
                    var idEnemy = Random.Range(0, enemies.Count);
                    enemy = _diContainer.InstantiatePrefab(enemies[idEnemy]);
                }

                var idPoint = Random.Range(0, pointsSpawn.Count);
                enemy.transform.position = pointsSpawn[idPoint].position;
                enemy.SetActive(true);
            }
            StartSpawn();
        }

        private void StopSpawn()
        {
            _tweenWait.Kill(false);
        }
    }
}