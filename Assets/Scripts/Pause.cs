using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Pause : MonoBehaviour{
    [SerializeField] InputAction pauseAction;
    [SerializeField] GameObject pauseMenu;
    public UnityEvent OnPause;
    public UnityEvent OnUnpause;

    bool isPaused = false;

    public static Pause Instance;

    void Start(){
        if (Instance == null){
            Instance = this;
            pauseAction.Enable();
        }else{
            Destroy(gameObject);
        }
    }

    void Update(){
        if (pauseAction.WasPerformedThisFrame()){
            TogglePause();
        }
    }

    public void TogglePause(){
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = (isPaused)? 0f : 1f;
        if(isPaused){
            OnPause?.Invoke();
        }else{
            OnUnpause?.Invoke();
        }
    }
}
