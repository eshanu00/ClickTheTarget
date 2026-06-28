using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    [SerializeField] private float maxYaw = 60f;
    [SerializeField] private float maxPitch = 30f;
    [SerializeField] private float rotationSpeed = 10f;

    [SerializeField] private Transform dartOrigin;
    [SerializeField] private GameObject dartPrefab;

    void Update()
    {
        ControlGun();

        if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            new WaitForSeconds(1.0f);
            ShootDart();
        }
    }

    private void ControlGun()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        float yaw = Mathf.Lerp(-maxYaw, maxYaw, mousePos.x / Screen.width);

        float pitch = Mathf.Lerp(0, -maxPitch, mousePos.y / Screen.height);

        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, 0);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void ShootDart()
    {

        float distanceFromCamera = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 mousePos = Mouse.current.position.ReadValue();

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distanceFromCamera));

        targetPos.z = 0f;

        GameObject dart = Instantiate(dartPrefab, dartOrigin.position, Quaternion.identity);

        dart.GetComponent<DartController>().Initialize(targetPos);
    }
}