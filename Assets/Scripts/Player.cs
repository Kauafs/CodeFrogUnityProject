using UnityEngine;
using TMPro;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f; // Força do pulo
    private Rigidbody rb;
    private bool canMove = false;
    public TextMeshProUGUI timerText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timerText.text = "";
    }

    void Update()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime);

            // Código de Pulo
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f) // Só permite pular se estiver no chão
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    public void UnlockMovement(float duration)
    {
        canMove = true;
        StartCoroutine(AllowMovementForTime(duration));
    }

    private IEnumerator AllowMovementForTime(float duration)
    {
        while (duration > 0)
        {
            timerText.text = "Tempo restante: " + duration.ToString("F1") + "s";
            yield return new WaitForSeconds(1f);
            duration--;
        }

        timerText.text = "";
        canMove = false;
    }
}
