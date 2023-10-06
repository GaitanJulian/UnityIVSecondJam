using System.Collections.Generic;
using UnityEngine;

public static class PlayerInventory
{
    private static List<KeyInteraction> keys = new List<KeyInteraction>();

    public static void AddKey(KeyInteraction key)
    {
        keys.Add(key);
    }

    public static bool HasKey(string keyName)
    {
        return keys.Exists(key => key.keyName.name == keyName);
    }

    public static void ResetKeys()
    {
        keys.Clear();
    }
}
