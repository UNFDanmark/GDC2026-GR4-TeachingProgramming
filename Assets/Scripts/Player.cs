using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Player : Killable
{
    public float movementSpeed;
    public float movementSpeedWhileShooting;
    //[SerializeField] private float rotationSpeed;
    private Rigidbody rb;
    //public InputAction rotationAction;
    public InputAction movementAction;

    InputShooter shooterInput;

    public Animator animator;
    

    private Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        rb = GetComponent<Rigidbody>();
        shooterInput = GetComponent<InputShooter>();
        //rotationAction.Enable();
        movementAction.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //float rotation = rotationAction.ReadValue<float>();
        
        //transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);
        
        Vector2 move = movementAction.ReadValue<Vector2>();
        if(shooterInput.shootAction.IsPressed()) rb.linearVelocity = (transform.right * move.x + transform.forward * move.y) * movementSpeedWhileShooting * Time.deltaTime + new Vector3(0, rb.linearVelocity.y, 0);
        rb.linearVelocity = (transform.right * move.x + transform.forward * move.y) * movementSpeed * Time.deltaTime + new Vector3(0, rb.linearVelocity.y, 0);
        animator.SetFloat("speed", rb.linearVelocity.magnitude);
        shooter.TryShoot("Enemy", this);
    }
    
    public override void die()
    {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
    }
}
