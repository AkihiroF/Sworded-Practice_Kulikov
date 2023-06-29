using UnityEngine;

namespace Scripts.Health
{
    public class DamagableProp : MonoBehaviour
    {
        public GameObject HitFX;
        public PlayerStats playerStats;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Sword"))
            {
                float magn = collision.relativeVelocity.magnitude;
                if (magn > 10)
                {
                    if (magn > 20) Instantiate(HitFX, collision.contacts[0].point + Vector3.up * 0.5f, Quaternion.identity);
                    playerStats.lastHit = collision.transform.parent.GetComponent<PlayerIndex>().index;
                    playerStats.AddHP(-(int)magn);
                }
            }
        }
    }
}
