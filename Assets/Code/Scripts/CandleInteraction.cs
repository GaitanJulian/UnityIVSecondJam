using UnityEngine;
using UnityEngine.UI;

public class CandleInteraction : MonoBehaviour, IInteractable
{
    private CandleFuel candleFuel;
    public Outline outline;

    private void Start()
    {
        candleFuel = FindObjectOfType<CandleFuel>();
    }

    public void Interact()
    {
        RefillCandle();
    }

    public void ToggleOutline(bool state)
    {
        if (outline != null)
        {
            outline.enabled = state;
        }
    }

    private void RefillCandle()
    {
        if (candleFuel != null)
        {
            candleFuel.RefillCandle();
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("CandleFuel script not found!");
        }
    }
}
