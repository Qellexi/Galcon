using UnityEngine;

[RequireComponent(typeof(PlanetUnits))]
public class PlanetLogic : MonoBehaviour
{
    public OwnerId owner = OwnerId.Neutral;
    public int maxUnits = 200;
    public float growthPerSecond = 1f;

    private PlanetUnits units;
    private float accumulator;

    void Awake()
    {
        units = GetComponent<PlanetUnits>();
    }

    void Update()
    {
        if (owner == OwnerId.Neutral) return;

        accumulator += growthPerSecond * Time.deltaTime;
        int add = Mathf.FloorToInt(accumulator);

        if (add > 0)
        {
            accumulator -= add;
            units.AddUnits(Mathf.Min(add, maxUnits - units.units));
        }
    }

    public void SetOwner(OwnerId newOwner)
    {
        owner = newOwner;

        var sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        sr.color = newOwner switch
        {
            OwnerId.Player => Color.cyan,
            OwnerId.AI => Color.red,
            _ => Color.gray
        };
    }
}
