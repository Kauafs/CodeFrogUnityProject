using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; 

public class ZeroDayBoss : MonoBehaviour
{
    public Transform jogador;
    private NavMeshAgent agente;
    private Animator animator;
    private bool perseguicaoAtivada = false;
    private bool atualizado = false;

    public AudioSource audioSource; 
    public AudioClip somCorrida;  

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (jogador != null && perseguicaoAtivada && !atualizado)
        {
            agente.SetDestination(jogador.position);
            animator.SetBool("RangeBoss", true);

            if (!audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(somCorrida);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log(" O Boss te pegou! REINICIANDO O JOGO...");
            ReiniciarJogo();
        }
    }

    public void AtivarPerseguicao()
    {
        if (!perseguicaoAtivada)
        {
            perseguicaoAtivada = true;
            Debug.Log(" O Boss começou a perseguição!");

            if (!audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(somCorrida);
            }
        }
    }

    public void AtualizarSoftware()
    {
        atualizado = true;
        agente.ResetPath();
        animator.SetBool("RangeBoss", false);
        Debug.Log(" Boss neutralizado pela atualização!");
        Destroy(gameObject);
    }

    void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
