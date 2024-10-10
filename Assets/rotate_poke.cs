using UnityEngine;

public class SlowRotate2 : MonoBehaviour
{
    // Set a base rotation speed
    public float baseRotationSpeed = 200f; // Base rotation speed in degrees
    public float speedMultiplier = 2f; // Factor to increase the speed

    // Update is called once per frame
    void Update()
    {
        // Calculate the effective rotation speed
        float effectiveRotationSpeed = baseRotationSpeed * speedMultiplier;

        // Rotate the object based on the effective rotation speed and Time.deltaTime
        transform.Rotate(0, effectiveRotationSpeed * Time.deltaTime, 0);
    }
}
