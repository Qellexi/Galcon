using UnityEngine;

public class PlanetClick : MonoBehaviour
{
    void OnMouseDown()
    {
        var sel = GetComponent<PlanetSelection>();
        if (sel != null)
            SelectionManager.Instance.OnPlanetClicked(sel);
    }
}
