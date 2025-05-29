using UnityEngine;

public class AtualizacaoSoftware : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            ZeroDayBoss boss = FindObjectOfType<ZeroDayBoss>();
            if (boss != null)
            {
                boss.AtualizarSoftware(); 
            }

            Debug.Log(" Atualização de software coletada!");
            Destroy(gameObject); 
        }
    }
}
