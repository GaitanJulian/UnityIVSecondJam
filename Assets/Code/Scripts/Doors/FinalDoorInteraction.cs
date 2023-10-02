using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorInteraction : DoorController
{
    public ZoneActiveFinalAnimation finalAnimation;

    // Override the Start method from the base class (DoorController)

    public override void OpenDoor()
    {
        base.OpenDoor();

        finalAnimation.ActivateAnimation();
    }
}
