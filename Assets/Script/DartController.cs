using UnityEngine;

public class DartController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Vector3 targetPosition;

    public void Initialize(Vector3 target)
    {
        targetPosition = target;
        transform.LookAt(target);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (0 <= transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            speed = 0;
            Destroy(gameObject);
        }
    }
}