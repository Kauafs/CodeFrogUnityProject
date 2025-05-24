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
                boss.AtivarPerseguicao(); // Ativa a perseguição do chefe
            }

            Debug.Log("Porta atravessada! Perseguição ativada.");
            Destroy(gameObject); // Remove a porta após ativação
        }
    }
}
