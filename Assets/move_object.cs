using UnityEngine;
using UnityEngine.SceneManagement; // Needed to manage scenes
using UnityEngine.UI; // Make sure to include the UI namespace

public class ArcMovement : MonoBehaviour
{
    public float height = 5f;  // Peak height of the arc
    public float speed = 5f;   // Speed of movement along the x and z axes
    public float duration = 2f; // Total time to complete the arc

    private Vector3 startPos;
    private Vector3 targetPos;
    private float timeElapsed = 0f;

    private bool isClicked = false;  // Flag to track button click

    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f); // Example target
    }

    void Update()
    {
        // Check if the button was clicked to start the movement
        if (isClicked)
        {
            MoveInArc();
        }
    }

    public void OnButtonClick()
    {
        // Set the flag to true when the button is clicked
        isClicked = true;
    }

    void MoveInArc()
    {
        // Calculate progress based on time and duration
        timeElapsed += Time.deltaTime;
        float progress = timeElapsed / duration;

        // Linear interpolation for horizontal movement
        Vector3 currentPos = Vector3.Lerp(startPos, targetPos, progress);

        // Calculate arc height (parabola)
        float arcHeight = Mathf.Sin(Mathf.PI * progress) * height;
        currentPos.y += arcHeight;

        // Update GameObject's position
        transform.position = currentPos;

        // Stop movement when target is reached
        if (progress >= 1f)
        {
            // Reset the flag to stop the movement and reset time
            isClicked = false;
            timeElapsed = 0f;

            // Log for debugging
            Debug.Log("Movement completed. Changing scene...");

            // Change to the specified scene (replace "NewScene" with your actual scene name)
            SceneManager.LoadScene("Pokedex");
        }
    }
}
