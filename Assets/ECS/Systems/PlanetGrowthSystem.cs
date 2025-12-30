using Unity.Entities;
using UnityEngine;

public partial class PlanetGrowthSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float dt = Time.DeltaTime;

        Entities.ForEach((ref PlanetComponent planet) =>
        {
            if (planet.OwnerId == 0) return;

            planet.Units += Mathf.FloorToInt(planet.GrowthRate * dt);
            planet.Units = Mathf.Min(planet.Units, planet.MaxUnits);
        }).Run();
    }
}
