using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;

    void Start()
    {
        
    }
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        if (GetComponent<Rigidbody>().velocity.magnitude <= maximumVelocity)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(horizontalInput * forceMultiplier, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PerigoTag"))
        {
            Destroy(gameObject);
        }
    }


}
*/

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f;
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
            case "move forward":
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                break;
            case "move left":
                transform.Translate(Vector3.left * moveSpeed * 10f * Time.deltaTime);
                break;
            case "move rigth":
                transform.Translate(Vector3.right * moveSpeed * 10f * Time.deltaTime);
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
                Debug.Log("Comando inválido!");
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