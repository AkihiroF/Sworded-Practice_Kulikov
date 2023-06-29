using Code.Scripts.Enemy;
using Code.Scripts.Player;
using Scripts.Enemy;
using UnityEngine;
using Zenject;

namespace Scripts.Core
{
    public class BaseInstaller : MonoInstaller
    {
        [SerializeField] private VariableJoystick joystick;
        public override void InstallBindings()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.Bind<VariableJoystick>().FromInstance(joystick);
            Container.Bind<PlayerMovement>().AsSingle();
        }

    }
}