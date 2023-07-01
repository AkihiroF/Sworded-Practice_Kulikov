using DG.Tweening;
using Scripts.Audio;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Feedback
{
    public class PersonFeedback : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private HitColor bigHitFX;
        [SerializeField] private HitColor hitFX;
        [SerializeField] private Transform smokeFX;
        [SerializeField] private GameObject botHitFX;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 1;
        
        public Animator animator;
        public Animation DamageAnim;
        public Animation CoinAnim;
        public Animation healtyLineAnim;
        public DamageSounder sounder;

        public void FeedbackFromUnit(Vector3 direction)
        {
            rb.AddForce(direction.normalized * 20 * speed);
        }

        public void FeedbackFromSword(float magn, Collision collision, bool isBot = false)
        {
            if (magn > 10)
            {

                rb.AddForce((Vector3.up - collision.transform.parent.position + transform.position).normalized * magn *
                            1.2f * speed);
                if (isBot) Instantiate(botHitFX, collision.contacts[0].point + Vector3.up * 0.5f, Quaternion.identity);
                else if (meshRenderer.isVisible)
                {

                    if (magn > 35)
                    {
                        HitColor hit = Instantiate(bigHitFX, collision.contacts[0].point + Vector3.up * 0.5f,
                            Quaternion.identity);
                        Color color = meshRenderer.material.color;
                        Color.RGBToHSV(color, out float h, out float u, out float e);
                        hit.color = Color.HSVToRGB(h, u, 1);
                    }
                    else
                    {
                        HitColor hit = Instantiate(hitFX, collision.contacts[0].point + Vector3.up * 0.5f,
                            Quaternion.identity);
                        Color color = meshRenderer.material.color;
                        Color.RGBToHSV(color, out float h, out float u, out float e);
                        hit.color = Color.HSVToRGB(h, u, 1);
                    }
                }
            }
        }

        public void FeedbackHealth()
        {
            healtyLineAnim.Play();
        }

        public void FeedbackAddHp(bool isBot = false)
        {
            if (!isBot)
            {
                animator.SetTrigger("Hit");
                sounder.PlayOuch();
            }
            DamageAnim.Play();
        }

        public void FeedbackDeath()
        {
            Instantiate(smokeFX, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        public void FeedbackCoin()
        {
            CoinAnim.gameObject.SetActive(true);
            CoinAnim.Play();
        }

        public void FeedbackAddPoint()
        {
            animator.SetTrigger("Point");
        }

        public void FeedbackAddLevel()
        {
            animator.SetTrigger("Level");
        }

        public void TimeShift()
        {
            var time = 1f;
            DOTween.To(() => time, x => time = x, 0.5f, 0.5f).OnUpdate(() =>
            {
                Time.timeScale = time;
            }).OnComplete(() =>
            {
                DOTween.To(() => time, x => time = x, 1, 0.05f).OnUpdate(() =>
                {
                    Time.timeScale = time;
                });
            });
        }
    }
}