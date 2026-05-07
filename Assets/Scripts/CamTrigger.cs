using UnityEngine;

public class CamTrigger : MonoBehaviour{
    [SerializeField] string p1Tag;
    [SerializeField] string p2Tag;
    [SerializeField] float transitionTime;
    [SerializeField] Camera cam1;
    [SerializeField] Camera cam2;
    float cam1Timer;
    float cam2Timer;

    void Update(){
        if (cam1Timer >= 0f){
            cam1.transform.position = Vector3.Lerp(cam1.transform.position, transform.position, 0.2f);
            cam1Timer -= Time.deltaTime;
        }
        if (cam2Timer >= 0f){
            cam2.transform.position = Vector3.Lerp(cam2.transform.position, transform.position, 0.2f);
            cam2Timer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.tag == p1Tag){
            cam1Timer = transitionTime;
        }
        if (coll.tag == p2Tag){
            cam2Timer = transitionTime;
        }
    }
}
