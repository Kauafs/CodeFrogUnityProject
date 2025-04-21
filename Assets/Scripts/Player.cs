
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

            // Debug para verificar os inputs
            Debug.Log($"Horizontal: {moveHorizontal}, Vertical: {moveVertical}");

            // Movimentação corrigida para respeitar a rotação Y=90° do sapo
            Vector3 moveDirection = transform.right * -moveVertical + transform.forward * moveHorizontal;
            rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed * Time.deltaTime);

            // Código de Pulo
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
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