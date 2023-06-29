using Scripts.Feedback;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PersonFeedback feedback;
        [SerializeField] private PersonUIComponent personUIComponent;
        [SerializeField] private int maxHp;

        [Inject] private EnemyPool pool;
        private float _currentHp;

        private void Start()
        {
            _currentHp = maxHp;
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
        
        public void AddHP(int damage)
            {
                // if(hp<0) DamageVignette.SetActive(true);
                // if (gameUI.Stats.Count > 1)
                // {
                //     
                //     PlayerStats playerStats = gameUI.Stats[lastHit];
                //     hp = (int)(hp * playerStats.MaxHP* playerStats.Damage * playerStats.damagemod / 100);
                //     if (hp < 0 && playerStats.vampire)
                //     {
                //
                //         gameUI.Stats[lastHit].AddHP(-hp/4);
                //         
                //     }
                // }
                _currentHp -= damage;
                if (damage != 0)
                {
                    feedback.FeedbackHealth();
                }
                if (damage < 0) 
                {
                    if (-damage > maxHp / 4)
                    {
                        if (Time.timeScale == 1)
                        {
                            if (playerStats.player || playerStats.lastHit == 0) feedback.TimeShift();
                        }
                    }
                }
                _currentHp = Mathf.Clamp(_currentHp, 0, maxHp);
                personUIComponent.UpdateAddHp(damage,maxHp,_currentHp);
                if (_currentHp<=0)
                {
                    Death();
                }
            }

        protected virtual void Death()
        {
            pool.AddEnemy(this.gameObject);
            personUIComponent.OnDeath();
            feedback.FeedbackDeath();
        }
        
    }
}