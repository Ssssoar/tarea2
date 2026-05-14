using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneManager : MonoBehaviour
{
    // Call this function and pass the scene name
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}