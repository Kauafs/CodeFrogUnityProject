using UnityEngine;

public class AbrirPorta : MonoBehaviour
{
    public GameObject porta; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log(" O jogador tocou na porta! Abrindo...");
            porta.SetActive(false); 
        }
    }
}
