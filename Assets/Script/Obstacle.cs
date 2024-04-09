using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Implement health deduction logic here
            Debug.Log("Player collided with obstacle!");
        }
    }
}
