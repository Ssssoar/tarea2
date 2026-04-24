using UnityEngine;

public class EnemyMovement : Movement{
    public override float DecideHorizontalMovement(){
        if(Player.Instance == null){
            return 0f;
        }
        return (float)(Player.Instance.transform.position.x - transform.position.x);
    }
}
