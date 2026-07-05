using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rb;
    public InputAction rotationAction;
    public InputAction movementAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotationAction.Enable();
        movementAction.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float rotation = rotationAction.ReadValue<float>();
        rb.angularVelocity = rotation * rotationSpeed * Vector3.up;

        Vector2 move = movementAction.ReadValue<Vector2>();
        rb.linearVelocity = (transform.right * move.x + transform.forward * move.y) * movementSpeed * Time.deltaTime;
    }
}
