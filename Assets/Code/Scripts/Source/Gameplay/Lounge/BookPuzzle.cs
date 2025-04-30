using System.Collections.Generic;
using Code.Scripts.Source.GameFSM.States;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Code.Scripts.Source.Gameplay.Lounge
{
    public class BookPuzzle : MonoBehaviour
    {
        
        public List<XRSocketInteractor> BookSockets = new List<XRSocketInteractor>(5);
        public List<string> CorrectBookPlacement = new List<string>(5);
        public bool PuzzleSolved = false;
        public bool FusePlugged = false;
        public GameObject puzzleMessage; 

        private void OnEnable()
        {
            GameStateLoungePhase2.OnSocketChanged += CheckPuzzle;
            GameStateLoungePhase2.OnFusePlugged += PlugFuseCheck;
        }

        private void OnDisable()
        {
            GameStateLoungePhase2.OnSocketChanged -= CheckPuzzle;
            GameStateLoungePhase2.OnFusePlugged -= PlugFuseCheck;
        }

        private void CheckPuzzle()
        {
            Debug.Log("Checking Puzzle");
            if (PuzzleSolved || !FusePlugged) return;

            for (int i = 0; i < BookSockets.Count; i++)
            {
                if (!BookSockets[i].hasSelection) return;

                GameObject selected = BookSockets[i].GetOldestInteractableSelected().transform.gameObject;
                Book book = selected.GetComponent<Book>();

                if (book == null || book.BookName != CorrectBookPlacement[i]) return;
            }

            PuzzleSolved = true;
            Debug.Log(" Puzzle terminé");
            puzzleMessage.SetActive(true);
        }

        private void PlugFuseCheck(bool fuseIsPlugged)
        {
            FusePlugged = fuseIsPlugged;
        }
        
    }
}
