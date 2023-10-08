using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteraction : Interactable
{
    public GameObject noteObject;
    public GameObject cameraNote;

    private bool isNoteVisible = false;

    public GameObject replacementNote;
    private Material originalMaterial;


    public override void Interact()
    {
        ToggleNoteVisibility(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cameraNote.SetActive(false);
            replacementNote.SetActive(false);
        }
    }

    private void ToggleNoteVisibility(bool isVisible)
    {
        isNoteVisible = isVisible;

        // Display a message in the UI
        string message = "Picked up the note";
        UIManager.Instance.StartDisplayingMessage(message, 1f);
        originalMaterial = noteObject.GetComponent<Renderer>().material;

        if (isVisible)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            replacementNote.GetComponent<Renderer>().material = originalMaterial;
            cameraNote.SetActive(true);
            replacementNote.SetActive(true);
        }
    }

    public bool IsNoteVisible()
    {
        return isNoteVisible;
    }
}
