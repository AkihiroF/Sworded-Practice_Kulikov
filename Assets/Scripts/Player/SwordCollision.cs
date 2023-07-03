using Scripts.BaseComponents;
using UnityEngine;

namespace Scripts.Player
{
    public class SwordCollision : MonoBehaviour
    {
        public GameObject HitFX;
        public BaseHealth bm;
        public GameObject fx;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Sword"))
            {
                if (!bm.IsBot) bm.Defense();

                //Invoke("SetTag", 1.5f);
                float magn = collision.relativeVelocity.magnitude;

                if (magn > 20) Instantiate(HitFX, collision.contacts[0].point + Vector3.up * 0.5f, Quaternion.identity);
            }
        }
    }
}

