using System;
using UnityEngine;

namespace Code.Scripts.Source.Audio
{
    [Serializable]
    public class AudioClipsIndex
    {
        // TODO: All audio clips of the project

        [field:SerializeField] public AudioClip UIButtonSelected { get; private set; }
        [field:SerializeField] public AudioClip UIButtonHoverEnter { get; private set; }
        [field:SerializeField] public AudioClip UIButtonHoverExit { get; private set; }
    }
}
