using UnityEngine;

namespace Scripts.Audio
{
    public class DamageSounder : MonoBehaviour
    {
        public AudioClip[] clip;
        AudioSource audio;
        public bool onetime;
        void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        public void PlayOuch()
        {
            if (onetime) audio.PlayOneShot(clip[Random.Range(0, clip.Length)]);
            else if (!audio.isPlaying) audio.PlayOneShot(clip[Random.Range(0, clip.Length)]);
        }
    }
}
