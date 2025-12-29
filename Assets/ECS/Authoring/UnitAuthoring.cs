using UnityEngine;
using Unity.Entities;

public class UnitAuthoring : MonoBehaviour
{
    public float speed = 5f;

    class Baker : Baker<UnitAuthoring>
    {
        public override void Bake(UnitAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new UnitData
            {
                Speed = authoring.speed
            });
        }
    }
}
