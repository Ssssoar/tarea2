using UnityEngine;

public class Movement : MonoBehaviour{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;

    float currentVelocity;
    Enums.Facing lastFacing;
    bool blocked;

    // Update is called once per frame
    void Update(){
        float movement = DecideHorizontalMovement();
        if(!blocked){
            float displacement = movement * moveSpeed * Time.deltaTime;
            rb.linearVelocity = new Vector2(displacement, rb.linearVelocity.y);
            currentVelocity = Mathf.Abs(displacement);
        }
        UpdateFacing(movement);
    }

    public virtual float DecideHorizontalMovement(){
        return 0f;
    }

    void UpdateFacing(float movement){
        if (movement != 0f){
            if (movement < 0f){
                lastFacing = Enums.Facing.Left;
            }else{
                lastFacing = Enums.Facing.Right;
            }
        }
    }

    public float GetCurrentVelocity(){
        return currentVelocity;
    }

    public bool IsMoving(){
        if (currentVelocity > 0f) return true;
        return false;
    }

    public Enums.Facing GetLastFacing(){
        return lastFacing;
    }

    public void Block(){
        rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
        blocked = true;
    }
    
    public void UnBlock(){
        blocked = false;
    }

    public bool IsBlocked(){
        return blocked;
    }
}