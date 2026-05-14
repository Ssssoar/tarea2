using UnityEngine;

public class Win : MonoBehaviour{
    [SerializeField] GameObject p1Win;
    [SerializeField] GameObject p2Win;
    [SerializeField] string p1Tag;
    [SerializeField] string p2Tag;
    void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == p1Tag){
            p1Win.SetActive(true);
        }
        if (coll.gameObject.tag == p2Tag){
            p2Win.SetActive(true);
        }
    }
}
