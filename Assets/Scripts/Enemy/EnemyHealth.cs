using Scripts.Feedback;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PersonFeedback feedback;

        [Inject] private EnemyPool pool;

        private float _currentHp;

        private void Start()
        {
            _currentHp = playerStats.MaxHP;
        }

        private void OnCollisionEnter(Collision collision) 
        {
        if (collision.gameObject.CompareTag("Unit"))
        {
            feedback.FeedbackFromUnit(transform.position- collision.transform.position);
        }
        if (collision.gameObject.CompareTag("Sword")&& collision.transform.parent!= transform)
        {
            float magn = collision.relativeVelocity.magnitude;
            feedback.FeedbackFromSword(magn,collision,true);
            playerStats.lastHit = collision.transform.parent.GetComponent<PlayerIndex>().index;
            CheckHp(-(int)magn);
        } 
        }

        private void CheckHp(int damage)
        {
            _currentHp += damage;
            if(_currentHp > 0)playerStats.AddHP(damage);
            else
            {
                Death();
            }
        }

        protected virtual void Death()
        {
            pool.AddEnemy(this.gameObject);
            playerStats.GoodDeath();
        }
        
    }
}