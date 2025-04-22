using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SetOptionFromUI : MonoBehaviour
{
    [SerializeField] private Scrollbar _volumeSlider;
    
    private void Start()
    {
        _volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
    }

    private void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }

}
