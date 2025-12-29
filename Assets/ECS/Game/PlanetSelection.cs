using UnityEngine;

public class PlanetSelection : MonoBehaviour
{
    private static PlanetSelection current;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Select()
    {
        DeselectAll();
        current = this;
        if (sr != null)
            sr.color *= 1.2f;
    }

    public static void DeselectAll()
    {
        if (current == null) return;

        var sr = current.GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color /= 1.2f;

        current = null;
    }
}
