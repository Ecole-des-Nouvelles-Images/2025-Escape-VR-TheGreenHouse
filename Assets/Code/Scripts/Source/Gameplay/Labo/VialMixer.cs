using UnityEngine;

namespace Code.Scripts.Source.Gameplay.Labo
{
    public class VialMixer : MonoBehaviour
    {
        private Vial _vial1;
        private Vial _vial2;


        private bool IsValidMix(Vial vial1, Vial vial2)
        {
            return ((vial1._potionType == Vial.PotionType.Tulénium && vial2._potionType == Vial.PotionType.Yzora) ||
                    (vial1._potionType == Vial.PotionType.Yzora && vial2._potionType == Vial.PotionType.Tulénium) ||
                    (vial1._potionType == Vial.PotionType.Morazium && vial2._potionType == Vial.PotionType.Veridox) ||
                    (vial1._potionType == Vial.PotionType.Veridox && vial2._potionType == Vial.PotionType.Morazium));
        }

        private Vial.PotionType GetMixResultType(Vial vial1, Vial vial2)
        {
            if ((vial1._potionType == Vial.PotionType.Tulénium && vial2._potionType == Vial.PotionType.Yzora) ||
                (vial1._potionType == Vial.PotionType.Yzora && vial2._potionType == Vial.PotionType.Tulénium))
                return Vial.PotionType.Agent;

            if ((vial1._potionType == Vial.PotionType.Morazium && vial2._potionType == Vial.PotionType.Veridox) ||
                (vial1._potionType == Vial.PotionType.Veridox && vial2._potionType == Vial.PotionType.Morazium))
                return Vial.PotionType.Base;

            return Vial.PotionType.Tulénium; 
        }

        public void MixVials(Vial vial1, Vial vial2)
        {
            if (!IsValidMix(vial1, vial2)) return;
        }
    }
}
