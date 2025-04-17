using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool isBlocked = true; // O obstáculo começa bloqueando o caminho

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBlocked)
        {
            Debug.Log("O caminho está bloqueado! Resolva a pergunta para avançar.");
        }

        // Quando o obstáculo tocar o chão, ele para de cair
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Obstáculo tocou o chão!");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY; // Fixa no chão
        }
    }

    public void UnlockObstacle()
    {
        isBlocked = false; // Desbloqueia o obstáculo
        Destroy(gameObject); // Remove o obstáculo quando desbloqueado
    }
}
