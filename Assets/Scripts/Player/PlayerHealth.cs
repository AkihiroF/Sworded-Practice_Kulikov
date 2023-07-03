using Code.Events;
using Scripts.Enemy;
using Scripts.Services;

namespace Scripts.Player
{
    public class PlayerHealth : EnemyHealth
    {
        protected override void Death()
        {
            GameUI.AddDeath();
            Signals.Get<OnStopGame>().Dispatch();
            base.Death();
        }
    }
}