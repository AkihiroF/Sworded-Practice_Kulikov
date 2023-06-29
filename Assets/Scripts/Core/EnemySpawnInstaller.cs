using Code.Scripts.Enemy;
using Scripts.Enemy;
using UnityEngine;
using Zenject;

namespace Scripts.Core
{
    public class EnemySpawnInstaller : MonoInstaller
    {
        [SerializeField] private PlayerIndex player;
        public override void InstallBindings()
        {
            Container.Bind<EnemyPool>().AsTransient().NonLazy();
            Container.Bind<EnemySpawner>().AsSingle();
            Container.Bind<PlayerIndex>().FromInstance(player).AsSingle();
            Container.BindFactory<EnemyMovement, EnemyMovement.Factory>();
        }
    }
}