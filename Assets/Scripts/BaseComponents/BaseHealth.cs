using UnityEngine;

namespace Scripts.BaseComponents
{
    public class BaseHealth : MonoBehaviour
    {
        [SerializeField] protected int maxHp;
        [SerializeField] protected PlayerStats playerStats;
        protected float _currentHp;

        protected bool IsDamagable = true;

        public bool Damagable
        {
            get => IsDamagable;
            set => IsDamagable = value;
        }

        public bool IsBot
        {
            get => playerStats.player;
        }
        public void Defense()
        {

            if (IsDamagable)
            {
                playerStats.lastHit = 0;
                IsDamagable = false;
            }
        }
    }
}