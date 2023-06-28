using Code.Scripts.Enemy;
using Code.Scripts.Player;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Core
{
    public class SurvivalInstaller : MonoInstaller
    {
        [SerializeField] private VariableJoystick joystick;
        public override void InstallBindings()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.Bind<EnemyPool>().AsTransient().NonLazy();
            Container.Bind<EnemySpawner>().AsSingle();
            Container.Bind<VariableJoystick>().FromInstance(joystick);
            Container.Bind<PlayerMovement>().AsSingle();
        }

    }
}