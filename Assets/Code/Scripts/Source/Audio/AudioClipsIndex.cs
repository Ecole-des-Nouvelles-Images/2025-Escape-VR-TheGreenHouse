using System;
using UnityEngine;

namespace Code.Scripts.Source.Audio
{
    [Serializable]
    public class AudioClipsIndex
    {
        // TODO: All audio clips of the project

        [Header("UI")]
        [field:SerializeField] public AudioClip UIButtonSelected { get; private set; }
        [field:SerializeField] public AudioClip UIButtonHoverEnter { get; private set; }
        [field:SerializeField] public AudioClip UIButtonHoverExit { get; private set; }

        [Header("Hall")]
        [field:SerializeField] public AudioClip CaseHammering { get; private set; }
        [field:SerializeField] public AudioClip CaseOpening { get; private set; }
    }
}
