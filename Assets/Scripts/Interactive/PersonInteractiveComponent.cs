using Scripts.Services;
using UnityEngine;

namespace Scripts.Interactive
{
    public class PersonInteractiveComponent : MonoBehaviour
    {
        [SerializeField] private BoostManager boostManager;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField]  private LayerMask boostLayer;
        [SerializeField]  private LayerMask pointLayer;
        [SerializeField]  private LayerMask coinLayer;
        private void OnTriggerEnter(Collider collision)
        {
            var coll = collision.gameObject.layer;
            if (boostLayer.CheckLayer(coll))
            {
                boostManager.ActivateBoost(collision.gameObject.GetComponent<BoostIndex>().index);
                collision.gameObject.GetComponent<BoostIndex>().GetBoost();
            }
            if (coinLayer.CheckLayer(coll)&& !playerStats.botface)
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5);
                collision.gameObject.SetActive(false);
            }
            if (pointLayer.CheckLayer(coll))
            {
                if (playerStats.botface) playerStats.AddPoints(50);
                else playerStats.AddPoints(25);
                collision.gameObject.SetActive(false);
                if (!playerStats.botface)
                {
                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5);
                    playerStats.CoinAnim.gameObject.SetActive(true);
                    playerStats.CoinAnim.Play();
                }
            }
        }
    }
}