using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleWobble : MonoBehaviour
{
    public float swayIntensityX;
    public float swayIntensityY;
    public float maxSway;
    public float minSway;

    public BobOverride[] bobOverrides;

    public Transform candle;

    [HideInInspector]
    public float currentSpeed;

    private float currentTimeX;
    private float currentTimeY;
    
    private float xPos;
    private float yPos;

    private Vector3 smoothV;

    private void Update() {
        foreach (BobOverride bob in bobOverrides) {
            if (currentSpeed >= bob.minSpeed && currentSpeed <= bob.maxSpeed) {
                float bobMultiplier = (currentSpeed == 0) ? 1 : currentSpeed;

                currentTimeX += bob.speedX / 10 * Time.deltaTime * bobMultiplier;
                currentTimeY += bob.speedY / 10 * Time.deltaTime * bobMultiplier;

                xPos = bob.bobX.Evaluate(currentTimeX) * bob.intensityX;
                yPos = bob.bobY.Evaluate(currentTimeY) * bob.intensityY;
            }
        }

        
        float xSway = -Input.GetAxis("Mouse X") * swayIntensityX;
        float ySway = -Input.GetAxis("Mouse Y") * swayIntensityY;

        xSway = Mathf.Clamp(xSway, minSway, maxSway);
        ySway = Mathf.Clamp(ySway, minSway, maxSway);

        xPos += xSway;
        yPos += ySway;
        
    }

    private void FixedUpdate() {
        Vector3 target = new Vector3(xPos, yPos, 0);
        Vector3 desiredPos = Vector3.SmoothDamp(candle.localPosition, target, ref smoothV, 0.1f);
        candle.localPosition = desiredPos;
    }

    [System.Serializable]
    public struct BobOverride {
        public float minSpeed;
        public float maxSpeed;

        [Header("X Settings")]
        public float speedX;
        public float intensityX;
        public AnimationCurve bobX;

        [Header("Y Settings")]
        public float speedY;
        public float intensityY;
        public AnimationCurve bobY;
    }
}
