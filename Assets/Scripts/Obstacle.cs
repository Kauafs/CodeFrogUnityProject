using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool isBlocked = true; // O obst�culo come�a bloqueando o caminho

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBlocked)
        {
            Debug.Log("O caminho est� bloqueado! Resolva a pergunta para avan�ar.");
        }

        // Quando o obst�culo tocar o ch�o, ele para de cair
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY; // Fixa no ch�o
        }
    }

    public void UnlockObstacle()
    {
        isBlocked = false; // Desbloqueia o obst�culo
        Destroy(gameObject); // Remove o obst�culo quando desbloqueado
    }
}
