using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour
{
    public GameObject targetObject;     // The GameObject to toggle (e.g., a RawImage)
    public AudioSource audioSource;      // The AudioSource to toggle

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the target object is inactive at the start
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }

        // Ensure the audio is playing at the start
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Detect screen touch or click
        if (Input.GetMouseButtonDown(0))
        {
            // Only toggle if not touching a UI element
            if (!IsPointerOverUIObject())
            {
                ToggleActiveState();
            }
        }
    }

    // Toggle the active state of the target object and play/stop audio
    private void ToggleActiveState()
    {
        if (targetObject != null)
        {
            // Toggle the target object's active state
            targetObject.SetActive(!targetObject.activeSelf);

            // Play or stop the audio based on the target object's active state
            if (!targetObject.activeSelf)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    // Check if the pointer is over a UI object
    private bool IsPointerOverUIObject()
    {
        if (EventSystem.current == null)
        {
            Debug.LogWarning("No EventSystem in the scene.");
            return false;
        }

        PointerEventData ped = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);

        return results.Count > 0;
    }
}
