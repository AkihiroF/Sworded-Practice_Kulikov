using UnityEngine;
using Zenject;

namespace Code.Scripts.Enemy
{
    public class EnemySpawnInstaller : MonoInstaller
    {
        [SerializeField] private PlayerIndex player;
        //[Inject] private EnemyPool enemyPool;
        public override void InstallBindings()
        {
            //Container.BindFactory<EnemyMovement,>().FromComponentInNewPrefab(player);
            Container.Bind<PlayerIndex>().FromInstance(player).AsSingle();
            Container.BindFactory<EnemyMovement, EnemyMovement.Factory>();
            //Container.Bind<EnemyMovement>().AsSingle();
        }
    }
}