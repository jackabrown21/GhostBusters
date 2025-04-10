using UnityEngine;

public class GhostWander : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionInterval = 3f;

    public Vector3 minPosition = new Vector3(-5f, 0f, -5f);
    public Vector3 maxPosition = new Vector3(5f, 0f, 5f);

    private Vector3 direction;

    void Start()
    {
        PickNewDirection();
        InvokeRepeating("PickNewDirection", changeDirectionInterval, changeDirectionInterval);
    }

    void Update()
    {
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

        if (newPosition.x < minPosition.x || newPosition.x > maxPosition.x)
        {
            direction.x *= -1;
            newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        }
        if (newPosition.z < minPosition.z || newPosition.z > maxPosition.z)
        {
            direction.z *= -1;
            newPosition.z = Mathf.Clamp(newPosition.z, minPosition.z, maxPosition.z);
        }

        transform.position = newPosition;
    }

    void PickNewDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        direction = new Vector3(x, 0f, z).normalized;
    }
}
