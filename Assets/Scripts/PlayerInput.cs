using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour{
    [SerializeField] InputAction jumpAction;
    [SerializeField] InputAction movementAction;
    [SerializeField] InputAction shoveAction;
    bool blocked = false;

    void Start(){
        jumpAction.Enable();
        movementAction.Enable();
        shoveAction.Enable();
        Pause.Instance.OnPause.AddListener(Block);
        Pause.Instance.OnUnpause.AddListener(UnBlock);
    }

    public float GetMovement(){
        if (blocked) return 0f;
        return movementAction.ReadValue<float>();
    }

    public bool GetJump(){
        if (blocked) return false;
        if (jumpAction.ReadValue<float>() == 0)
            return false;
        else
            return true;
    }

    public bool GetShove(){
        if (blocked) return false;
        if (shoveAction.ReadValue<float>() == 0)
            return false;
        else
            return true;
    }

    void Block(){
        blocked = true;
    }

    void UnBlock(){
        blocked = false;
    }
}
