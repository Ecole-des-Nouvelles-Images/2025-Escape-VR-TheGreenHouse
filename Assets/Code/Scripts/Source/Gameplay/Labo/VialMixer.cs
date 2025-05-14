using System;
using UnityEngine;
using VRTemplateAssets.Scripts;

namespace Code.Scripts.Source.Gameplay.Labo
{
    public class VialMixer : MonoBehaviour
    {
        [SerializeField] private Vial _vial1;
        [SerializeField] private Vial _vial2;
        [SerializeField] private XRKnob _dial1;
        [SerializeField] private XRKnob _dial2;


        private Vial _resultVial;

        private void Start()
        {
            _dial1.onValueChange.AddListener((value) => OnDialMoved(_vial1, value));
            _dial2.onValueChange.AddListener((value) => OnDialMoved(_vial2, value));
        }

        [ContextMenu("Mix Vials")]
        private void MixVials()
        {
            try
            {
                TryMix(_vial1, _vial2);
            }
            catch (Exception e)
            {
                Debug.LogWarning("ERREUR");
            }
        }
        
        private PotionType TryMix(Vial vial1, Vial vial2)
        {
            int resultVial = vial1.Properties.Index + vial2.Properties.Index;

            if (Mathf.Approximately(vial1.Properties.CurrentDose, vial1.Properties.CorrectDose)
                && Mathf.Approximately(vial2.Properties.CurrentDose, vial2.Properties.CorrectDose))
            {
                switch (resultVial)
                {
                    case 11 :
                        return PotionType.Agent;
                    case 15 :
                        return PotionType.Base;
                    case 26:
                        // TODO: PotionType.Final;
                        break;
                    default:
                        throw new Exception("TryMix result in trash vial"); // TODO: Implement PotionType.Trash;
                };
            }
            throw new Exception("TryMix result bad dosage"); // TODO: Implement PotionType.Trash; // Replace when ready;
        }
        

        private void OnDialMoved(Vial vial, float value)
        {
            value = Mathf.Clamp(value, 0f, 1f);
            int stepIndex = Mathf.RoundToInt(value * 3); 
            switch (stepIndex)
            {
                case 0:
                    // 25%
                    break;
                case 1:
                    // 50%
                    break;
                case 2:
                    // 75%
                    break;
                case 3:
                    // 100%
                    break;
            }

            Debug.Log($"OnDialMoved {value}");

        }
    }
}