using System.Collections.Generic;
using Code.Scripts.Source.Gameplay.Lounge;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BookPuzzleManager : MonoBehaviour
{
    public List<XRSocketInteractor> slots;
    public List<string> correctOrder;

    public bool puzzleSolved = false;

    private void OnEnable()
    {
        BookSocket.OnAnySocketChanged += CheckPuzzle;
    }

    private void OnDisable()
    {
        BookSocket.OnAnySocketChanged -= CheckPuzzle;
    }

    private void CheckPuzzle()
    {
        if (puzzleSolved) return;

        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].hasSelection) return;

            GameObject selected = slots[i].GetOldestInteractableSelected().transform.gameObject;
            Book book = selected.GetComponent<Book>();

            if (book == null || book.bookName != correctOrder[i])
                return;
        }

        puzzleSolved = true;
        Debug.Log(" Puzzle terminé");
       
    }
}
