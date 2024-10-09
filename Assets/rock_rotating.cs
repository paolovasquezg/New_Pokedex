using UnityEngine;

public class rock_rotating : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 0, 10); // Adjust the speed for each axis (X, Y, Z)

    // Update is called once per frame
    void Update()
    {
        // Rotate the object slowly based on the rotationSpeed and the time passed since the last frame
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
