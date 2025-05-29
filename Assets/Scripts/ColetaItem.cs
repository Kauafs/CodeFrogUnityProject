using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    private DDoSAtivadoPorItem gerenciadorDDoS; 
    public AudioClip somColeta; 

    void Start()
    {
        gerenciadorDDoS = FindObjectOfType<DDoSAtivadoPorItem>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log(" O jogador coletou um item! Ativando DDoS...");

            if (somColeta != null) 
            {
                GameObject somObj = new GameObject("SomColeta");
                AudioSource somAudio = somObj.AddComponent<AudioSource>();
                somAudio.clip = somColeta;
                somAudio.Play();
                Destroy(somObj, somColeta.length); 
            }

            gerenciadorDDoS.AtivarDDoS(); 
            Destroy(gameObject); 
        }
    }
}
