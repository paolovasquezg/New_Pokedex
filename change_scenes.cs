using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log($"Attempting to load scene: {sceneName}");  // Log the scene that is being requested
        SceneManager.LoadScene(sceneName);
        Debug.Log($"Scene {sceneName} loaded successfully.");  // Log after the scene has loaded (note that this will run before the new scene is fully displayed)
    }
}
