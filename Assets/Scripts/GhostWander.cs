using UnityEngine;

public class GhostWander : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionInterval = 3f;

    private Vector3 direction;

    void Start()
    {
        PickNewDirection();
        InvokeRepeating("PickNewDirection", changeDirectionInterval, changeDirectionInterval);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void PickNewDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        direction = new Vector3(x, 0f, z).normalized;
    }
}
