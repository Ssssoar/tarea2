using UnityEngine;

public class Shove : MonoBehaviour{
    [SerializeField] PlayerInput inputComp;
    [SerializeField] Movement moveComp;
    [SerializeField] GameObject leftShove;
    [SerializeField] GameObject rightShove;

    [SerializeField] float shoveTime;
    
    float shoveTimer;
    bool shoving;

    void Start(){
        EndShove();
    }

    void Update(){
        bool holding = inputComp.GetShove();
        if (holding && !shoving){
            BeginShove();
        }else if(shoving){
            ShoveTimer();
        }
    }

    void ShoveTimer(){
        shoveTimer -= Time.deltaTime;
        if(shoveTimer <= 0f){
            shoving = false;
            EndShove();
        }
    }

    void BeginShove(){
        Enums.Facing facing = moveComp.GetLastFacing();
        if (facing == Enums.Facing.Left){
            leftShove.SetActive(true);
        }else{
            rightShove.SetActive(true);
        }
        shoveTimer = shoveTime;
        shoving = true;
        moveComp.Block();
    }

    void EndShove(){
        leftShove.SetActive(false);
        rightShove.SetActive(false);
        moveComp.UnBlock();
    }
}
