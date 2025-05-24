using UnityEngine;

public class AtualizacaoSoftware : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se foi o jogador que pegou o item
        {
            ZeroDayBoss boss = FindObjectOfType<ZeroDayBoss>();
            if (boss != null)
            {
                boss.AtualizarSoftware(); // Faz o chefe parar ao pegar a atualização
            }

            Debug.Log(" Atualização de software coletada!");
            Destroy(gameObject); // Remove o item da cena
        }
    }
}
