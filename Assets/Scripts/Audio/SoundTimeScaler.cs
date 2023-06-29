using UnityEngine;

namespace Scripts.Audio
{
    public class SoundTimeScaler : MonoBehaviour
    {
        AudioSource audio;
        float scale;
        void Start()
        {
            audio = GetComponent<AudioSource>();
            scale = audio.pitch;
        }

        // Update is called once per frame
        void Update()
        {
            audio.pitch = scale * Time.timeScale;
        }
    }
}
