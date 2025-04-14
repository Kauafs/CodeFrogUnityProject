using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver()
    {
        gameOverPanel?.SetActive(true); // Mostra o painel de Game Over
        Time.timeScale = 0f; // Pausa o jogo
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Restaura o tempo de jogo
        StartCoroutine(RestartWithDelay()); // Inicia a Coroutine com delay
    }

    private IEnumerator RestartWithDelay()
    {
        yield return new WaitForSeconds(0.2f); // Delay curto antes de reiniciar a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena
    }
}
