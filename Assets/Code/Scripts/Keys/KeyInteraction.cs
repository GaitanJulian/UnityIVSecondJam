using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour, IInteractable 
{
    public KeyName keyName; // Unique identifier for the key

    public Outline outline;

    public List<AudioClip> keyPickupSounds;

    public void Interact()
    {
        Addkey();
    }

    public void ToggleOutline(bool state)
    {
        if (outline != null)
        {
            outline.enabled = state;
        }
    }

    public void Addkey()
    {
        // Add the key to the player's inventory
        PlayerInventory.AddKey(this);

        // Display a message in the UI
        string message = "Picked up " + keyName.roomName + " key";
        UIManager.Instance.StartDisplayingMessage(message, 1f);

        // Optionally, you can play a pickup sound or animation here
        if (keyPickupSounds.Count > 0)
        {
            int randomSoundIndex = Random.Range(0, keyPickupSounds.Count);
            AudioSource.PlayClipAtPoint(keyPickupSounds[randomSoundIndex], transform.position);
        }

        // Destroy the key object
        Destroy(gameObject);
    }
}
