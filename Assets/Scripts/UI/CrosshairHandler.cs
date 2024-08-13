using StarterAssets;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CrosshairHandler : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs inputs;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color interactColor;

    private Image crosshair;

    private bool canInteract = false;

    private void Start()
    {
        crosshair = GetComponent<Image>();
        crosshair.color = defaultColor;
    }

    private void Update()
    {
        HandleRaycast();

        HandleCrosshair();
    }

    private void HandleCrosshair()
    {
        if (canInteract && crosshair.color != interactColor)
        {
            crosshair.color = interactColor;
        }
        else if (!canInteract && crosshair.color != defaultColor)
        {
            crosshair.color = defaultColor;
        }
    }

    private void HandleRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, inputs.maxInteractionDistance))
        {
            if (hit.collider.CompareTag("Target"))
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
        else
        {
            canInteract = false;
        }
    }
}
