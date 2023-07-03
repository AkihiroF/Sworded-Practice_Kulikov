using Scripts.BaseComponents;
using Scripts.Feedback;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemyHealth : BaseHealth
    {
        [SerializeField] private PersonFeedback feedback;
        [SerializeField] private PersonUIComponent personUIComponent;

        [Inject] private EnemyPool pool;
        [Inject] protected GameUI GameUI;
        [Inject] private BalanceSheet balance;
        private int _lastHit;

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
            _lastHit = collision.transform.parent.GetComponent<PlayerIndex>().index;
            AddHP(-(int)magn);
        } 
        }

        public void UpgradeMaxHp(int Level)
        {
            maxHp = (int)(100 * Mathf.Pow((float)Level, balance.HPcoeff));
            _currentHp = maxHp;
            AddHP(0);
        }

        public void AddHP(int damage)
            {
                if (GameUI.Stats.Count > 1)
                {
                    PlayerStats playerStats = GameUI.Stats[_lastHit];
                    damage = (int)(damage * maxHp* playerStats.Damage * playerStats.damagemod / 100);
                    if (damage < 0 && playerStats.vampire)
                    {
                
                        GameUI.Stats[_lastHit].AddHP(-damage/4);
                        
                    }
                }

                if (!Damagable)
                {
                    Damagable = true;
                    return;
                }
                _currentHp += damage;
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
                feedback.FeedbackAddHp(!playerStats.botface);
                personUIComponent.UpdateAddHp(damage,maxHp,_currentHp);
                if (_currentHp<=0)
                {
                    Death();
                }
            }

        protected virtual void Death()
        {
            GameObject o;
            (o = this.gameObject).SetActive(false);
            pool.AddEnemy(o);
            personUIComponent.OnDeath();
            feedback.FeedbackDeath();
            _currentHp = maxHp;
            
            
            if (_lastHit == 0)
            {
                GameUI.AddKill();
            }
            playerStats.GiveXp(_lastHit);
            AddHP(0);
            if (GameUI.mode != 0) GameUI.MinusAlive();
        }
        public class Factory : PlaceholderFactory<EnemyHealth>
        {
        }
    }
}