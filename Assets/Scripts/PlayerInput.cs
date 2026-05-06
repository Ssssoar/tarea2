using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour{
    [SerializeField] InputAction jumpAction;
    [SerializeField] InputAction movementAction;
    [SerializeField] InputAction shoveAction;

    void Start(){
        jumpAction.Enable();
        movementAction.Enable();
        shoveAction.Enable();
    }

    public float GetMovement(){
        return movementAction.ReadValue<float>();
    }

    public bool GetJump(){
        if (jumpAction.ReadValue<float>() == 0)
            return false;
        else
            return true;
    }

    public bool GetShove(){
        if (shoveAction.ReadValue<float>() == 0)
            return false;
        else
            return true;
    }
}
