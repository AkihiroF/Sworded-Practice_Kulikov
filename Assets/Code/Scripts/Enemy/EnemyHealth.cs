using UnityEngine;
using Zenject;

namespace Code.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private HitColor BigHitFX;
        [SerializeField] private HitColor HitFX;
        [SerializeField] private GameObject BotHitFX;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 1;

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
            rb.AddForce((transform.position- collision.transform.position).normalized * 20 * speed);
        }
        if (collision.gameObject.CompareTag("Sword")&& collision.transform.parent!= transform)
        {
            float magn = collision.relativeVelocity.magnitude;
            if (magn > 10)
            {
                
                rb.AddForce((Vector3.up - collision.transform.parent.position + transform.position).normalized * magn *1.2f* speed);
                if (playerStats.botface) Instantiate(BotHitFX, collision.contacts[0].point + Vector3.up * 0.5f, Quaternion.identity);
                else if (meshRenderer.isVisible)
                {
                        
                    if (magn > 35)
                    {
                        HitColor hit=Instantiate(BigHitFX, collision.contacts[0].point + Vector3.up * 0.5f, Quaternion.identity);
                        Color color= meshRenderer.material.color;
                        Color.RGBToHSV(color,out float h, out float u, out float e);
                        hit.color = Color.HSVToRGB(h, u, 1);
                    }
                    else
                    {
                        HitColor hit = Instantiate(HitFX, collision.contacts[0].point + Vector3.up * 0.5f, Quaternion.identity);
                        Color color = meshRenderer.material.color;
                        Color.RGBToHSV(color, out float h, out float u, out float e);
                        hit.color = Color.HSVToRGB(h, u, 1);
                    }
                }
                playerStats.lastHit = collision.transform.parent.GetComponent<PlayerIndex>().index;
                CheckHp(-(int)magn);
            }
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