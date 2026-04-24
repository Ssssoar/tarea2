using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement{
    [SerializeField] InputAction movementAction;

    void Start(){
        movementAction.Enable();
    }

    public override float DecideHorizontalMovement(){
        return movementAction.ReadValue<float>();
    }
}
