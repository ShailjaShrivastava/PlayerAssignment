using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Implement health deduction logic here
            Debug.Log("Player collided with obstacle!");
        }
    }
}
