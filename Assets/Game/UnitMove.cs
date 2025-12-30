using UnityEngine;

public class UnitMove : MonoBehaviour
{
    Vector3 target;
    float speed;
    float wobbleOffset;

    public void Init(Vector3 from, Vector3 to)
    {
        transform.position = from;
        target = to;
        speed = Random.Range(3.5f, 6f);
        wobbleOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        float wobble = Mathf.Sin(Time.time * 8f + wobbleOffset) * 0.1f;
        Vector3 dir = (target - transform.position).normalized;
        Vector3 side = new Vector3(-dir.y, dir.x, 0f);

        transform.position = Vector3.MoveTowards(
            transform.position,
            target + side * wobble,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.05f)
            Destroy(gameObject);
    }
}
