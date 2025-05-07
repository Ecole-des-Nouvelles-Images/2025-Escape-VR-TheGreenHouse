using Code.Scripts.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Code.Scripts.Source.Audio
{
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [Header("Mixer system")]
        [SerializeField] private AudioMixer _mixer;

        [Space]
        public AudioClipsIndex ClipsIndex;

        [Header("Volume")]
        [SerializeField] [Range(0, 1)] private float _initialAmbienVolume = 0.5f;
        [SerializeField] [Range(0, 1)] private float _initialSFXVolume = 0.5f;

        [field:SerializeField] public AudioMixerGroup Master;
        [field:SerializeField] public AudioMixerGroup SFX;
        [field:SerializeField] public AudioMixerGroup Ambient;

        private static readonly string AmbientVolumeParameter = "VolumeAmbient";
        private static readonly string SFXVolumeParameter = "VolumeSFX";

        private float _ambientVolume;
        public float AmbientVolume {
            get => _ambientVolume;

            set {
                _ambientVolume = value;
                UpdateVolume(AmbientVolumeParameter, value);
            }
        }

        private float _sfxVolume;

        public AudioManager(AudioClipsIndex clipsIndex)
        {
            ClipsIndex = clipsIndex;
        }

        public float SFXVolume {
            get => _sfxVolume;

            set {
                _sfxVolume = value;
                UpdateVolume(SFXVolumeParameter, value);
            }
        }

        public void UpdateVolume(string mixerParameter, float value)
        {
            float decibels = -80 * (1 - value);

            _mixer.SetFloat(mixerParameter, decibels);
        }
    }
}
