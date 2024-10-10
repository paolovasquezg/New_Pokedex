using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript_wait : MonoBehaviour
{
    public float delay = 6.0f; // Time to wait before loading the scene

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneWithDelay(sceneName)); // Coroutine to handle wait and load
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene(sceneName);      // Load the scene after the wait
    }
}