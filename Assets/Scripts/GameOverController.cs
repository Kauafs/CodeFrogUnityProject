using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOverController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log(" GAME OVER! O sapo foi destruído pelo ataque DDoS.");
            Destroy(other.gameObject); 
            Invoke("ReiniciarJogo", 2f); 
        }
    }

    void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
