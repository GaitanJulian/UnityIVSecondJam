using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public KeyName keyName; // Unique identifier for the key
    public void Addkey()
    {
        // Add the key to the player's inventory
        PlayerInventory.AddKey(this);

        // Display a message in the UI
        string message = "Picked up " + keyName.roomName + " key";
        UIManager.Instance.StartDisplayingMessage(message, 1f);

        // Optionally, you can play a pickup sound or animation here

        // Destroy the key object
        Destroy(gameObject);
    }
}
