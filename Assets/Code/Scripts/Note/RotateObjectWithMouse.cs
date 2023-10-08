using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectWithMouse : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public float minRotationX = -90.0f; // Límite mínimo en el eje X
    public float maxRotationX = 90.0f;  // Límite máximo en el eje X

    private bool isRotating = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Aplicar la rotación en los ejes X e Y, limitando los valores dentro del rango.
            Vector3 rotation = new Vector3(-mouseY, 0, mouseX) * rotationSpeed;
            Vector3 newRotation = transform.eulerAngles + rotation;

            // Limitar la rotación en el eje X entre minRotationX y maxRotationX.
            newRotation.x = Mathf.Clamp(newRotation.x, minRotationX, maxRotationX);

            transform.eulerAngles = newRotation;
        }
    }
}
