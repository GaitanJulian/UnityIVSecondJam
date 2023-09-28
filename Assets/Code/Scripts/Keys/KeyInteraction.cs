using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public KeyName keyName; // Unique identifier for the key
    public void Addkey()
    {
        // Add the key to the player's inventory
        PlayerInventory.AddKey(this);

        // Optionally, you can play a pickup sound or animation here

        // Destroy the key object
        Destroy(gameObject);
    }
}
