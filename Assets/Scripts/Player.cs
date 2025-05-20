using UnityEngine;
using TMPro;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
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

        // 🔹 Garantindo que o sapo começa no chão
        transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);

        // 🔹 Garantindo que a animação começa em Idle
        animator.SetBool("Mover", false);

        // 🔹 Aplicando gravidade desde o início
        velocity.y = -2f;
    }

    void Update()
    {
        if (!canMove)
        {
            // 🔹 Impede movimentação e mantém animação parada
            animator.SetBool("Mover", false);
            controller.Move(Vector3.zero);
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        moveDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y,Vector3.up) * moveDirection;
        moveDirection.y = 0;

        if (moveDirection.magnitude > 0.1f)
        {
            transform.forward = moveDirection; // 🔹 Corrigindo rotação do sapo
        }

        controller.Move(moveDirection * Time.deltaTime * moveSpeed);

        // 🔹 Atualizando animação corretamente
        animator.SetBool("Mover", moveDirection.magnitude > 0.1f);

        // Gravidade aplicada continuamente
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
            animator.SetTrigger("Jump");
        }

        isGrounded = controller.isGrounded;
    }

    void FixedUpdate()
    {
        // 🔹 Aplicando gravidade continuamente
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
        animator.SetBool("Mover", false); // 🔹 Garantindo que a animação para quando o tempo acabar
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
