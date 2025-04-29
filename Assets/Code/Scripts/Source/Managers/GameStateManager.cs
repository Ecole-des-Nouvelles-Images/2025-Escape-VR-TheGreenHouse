using System.Collections.Generic;
using Code.Scripts.Source.XR;
using NUnit.Framework;
using UnityEngine;

namespace Code.Scripts.Source.Managers
{
    public class GameStateManager: MonoBehaviour
    {
        [Header("Lounge")]
        public List<string> CorrectBookPlacement;
        public List<XRSocketTagInteractor> BookSockets;
        
        
    }
}
