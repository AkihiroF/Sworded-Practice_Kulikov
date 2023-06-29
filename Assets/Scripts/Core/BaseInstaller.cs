using Code.Scripts.Player;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Scripts.Core
{
    public class BaseInstaller : MonoInstaller
    {
        [SerializeField] private VariableJoystick joystick;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private Camera camera;
        [SerializeField] private RectTransform holderStats;
        public override void InstallBindings()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.Bind<VariableJoystick>().FromInstance(joystick);
            Container.Bind<Camera>().FromInstance(camera);
            Container.Bind<RectTransform>().FromInstance(holderStats);
            Container.Bind<GameUI>().FromInstance(gameUI);
            Container.Bind<PersonUIComponent>().AsSingle();
            Container.Bind<PlayerMovement>().AsSingle();
        }

    }
}