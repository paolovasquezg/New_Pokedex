using UnityEngine;

public class ToggleObjectAndAudio : MonoBehaviour
{
    public GameObject targetObject;  // The object you want to toggle
    public AudioSource audioSource;  // The audio source you want to control

    void Start()
    {
        // Make sure the target object is inactive at the beginning
        targetObject.SetActive(false);

        // Start playing the audio at the beginning
        audioSource.Play();
    }

    // This method is called when the button is pressed
    public void ToggleActiveState()
    {
        // Toggle the active state of the target object
        bool isActive = !targetObject.activeSelf;
        targetObject.SetActive(isActive);

        // Toggle the audio source: Stop if the object is inactive, resume playing if active
        if (!isActive)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();  // Resume audio if it was stopped
            }
        }
        else
        {
            audioSource.Stop();  // Stop the audio when the object is deactivated
        }
    }
}
