using UnityEngine;

public class WSClient : MonoBehaviour
{
    public static WSClient Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SendMoveCommand(
        PlanetSelection from,
        PlanetSelection to,
        int amount)
    {
        if (from == null || to == null || amount <= 0)
            return;

        ExecuteMove(from, to, amount);
    }

    void ExecuteMove(
        PlanetSelection from,
        PlanetSelection to,
        int amount)
    {
        if (SelectionManager.Instance == null)
            return;

        SelectionManager.Instance.SendUnits(from, to);
    }
}
