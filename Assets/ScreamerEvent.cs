using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerEvent : MonoBehaviour
{
    private UIManager _manager;
    int defaultLayer;

    private void Start()
    {
        _manager = FindObjectOfType<UIManager>();
        defaultLayer   = LayerMask.NameToLayer("Default");
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
}
