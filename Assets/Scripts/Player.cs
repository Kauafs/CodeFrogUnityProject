using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool canMove = false;
    public int score = 0; // Pontuação inicial

    void Start()
    {
        Debug.Log("Score inicial: " + score);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Pontuação: " + score);
    }

    public void LosePoints(int amount)
    {
        score -= amount;
        Debug.Log("Pontuação: " + score);
    }
}
