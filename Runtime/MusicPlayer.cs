using UnityEngine;

namespace Utilities
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource musicAudioSource;

        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

            if (objs.Length > 1)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void PlayFromBeginning() 
        {
            musicAudioSource.Play();
        }

        public void Pause() 
        {
            musicAudioSource.Pause();
        }

        public void UnPause() 
        {
            musicAudioSource.UnPause();
        }
    }
}