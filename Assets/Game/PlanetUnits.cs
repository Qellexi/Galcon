using UnityEngine;
using TMPro;

public class PlanetUnits : MonoBehaviour
{
    public int units = 10;
    public TextMeshPro text;

    void Start()
    {
        UpdateText();
    }

    public void AddUnits(int amount)
    {
        units += amount;
        UpdateText();
    }

    public void TakeUnits(int amount)
    {
        units = Mathf.Max(0, units - amount);
        UpdateText();
    }

    void UpdateText()
    {
        if (text != null)
            text.text = units.ToString();
    }
}
