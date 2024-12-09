using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float radius = 2f; // Radius of the circle
    public float speed = 50f; // Speed of rotation
    private Vector3 centerPosition;

    private void Start()
    {
        // Set the center of the circle as the dragon's current position
        centerPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new position for circular motion
        float angle = Time.time * speed; // Time-based angle for smooth motion
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Update the dragon's position to follow the circular path
        transform.position = centerPosition + new Vector3(x, 0, z);
    }
}
