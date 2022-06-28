using UnityEngine;
using UnityEngine.Audio;

namespace SpaceMobile
{
    public class MasterMixer : MonoBehaviour
    {
        [SerializeField] private AudioMixer masterMixer;

        public void SetSoundLvl(float soundLvl)
        {
            masterMixer.SetFloat("Sound", soundLvl);
        }


        public void SetMusicLvl(float musicLvl)
        {
            masterMixer.SetFloat("Music", musicLvl);
        }
    }
}
