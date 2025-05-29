using UnityEngine;
using UnityEngine.SceneManagement; 

public class VirusObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log(" Infectado! Reiniciando jogo...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }
}
