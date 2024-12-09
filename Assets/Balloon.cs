using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject popEffectPrefab; // Assign the PopEffect prefab in the Inspector
    public AudioClip popSound;         // Optional: Assign a popping sound effect

    public void Pop()
    {
        // Spawn the pop effect at the balloon's position
        if (popEffectPrefab != null)
        {
            Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
        }

        // Play the pop sound if assigned
        if (popSound != null)
        {
            AudioSource.PlayClipAtPoint(popSound, transform.position);
        }

        Debug.Log("Balloon Popped!");
        Destroy(gameObject); // Remove the balloon from the scene
    }
}
