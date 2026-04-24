using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] InputAction jumpAction;
    [SerializeField] float chargeSpeed; //in seconds
    [SerializeField] float minJumpForce;
    [SerializeField] float maxJumpForce;

    float jumpCharge; //0 to 1

    void Start(){
        jumpAction.Enable();
    }

    void Update(){
        bool holding = InputToBool();
        if (holding){
            Charge();
        }else if (jumpCharge > 0f){
            ExecuteJump();
        }
    }

    bool InputToBool(){
        if (jumpAction.ReadValue<float>() == 0)
            return false;
        else
            return true;
    }

    void Charge(){
        jumpCharge += chargeSpeed * Time.deltaTime;
        if (jumpCharge >= 1f){
            jumpCharge = 1f;
        }
    }

    void ExecuteJump(){
        float actualJumpForce = ((maxJumpForce - minJumpForce) * jumpCharge) + minJumpForce;
        rb.linearVelocityY = actualJumpForce;
        jumpCharge = 0f;
    }
}
