using Code.Events;
using Code.Scripts.Enemy;
using deVoid.Utils;

namespace Code.Scripts.Player
{
    public class PlayerHealth : EnemyHealth
    {
        protected override void Death()
        {
            Signals.Get<OnStopGame>().Dispatch();
        }
    }
}