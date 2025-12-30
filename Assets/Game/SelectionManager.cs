using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;
    public GameObject unitPrefab;

    private PlanetSelection selected;

    void Awake()
    {
        Instance = this;
    }

    public void OnPlanetClicked(PlanetSelection planet)
    {
        if (selected == null)
        {
            selected = planet;
            selected.Select();
            return;
        }

        if (selected == planet)
        {
            PlanetSelection.DeselectAll();
            selected = null;
            return;
        }

        SendUnits(selected, planet);
        PlanetSelection.DeselectAll();
        selected = null;
    }

    public void SendUnits(PlanetSelection fromSel, PlanetSelection toSel)
    {
        var fromUnits = fromSel.GetComponent<PlanetUnits>();
        var toUnits = toSel.GetComponent<PlanetUnits>();
        var fromLogic = fromSel.GetComponent<PlanetLogic>();
        var toLogic = toSel.GetComponent<PlanetLogic>();

        if (fromUnits.units <= 1) return;

        int amount = fromUnits.units / 2;
        fromUnits.TakeUnits(amount);

        if (toLogic.owner == fromLogic.owner)
        {
            toUnits.AddUnits(amount);
        }
        else
        {
            int left = toUnits.units - amount;
            if (left > 0)
            {
                toUnits.TakeUnits(amount);
            }
            else
            {
                toUnits.TakeUnits(toUnits.units);
                toLogic.SetOwner(fromLogic.owner);
                toUnits.AddUnits(Mathf.Max(1, -left));
            }
        }

        SpawnVisualUnits(fromSel.transform.position, toSel.transform.position, amount);
    }

    void SpawnVisualUnits(Vector3 start, Vector3 end, int amount)
    {
        int count = Mathf.Min(amount, 30);
        for (int i = 0; i < count; i++)
        {
            var unit = Instantiate(unitPrefab);
            var move = unit.GetComponent<UnitMove>();
            if (move != null)
            {
                Vector3 jitter = Random.insideUnitCircle * 0.2f;
                move.Init(start + jitter, end);
            }
        }
    }
}
