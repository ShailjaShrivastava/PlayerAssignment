using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float interactionRange = 2f;

    private Rigidbody rb;
    private Camera mainCamera;
      public ScoreManager scoreManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        MovePlayer();
        InteractWithObjects();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    private void InteractWithObjects()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                if (hit.collider.CompareTag("Collectible"))
                {
                    // Implement score increase logic here
                    Debug.Log("Collected object!");
                    scoreManager.IncreaseScore(10); // Increase score by 10
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Implement score increase logic here
            Debug.Log("Collected object!");
            scoreManager.IncreaseScore(10); 
            Destroy(other.gameObject);
        }
    }
}
