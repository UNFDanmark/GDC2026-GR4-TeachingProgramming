using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }

    private void Update()
    {
        float rotation = rotationAction.ReadValue<float>();
        //rb.angularVelocity = rotation * rotationSpeed * Vector3.up;
        transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);
        
        Vector2 move = movementAction.ReadValue<Vector2>();
        rb.linearVelocity = (transform.right * move.x + transform.forward * move.y) * movementSpeed * Time.deltaTime + new Vector3(0, rb.linearVelocity.y, 0);
    }
}
