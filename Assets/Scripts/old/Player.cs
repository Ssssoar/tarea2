using UnityEngine;

public class Player : MonoBehaviour{
    //SINGLETON
    static public Player Instance;
    void Awake(){
        if (Instance != null){
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    //SINGLETON END
}
