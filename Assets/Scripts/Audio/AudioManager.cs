using UnityEngine;

namespace SpaceMobile
{
    public class AudioManager: MonoBehaviour
    {
        [SerializeField] private AudioSource[] music;

        private void Start()
        {
            music[2].Play();
        }

        public void PlayMusic(int number)
        {
            music[number].Play();
        }

        public void PlayMusic(int numberStop, int numberPlay)
        {
            music[numberStop].Stop();
            music[numberPlay].Play();
        }

        public void PlayMusic(int numberStop, int numberPlay_0, int numberPlay_1)
        {
            music[numberStop].Stop();
            music[numberPlay_0].Play();
            music[numberPlay_1].Play();
        }

        public void PlayMusic(int numberStop_0, int numberStop_1, int numberPlay_0, int numberPlay_1)
        {
            music[numberStop_0].Stop();
            music[numberStop_1].Stop();
            music[numberPlay_0].Play();
            music[numberPlay_1].Play();
        }

        public void StopMusic(int number)
        {
            music[number].Stop();
        }

        public void PauseMusic()
        {
            music[2].Pause();
        }

        public void UnPauseMusic()
        {
            music[2].UnPause();
        }
    }
}
