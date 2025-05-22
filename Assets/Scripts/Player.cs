using UnityEngine;
using TMPro;
using System.Collections;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private Animator animator;
    private bool canMove = false;
    public TextMeshProUGUI timerText;

    [SerializeField]
    private Transform cameraTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        timerText.text = "";
        transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        animator.SetBool("Mover", false);
        velocity.y = -2f; // 🔹 Gravidade inicial
    }

    void Update()
    {
        if (!canMove)
        {
            animator.SetBool("Mover", false);
            controller.Move(Vector3.zero);
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        moveDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
        moveDirection.y = 0;

        float speed = Input.GetKey(KeyCode.LeftShift) ? 6f : 3f; // 🔹 Alterna corrida e caminhada direto

        if (moveDirection.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 10f);
        }

        controller.Move(moveDirection * Time.deltaTime * speed);

        animator.SetBool("Mover", moveDirection.magnitude > 0.1f);

        // 🔹 Aplicando gravidade corretamente
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) // 🔹 Agora verifica diretamente no "CharacterController"
        {
            velocity.y = Mathf.Sqrt(2 * -Physics.gravity.y * 1.5f); // 🔹 Pulo baseado na gravidade
            animator.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
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
        animator.SetBool("Mover", false);
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = focus ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
