using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleFuel : MonoBehaviour
{
    public float maxFuel = 150.0f; // Maximum fuel duration in seconds (1 minute in this example)
    public float startFuel = 40f;
    public float fuelConsumptionRate = 1.0f; // Rate at which the candle consumes fuel per second

    public GameObject candleBody;
    public GameObject candleTip;

    public Transform bottomBodyCandle;
    public Transform topBodyCandle;
    public Transform topOfTheContainer;


    private float currentFuel; // Current fuel duration

    // Candle components
    public Light candleLight;
    public GameObject candleParticles;

    private UIManager manager;

    private void Start()
    {
        currentFuel = startFuel; // Initialize current fuel to maximum
        manager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        // Check if there's still fuel left
        if (currentFuel > 0)
        {
            // Reduce current fuel over time
            currentFuel -= fuelConsumptionRate * Time.deltaTime;

            updateCandleVisuals();

            // Check if the candle is out of fuel
            if (currentFuel <= 0)
            {
                // Handle candle being out of fuel (e.g., turn off the candle)
                CandleOutOfFuel();
            }
        }
    }

    private void updateCandleVisuals()
    {
        float normalizedFuel = Mathf.Clamp01(currentFuel / maxFuel);
       
        float positionDifference = bottomBodyCandle.position.y - topOfTheContainer.position.y;

        float newYScale = normalizedFuel;

        candleBody.transform.localScale = new Vector3(1f, newYScale, 1f);

        Vector3 bodyPositon = candleBody.transform.localPosition;

        candleBody.transform.localPosition = new Vector3 (bodyPositon.x, bodyPositon.y - positionDifference, bodyPositon.z);

        candleTip.transform.position = topBodyCandle.position;


        // Adjust light range
        /*
        if (candleLight != null)
        {
            float newLightRange = Mathf.Max(2.5f, 3.5f * normalizedFuel); // Minimum 2.5
            candleLight.range = newLightRange;
        }
        */

        // Calculate light intensity based on normalizedFuel
        if (candleLight != null)
        {
            // Define the minimum and maximum intensity values
            float minIntensity = 0.1f;
            float maxIntensity = 1.0f;

            // Calculate the intensity based on normalizedFuel
            float newIntensity = Mathf.Lerp(minIntensity, maxIntensity, normalizedFuel);

            // Set the light intensity
            candleLight.intensity = newIntensity;
        }
    }
 
    private void CandleOutOfFuel()
    {
        candleParticles.SetActive(false);
        candleLight.gameObject.SetActive(false);
        manager.HandleGameOver();
    }

    public void RefillCandle()
    {
        // Method to refill the candle to its maximum fuel capacity
        currentFuel = maxFuel;
    }
}
