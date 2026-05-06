using UnityEngine;

public class Movement : MonoBehaviour{
    [SerializeField] PlayerInput inputComp;
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool debug;

    float currentVelocity;
    Enums.Facing lastFacing;
    bool blocked;

    // Update is called once per frame
    void Update(){
        float movement = inputComp.GetMovement();
        if(!blocked){
            float displacement = movement * moveSpeed * Time.deltaTime;
            rb.linearVelocity = new Vector2(displacement, rb.linearVelocity.y);
            currentVelocity = Mathf.Abs(displacement);
        }
        UpdateFacing(movement);
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

    public void SetFacing(Enums.Facing facing){
        lastFacing = facing;
    }

    public void Block(){
        rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
        blocked = true;
        if (debug)
            Debug.Log("Blocked");
    }
    
    public void UnBlock(){
        blocked = false;
        if (debug)
            Debug.Log("Unblocked");
    }

    public bool IsBlocked(){
        return blocked;
    }
}