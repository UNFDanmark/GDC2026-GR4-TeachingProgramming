using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotationAction.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public InputAction rotationAction;
    private void Update()
    {
        float rotation = rotationAction.ReadValue<float>();
        rb.angularVelocity = rotation * rotationSpeed * Vector3.up;
    }
}
