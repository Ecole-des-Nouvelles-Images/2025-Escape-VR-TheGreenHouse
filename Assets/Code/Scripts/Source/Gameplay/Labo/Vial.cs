using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Scripts.Source.Gameplay.Labo
{
    public class Vial : MonoBehaviour
    {
        public enum PotionType
        {
            Tulénium,
            Yzora,
            Morazium,
            Veridox,
            Agent,
            Base
        }

        [SerializeField] public PotionType _potionType;
        public float correctQuantitative
        {
            get
            {
                switch (_potionType)
                {
                    case PotionType.Tulénium:
                        return 0.25f;
                    case PotionType.Yzora:
                        return 0.75f;
                    case PotionType.Morazium:
                        return 0.50f;
                    case PotionType.Veridox:
                        return 1f;
                    case PotionType.Agent:
                        return 0.5f;
                    case PotionType.Base:
                        return 1f;
                    default:
                        return 0f;
                }
            }
        }

        public void Initialize(PotionType type)
        {
            _potionType = type;
        }
    }
}