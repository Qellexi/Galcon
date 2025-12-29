using UnityEngine;
using Unity.Entities;

public class PlanetAuthoring : MonoBehaviour
{
    public int startUnits = 10;
    public OwnerId owner = OwnerId.Neutral;
    public float growthRate = 1f;

    class Baker : Baker<PlanetAuthoring>
    {
        public override void Bake(PlanetAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new PlanetData
            {
                Units = authoring.startUnits,
                Owner = authoring.owner,
                GrowthRate = authoring.growthRate
            });
        }
    }
}
