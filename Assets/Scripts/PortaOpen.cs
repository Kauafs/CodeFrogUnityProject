using UnityEngine;

public class PortaOpen : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Se o jogador passar pela porta
        {
            ZeroDayBoss boss = FindObjectOfType<ZeroDayBoss>();
            if (boss != null)
            {
                boss.AtivarPerseguicao(); // Ativa a persegui��o do chefe
            }

            Debug.Log("Porta atravessada! Persegui��o ativada.");
            Destroy(gameObject); // Remove a porta ap�s ativa��o
        }
    }
}
