using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Enemy
{
    public class EnemyPool
    {

        public static EnemyPool Pool;
        private List<GameObject> enemies;

        public EnemyPool()
        {
            enemies = new List<GameObject>();
            Pool = this;
        }

        public GameObject GetEnemy()
        {
            if (enemies.Count > 0)
            {
                var enemy = enemies[0];
                enemies.Remove(enemy);
                return enemy;
            }
            return null;
        }

        public void AddEnemy(GameObject enemy) => enemies.Add(enemy);
    }
}