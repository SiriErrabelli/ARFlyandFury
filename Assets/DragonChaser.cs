using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonChaser : MonoBehaviour
{
    public float moveSpeed = 3f; // Dragon's movement speed
    private GameObject targetBalloon;

    private void Update()
    {
        // Find a target balloon if none exists
        if (targetBalloon == null)
        {
            FindClosestBalloon();
        }
        else
        {
            MoveTowardsBalloon();
        }
    }

    private void FindClosestBalloon()
    {
        // Find all balloons with the "Balloon" tag
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject balloon in balloons)
        {
            float distance = Vector3.Distance(transform.position, balloon.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                targetBalloon = balloon;
            }
        }
    }

    private void MoveTowardsBalloon()
    {
        if (targetBalloon != null)
        {
            // Move the dragon toward the balloon
            transform.position = Vector3.MoveTowards(transform.position, targetBalloon.transform.position, moveSpeed * Time.deltaTime);

            // If close enough to the balloon, pop it
            if (Vector3.Distance(transform.position, targetBalloon.transform.position) < 0.5f)
            {
                Debug.Log("Popping Balloon!");
                targetBalloon.GetComponent<Balloon>()?.Pop();
                targetBalloon = null; // Reset target after popping
            }
        }
    }
}
