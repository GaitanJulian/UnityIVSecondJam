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

    private void Start()
    {
        currentFuel = startFuel; // Initialize current fuel to maximum
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

        // Adjust the scale of the candle particles
        if (candleParticles != null)
        {
            float newParticleScale = Mathf.Max(0.5f, 1f * normalizedFuel); // Minimum 0.5
            candleParticles.transform.localScale = new Vector3(1f, newParticleScale, 1f);
            candleParticles.transform.position = topBodyCandle.transform.position;
        }

        // Adjust light range
        if (candleLight != null)
        {
            float newLightRange = Mathf.Max(2.5f, 3.5f * normalizedFuel); // Minimum 2.5
            candleLight.range = newLightRange;
        }
    }
 
    private void CandleOutOfFuel()
    {
        candleParticles.SetActive(false);
        candleLight.gameObject.SetActive(false);
    }

    public void RefillCandle()
    {
        // Method to refill the candle to its maximum fuel capacity
        currentFuel = maxFuel;
    }
}
