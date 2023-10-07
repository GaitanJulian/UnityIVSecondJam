using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    protected Outline outline;

    protected virtual void Start()
    {
        outline = GetComponentInChildren<Outline>();
        ToggleOutline(false);
    }

    public abstract void Interact();

    public void ToggleOutline(bool toggle)
    {
        if (outline != null)
        {
            outline.enabled = toggle;
        }
    }
}
