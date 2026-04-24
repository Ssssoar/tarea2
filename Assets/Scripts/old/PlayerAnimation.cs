using UnityEngine;

public class PlayerAnimation : MonoBehaviour{
    [SerializeField] Animator animComp;
    [SerializeField] Movement movementComp;
    [SerializeField] SpriteRenderer spriteComp;
    [SerializeField] string upAnim;
    [SerializeField] string downAnim;
    [SerializeField] string leftAnim;
    [SerializeField] string upRunAnim;
    [SerializeField] string downRunAnim;
    [SerializeField] string leftRunAnim;

    bool running;
    Enums.Facing currentFacing;

    void Start(){
        running = false;
        currentFacing = Enums.Facing.Down;
    }
    
    void Update(){
        //update running
        if(movementComp.GetCurrentVelocity() > 0f){
            running = true;
        }else{
            running = false;
        }

        currentFacing = movementComp.GetLastFacing();

        string animClip = ChooseAnim(running, currentFacing);
        bool mirror = ChooseMirror(currentFacing);

        animComp.Play(animClip);
        spriteComp.flipX = mirror;
    }

    string ChooseAnim(bool running, Enums.Facing currentFacing){
        string ret = "";
        if (running){
            switch(currentFacing){
                case Enums.Facing.Up:
                    ret = upRunAnim;
                break;
                case Enums.Facing.Left:
                    ret = leftRunAnim;
                break;
                case Enums.Facing.Right:
                    ret = leftRunAnim;
                break;
                case Enums.Facing.Down:
                    ret = downRunAnim;
                break;
            }
        }else{
            switch(currentFacing){
                case Enums.Facing.Up:
                    ret = upAnim;
                break;
                case Enums.Facing.Left:
                    ret = leftAnim;
                break;
                case Enums.Facing.Right:
                    ret = leftAnim;
                break;
                case Enums.Facing.Down:
                    ret = downAnim;
                break;
            }
        }
        return ret;
    }

    bool ChooseMirror(Enums.Facing currentFacing){
        if (currentFacing == Enums.Facing.Right) {return true;}
        return false;
    }
}
