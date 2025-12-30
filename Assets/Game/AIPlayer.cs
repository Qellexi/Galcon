using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public float thinkEvery = 1.2f;
    public int minUnitsToAttack = 10;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < thinkEvery) return;
        timer = 0f;

        PlanetLogic from = null;
        int best = minUnitsToAttack;

        foreach (var p in FindObjectsOfType<PlanetLogic>())
        {
            if (p.owner != OwnerId.AI) continue;

            int u = p.GetComponent<PlanetUnits>().units;
            if (u >= best)
            {
                best = u;
                from = p;
            }
        }

        if (from == null) return;

        PlanetLogic to = null;
        int weakest = int.MaxValue;

        foreach (var p in FindObjectsOfType<PlanetLogic>())
        {
            if (p.owner == OwnerId.AI) continue;

            int u = p.GetComponent<PlanetUnits>().units;
            if (u < weakest)
            {
                weakest = u;
                to = p;
            }
        }

        if (to == null) return;

        SelectionManager.Instance.SendUnits(
            from.GetComponent<PlanetSelection>(),
            to.GetComponent<PlanetSelection>()
        );
    }
}
