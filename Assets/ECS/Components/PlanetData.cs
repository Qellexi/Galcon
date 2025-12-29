using Unity.Entities;

public struct PlanetData : IComponentData
{
    public int Units;
    public OwnerId Owner;
    public float GrowthRate;
}
