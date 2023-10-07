using UnityEngine;
using UnityEngine.UI;

public class CandleInteraction : Interactable
{
    private CandleFuel candleFuel;

    protected override void Start()
    {
        base.Start();
        candleFuel = FindObjectOfType<CandleFuel>();
    }

    public override void Interact()
    {
        RefillCandle();
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
