using UnityEngine;
using UnityEngine.InputSystem;

public class InputShooter : Shooter
{
    public InputAction shootAction;
    
    void Start()
    {
        shootAction.Enable();
    }

    protected override bool ShootAction() => shootAction.IsPressed();
}
