using UnityEngine;

public class GhostWander : MonoBehaviour
{
    public float speed;                      // Set in Inspector
    public float changeDirectionInterval;    // Set in Inspector

    public Vector3 minPosition;               // Set in Inspector
    public Vector3 maxPosition;               // Set in Inspector

    private Vector3 direction;

    void Start()
{
    // Force starting inside the box
    Vector3 clampedStart = transform.position;
    clampedStart.x = Mathf.Clamp(clampedStart.x, minPosition.x, maxPosition.x);
    clampedStart.z = Mathf.Clamp(clampedStart.z, minPosition.z, maxPosition.z);
    transform.position = clampedStart;

    PickNewDirection();
    InvokeRepeating(nameof(PickNewDirection), changeDirectionInterval, changeDirectionInterval);
}
void OnDrawGizmosSelected()
{
    Gizmos.color = Color.cyan;
    Vector3 center = new Vector3(
        (minPosition.x + maxPosition.x) / 2f,
        transform.position.y,
        (minPosition.z + maxPosition.z) / 2f
    );
    Vector3 size = new Vector3(
        Mathf.Abs(maxPosition.x - minPosition.x),
        0.1f,
        Mathf.Abs(maxPosition.z - minPosition.z)
    );
    Gizmos.DrawWireCube(center, size);
}


    void Update()
    {
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

        if (newPosition.x < minPosition.x || newPosition.x > maxPosition.x)
        {
            direction.x *= -1;
        }
        if (newPosition.z < minPosition.z || newPosition.z > maxPosition.z)
        {
            direction.z *= -1;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.z = Mathf.Clamp(newPosition.z, minPosition.z, maxPosition.z);

        transform.position = newPosition;
    }

    void PickNewDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        direction = new Vector3(x, 0f, z).normalized;
    }
}
