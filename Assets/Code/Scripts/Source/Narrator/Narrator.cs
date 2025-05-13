using Code.Scripts.Utils;
using UnityEngine;

namespace Code.Scripts.Source.Narrator
{
    [RequireComponent(typeof(AudioSource))]
    public class Narrator: MonoBehaviourSingleton<Narrator>
    {
        private AudioSource _audioSource;


    }
}
