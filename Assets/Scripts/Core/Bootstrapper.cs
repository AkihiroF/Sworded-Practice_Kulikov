using Code.Events;
using Scripts.Services;
using UnityEngine;

namespace Scripts.Core
{
    public class Bootstrapper : MonoBehaviour
    {

        private void Start()
        {
            Signals.Get<OnStartGame>().Dispatch();
        }
    }
}