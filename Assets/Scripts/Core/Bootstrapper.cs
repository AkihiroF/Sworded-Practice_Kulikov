using Code.Events;
using deVoid.Utils;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Core
{
    public class Bootstrapper : MonoBehaviour
    {

        private void Start()
        {
            Signals.Get<OnStartGame>().Dispatch();
        }
    }
}