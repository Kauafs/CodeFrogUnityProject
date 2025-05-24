using UnityEngine;
using UnityEngine.AI;

public class ZeroDayBoss : MonoBehaviour
{
    public Transform jogador;
    public float distanciaAtaque = 3.0f;
    private NavMeshAgent agente;
    private Animator animator;
    private bool perseguicaoAtivada = false; // Chefe só persegue após a "porta open"
    private bool atualizado = false; // Chefe desaparece ao coletar atualização

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jogador != null && perseguicaoAtivada && !atualizado) // Só persegue após ativação e se não estiver atualizado
        {
            float distancia = Vector3.Distance(transform.position, jogador.position);
            Debug.Log($" Distância do jogador: {distancia}");

            if (distancia > distanciaAtaque)
            {
                agente.SetDestination(jogador.position);
                animator.SetBool("RangeBoss", true);
                Debug.Log("Chefe começou a perseguição!");
            }
            else
            {
                animator.SetBool("RangeBoss", false);
                agente.ResetPath();
                Debug.Log("Chefe está próximo e ativando animação de ataque.");
            }
        }
    }

    public void AtivarPerseguicao()
    {
        if (!perseguicaoAtivada)
        {
            perseguicaoAtivada = true;
            Debug.Log("Jogador passou pela porta! Chefe inicia perseguição.");
        }
    }

    public void AtualizarSoftware()
    {
        atualizado = true;
        animator.SetBool("RangeBoss", false);
        agente.ResetPath();
        Debug.Log(" Chefe neutralizado pela atualização!");

        Destroy(gameObject); // Remove o chefe da cena
    }
}
