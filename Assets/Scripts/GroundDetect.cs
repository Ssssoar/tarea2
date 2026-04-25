using UnityEngine;
using UnityEngine.Events;

public class GroundDetect : MonoBehaviour{
    [SerializeField] UnityEvent OnFloorDetected;

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Floor"){
            OnFloorDetected?.Invoke();
        }
    }
}
