using UnityEngine;

public class PortaOpen : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            ZeroDayBoss boss = FindObjectOfType<ZeroDayBoss>();
            if (boss != null)
            {
                boss.AtivarPerseguicao(); 
            }

            Debug.Log("Porta atravessada! Perseguição ativada.");
            Destroy(gameObject); 
        }
    }
}
