using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Services
{
    public class AudioService : SingletonMonoBehaviour<AudioService>
    {
        #region Variables

        [SerializeField] private AudioSource _sfxAudioSource;
        [SerializeField] private AudioSource _ostAudioSource;

        #endregion

        #region Public methods

        public void PlaySfx(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }

            _sfxAudioSource.PlayOneShot(clip);
        }
        
        public void PlayOst(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }

            _ostAudioSource.PlayOneShot(clip);
        }

        #endregion
    }
}