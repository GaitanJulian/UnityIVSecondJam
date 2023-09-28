using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private DoorController[] doors;
    private bool isOpened = false;

    private void Start()
    {
        doors = GetComponentsInChildren<DoorController>();
    }

    public void OpenDoors()
    {
        if (isOpened) return;  

        isOpened = true;
        foreach (DoorController controller in doors) 
        {
            controller.OpenDoor();
        }
    }
}
