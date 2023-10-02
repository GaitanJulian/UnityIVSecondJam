using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    protected Quaternion initialRotation;
    protected Quaternion targetRotation;
    protected bool isOpening = false;

    public float maxAngle = 90f;
    public float openSpeed = 2f;

    virtual protected void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation;
    }

    virtual public void OpenDoor()
    {
        if (!isOpening)
        {
            targetRotation *= Quaternion.Euler(0, maxAngle, 0);
            StartCoroutine(AnimateDoor());
        }
    }

    private IEnumerator AnimateDoor()
    {
        isOpening = true;
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, openSpeed * Time.deltaTime);
            yield return null;
        }
        isOpening = false;
    }
}
