using UnityEngine;

public class TargetController : MonoBehaviour
{
    
    private void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dart"))
        {
            print("Hit");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            print("Hit");
            Destroy(gameObject);
        }
    }
}
