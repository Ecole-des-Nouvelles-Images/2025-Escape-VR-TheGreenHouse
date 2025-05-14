using System;
using UnityEngine;
using System.Linq;

namespace Code.Scripts.Source.Gameplay.Labo
{
    public class MixRules
    {
        public static PotionType TryMix(Vial vial1, Vial vial2)
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
    }
}
