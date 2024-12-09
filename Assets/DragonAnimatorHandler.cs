using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimatorHandler : MonoBehaviour
{
    private Animator animator;
    public float radius = 2f; // Radius of the circle
    public float speed = 50f; // Speed of the circular motion
    private Vector3 centerPosition;
    private bool isCircularMotionStarted = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        centerPosition = transform.position; // Set the center of the circle
        StartCoroutine(WaitForTakeOffAnimation());
    }

    private IEnumerator WaitForTakeOffAnimation()
    {
        // Wait until the "Take Off" animation starts
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Take Off"))
        {
            yield return null; // Wait for the animation to start
        }

        // Wait until the "Take Off" animation finishes
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null; // Wait for the animation to complete
        }

        // Start circular motion
        isCircularMotionStarted = true;
    }

    private void Update()
    {
        // Handle circular motion once triggered
        if (isCircularMotionStarted)
        {
            float angle = Time.time * speed; // Time-based angle for smooth rotation
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            transform.position = centerPosition + new Vector3(x, 0, z);
        }
    }
}

