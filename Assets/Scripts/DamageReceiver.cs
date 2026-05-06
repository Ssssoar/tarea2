using UnityEngine;

public class DamageReceiver : MonoBehaviour{
    [SerializeField] Movement moveComp;
    [SerializeField] Jump jumpComp;

    [SerializeField] string tagToCheck;

    void Start(){
        Debug.Log(tagToCheck);
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.tag == tagToCheck){
            if (coll.gameObject.name == "ShoveLeft"){
                moveComp.SetFacing(Enums.Facing.Left);
            }else{
                moveComp.SetFacing(Enums.Facing.Right);
            }
            moveComp.Block();
            jumpComp.ForceJump();
        }
    }
}
