using UnityEngine;
using UnityEngine.SceneManagement; // Needed to manage scenes

public class SceneChanger : MonoBehaviour
{
    // This method is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Log the name of the object that triggered the collider
        Debug.Log($"Object {other.name} entered the trigger.");

        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("lapras")) // Change "Player" to the tag you want to check for
        {
            Debug.Log("Player detected. Changing scene...");
            ChangeScene(); // Call the method to change the scene
        }
        else
        {
            Debug.Log($"Object {other.name} does not have the 'Player' tag.");
        }
    }

    // Method to change the scene
    void ChangeScene()
    {
        // Replace "NewScene" with the name of the scene you want to load
        string newSceneName = "lapras"; // Change this to your scene name
        Debug.Log($"Loading scene: {newSceneName}");
        SceneManager.LoadScene(newSceneName);
    }
}
