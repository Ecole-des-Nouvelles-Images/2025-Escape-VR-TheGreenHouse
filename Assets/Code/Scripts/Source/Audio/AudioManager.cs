using Code.Scripts.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Code.Scripts.Source.Audio
{
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [Space]
        [SerializeField] private AudioMixer _mixerSystem;

        [Space]
        public AudioClipsIndex ClipsIndex;

        [Header("Initial Mix")]
        [SerializeField] [Range(0, 1)] private float _initialMasterVolume = 0.5f;
        [SerializeField] [Range(0, 1)] private float _initialAmbienVolume = 1f;
        [SerializeField] [Range(0, 1)] private float _initialSFXVolume = 1f;

        [Header("Mixer Groups")]
        [field:SerializeField] public AudioMixerGroup MasterMixerModule;
        [field:SerializeField] public AudioMixerGroup AmbientMixerModule;
        [field:SerializeField] public AudioMixerGroup SFXMixerModule;

        private static readonly string MasterVolumeParameter = "VolumeMaster";
        private static readonly string AmbientVolumeParameter = "VolumeAmbient";
        private static readonly string SFXVolumeParameter = "VolumeSFX";

        private float _masterVolume;
        public float MasterVolume {
            get => _masterVolume;

            set {
                _masterVolume = value;
                UpdateVolume(MasterVolumeParameter, value);
            }
        }

        private float _ambientVolume;
        public float AmbientVolume {
            get => _ambientVolume;

            set {
                _ambientVolume = value;
                UpdateVolume(AmbientVolumeParameter, value);
            }
        }

        private float _sfxVolume;
        public float SFXVolume {
            get => _sfxVolume;

            set {
                _sfxVolume = value;
                UpdateVolume(SFXVolumeParameter, value);
            }
        }

        private void Awake()
        {
            MasterVolume = _initialMasterVolume;
            AmbientVolume = _initialAmbienVolume;
            SFXVolume = _initialSFXVolume;
        }

        /// <summary>
        /// Update the appropriate volume referenced as an exposed mixer parameter
        /// </summary>
        /// <remarks>🛈 The function is called upon setting the Volume properties and shouldn't be used as-is</remarks>
        /// <param name="mixerParameter">Name of the exposed mixer parameter to modify.</param>
        /// <param name="value">Normalized volume (automatically clamped between [0,1])</param>
        private void UpdateVolume(string mixerParameter, float value)
        {
            float decibels = -80 * (1 - Mathf.Clamp(value, 0, 1));

            _mixerSystem.SetFloat(mixerParameter, decibels);
        }

        /// <summary>
        /// Update manually the appropriate volume referenced as an exposed mixer parameter
        /// </summary>
        /// <remarks>⚠ Use with caution as volume value can exceed 1</remarks>
        /// <param name="mixerParameter">Name of the exposed mixer parameter to modify</param>
        /// <param name="value">Unclamped normalized volume</param>
        public void UpdateVolumeUnclamped(string mixerParameter, float value)
        {
            float decibels = -80 * (1 - value);

            _mixerSystem.SetFloat(mixerParameter, decibels);
        }
    }
}
