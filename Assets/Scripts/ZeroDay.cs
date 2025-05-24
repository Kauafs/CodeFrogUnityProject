using UnityEngine;
using UnityEngine.AI;

public class ZeroDayBoss : MonoBehaviour
{
    public Transform jogador;
    public float distanciaAtaque = 3.0f;
    private NavMeshAgent agente;
    private Animator animator;
    private bool perseguicaoAtivada = false; // Chefe s� persegue ap�s a "porta open"
    private bool atualizado = false; // Chefe desaparece ao coletar atualiza��o

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jogador != null && perseguicaoAtivada && !atualizado) // S� persegue ap�s ativa��o e se n�o estiver atualizado
        {
            float distancia = Vector3.Distance(transform.position, jogador.position);
            Debug.Log($" Dist�ncia do jogador: {distancia}");

            if (distancia > distanciaAtaque)
            {
                agente.SetDestination(jogador.position);
                animator.SetBool("RangeBoss", true);
                Debug.Log("Chefe come�ou a persegui��o!");
            }
            else
            {
                animator.SetBool("RangeBoss", false);
                agente.ResetPath();
                Debug.Log("Chefe est� pr�ximo e ativando anima��o de ataque.");
            }
        }
    }

    public void AtivarPerseguicao()
    {
        if (!perseguicaoAtivada)
        {
            perseguicaoAtivada = true;
            Debug.Log("Jogador passou pela porta! Chefe inicia persegui��o.");
        }
    }

    public void AtualizarSoftware()
    {
        atualizado = true;
        animator.SetBool("RangeBoss", false);
        agente.ResetPath();
        Debug.Log(" Chefe neutralizado pela atualiza��o!");

        Destroy(gameObject); // Remove o chefe da cena
    }
}
