using UnityEngine;

namespace Scripts.Audio
{
    public class VibroSounder : MonoBehaviour
    {
        AudioSource audioSource;
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Interface(AudioClip audio)
        {
            audioSource.PlayOneShot(audio);
        }
        public void Soft(AudioClip audio)
        {
            audioSource.PlayOneShot(audio);
        }
    }
}
