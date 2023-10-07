using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerEvent : MonoBehaviour, IInteractable
{
    private UIManager _manager;
    int defaultLayer;
    bool hasBeenTriggered = false;

    private void Start()
    {
        _manager = FindObjectOfType<UIManager>();
        defaultLayer   = LayerMask.NameToLayer("Default");
    }

    public void Interact ()
    {
        ActivateScreamer();
    }

    public void ToggleOutline(bool state)
    {
        // No outline for Screamers
    }

    public void ActivateScreamer()
    {
        _manager.TriggerScreamer();
        ChangeLayer();
    }

    private void ChangeLayer()
    {
        gameObject.layer = defaultLayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered) 
        {
            ActivateScreamer();
            hasBeenTriggered = true;
        }
        
    }
}
