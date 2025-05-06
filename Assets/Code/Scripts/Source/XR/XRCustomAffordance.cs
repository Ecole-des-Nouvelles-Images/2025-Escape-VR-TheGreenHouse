using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRCustomAffordance : MonoBehaviour
{
    [SerializeField] private Material _highlightMaterial;

    private Renderer objectRenderer;
    private XRBaseInteractable interactable;
    private Material _initialMaterial;
    void Awake()
    {
        objectRenderer = GetComponentInParent<Renderer>();
        _initialMaterial = objectRenderer.material;
        interactable = GetComponentInParent<XRBaseInteractable>();
    }

    private void OnEnable()
    {
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
    }

    private void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.hoverExited.RemoveListener(OnHoverExit);
    }


    void OnHoverEnter(HoverEnterEventArgs args)
    {
        objectRenderer.material = _highlightMaterial;
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        objectRenderer.material = _initialMaterial;
    }
}
