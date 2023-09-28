using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private DoorController[] doors;
    private bool isOpened = false;

    public bool requiresKey = false;
    public KeyName requiredKey;
    private void Start()
    {
        doors = GetComponentsInChildren<DoorController>();
    }

    public void OpenDoors()
    {
        if (isOpened) return;

        if (!requiresKey || (requiresKey && PlayerInventory.HasKey(requiredKey.name)))
        {
            isOpened = true;
            foreach (DoorController controller in doors)
            {
                controller.OpenDoor();
            }
        }
    }
}
