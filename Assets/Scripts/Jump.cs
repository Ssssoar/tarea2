using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour{
    [SerializeField] PlayerInput inputComp;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Movement moveComp;
    [SerializeField] float chargeSpeed; //in seconds
    [SerializeField] float minJumpForce;
    [SerializeField] float maxJumpForce;
    [SerializeField] float forwardForce;
    [SerializeField] int maxJumps;

    float jumpCharge; //0 to 1
    int jumpsStored = 1;

    void Update(){
        bool holding = inputComp.GetJump();
        if (jumpsStored > 0){
            if (holding){
                Charge();
            }else if (jumpCharge > 0f){
                ExecuteJump();
            }
        }
    }

    void Charge(){
        if ((jumpCharge == 0) && (moveComp != null)){
            moveComp.Block();
        }
        jumpCharge += chargeSpeed * Time.deltaTime;
        if (jumpCharge >= 1f){
            jumpCharge = 1f;
        }
    }

    void ExecuteJump(){
        float actualJumpForce = ((maxJumpForce - minJumpForce) * jumpCharge) + minJumpForce;
        rb.linearVelocityY = actualJumpForce;
        jumpCharge = 0f;
        if (moveComp != null){
            float direction = 0f;
            if (moveComp.GetLastFacing() == Enums.Facing.Left){
                direction = -1f;
            }else if(moveComp.GetLastFacing() == Enums.Facing.Right){
                direction = 1f;
            }
            rb.linearVelocityX = forwardForce * direction;
        }
        jumpsStored--;
    }

    public void ForceJump(){
        jumpCharge = 0.5f;
        ExecuteJump();
    }

    public void RestoreJumps(){
        jumpsStored = maxJumps;
    }
}
