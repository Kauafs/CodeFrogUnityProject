using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ExecuteCommand(string command)
    {
        switch (command.ToLower())
        {
            case "move left":
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                break;
            case "move right":
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                break;
            case "jump":
                if (isGrounded)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
                break;
            case "attack":
                Debug.Log("Sapo atacou!");
                break;
            default:
                Debug.Log("Comando inv�lido!");
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
