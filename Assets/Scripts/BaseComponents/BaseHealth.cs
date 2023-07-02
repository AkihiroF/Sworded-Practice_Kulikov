using UnityEngine;

namespace Scripts.BaseComponents
{
    public class BaseHealth : MonoBehaviour
    {
        [SerializeField] protected int maxHp;
        [SerializeField] protected PlayerStats playerStats;
        protected float _currentHp;

        protected bool isDamagable;

        public bool Damagable
        {
            get => isDamagable;
            set => isDamagable = value;
        }

        public bool IsBot
        {
            get => playerStats.player;
        }
        public void Defense()
        {

            if (isDamagable)
            {
                playerStats.lastHit = 0;
                isDamagable = false;
            }
        }
    }
}