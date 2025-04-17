using UnityEngine;
using TMPro;
using System.Collections.Generic; // Importa List para armazenar os obstáculos

public class ProgrammingQuiz : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI scoreText; // Exibe a pontuação na tela
    public TextMeshProUGUI correctAnswersText; // Exibe número de respostas certas
    public Player player;
    public GameObject obstaclePrefab; // Prefab do obstáculo

    private List<GameObject> obstacles = new List<GameObject>(); // Lista de obstáculos ativos
    private int currentQuestionIndex = 0;
    private int correctAnswers = 0; // Contador de respostas corretas

    private string[][] questions = new string[][]
    {
        new string[] { "Qual comando imprime um texto na tela em C#?", "Console.WriteLine(\"Hello World\");" },
        new string[] { "Como declarar uma variável inteira chamada score?", "int score;" },
        new string[] { "Corrija o erro: if (x = 5)", "if (x == 5)" },
        new string[] { "Complete o loop que imprime números de 1 a 5:\nfor (int i = __; i <= 5; i++)", "1" }
    };

    void Start()
    {
        GameObject existingObstacle = GameObject.FindGameObjectWithTag("Obstacle"); // Encontra o obstáculo inicial
        if (existingObstacle != null)
        {
            obstacles.Add(existingObstacle); // Adiciona à lista
        }

        UpdateUI();
        LoadNextQuestion();
    }

    public void CheckAnswer()
    {
        string userAnswer = answerInput.text.Trim();

        if (userAnswer.ToLower() == questions[currentQuestionIndex][1].ToLower())
        {
            feedbackText.text = "Resposta correta! Você pode se mover!";
            player.UnlockMovement();

            if (obstacles.Count > 0) // Verifica se há obstáculos ativos
            {
                GameObject oldestObstacle = obstacles[0]; // Obtém o primeiro obstáculo criado
                Destroy(oldestObstacle); // Remove da cena
                obstacles.RemoveAt(0); // Remove da lista
            }

            player.AddScore(10);
            correctAnswers++;
            UpdateUI();

            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Length)
            {
                LoadNextQuestion();
            }
            else
            {
                feedbackText.text = "Você completou todas as perguntas!";
            }
        }
        else
        {
            feedbackText.text = "Resposta incorreta! Obstáculo adicional criado!";
            player.LosePoints(10);
            CreateExtraObstacle();
            UpdateUI();
        }

        answerInput.text = "";
    }

    void LoadNextQuestion()
    {
        questionText.text = questions[currentQuestionIndex][0];
        feedbackText.text = "";
    }

    void CreateExtraObstacle()
    {
        Vector3 obstaclePosition = new Vector3(player.transform.position.x + 2, 1, player.transform.position.z);
        GameObject newObstacle = Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);
        obstacles.Add(newObstacle); // Adiciona à lista de obstáculos ativos
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + player.score;
        correctAnswersText.text = "Respostas certas: " + correctAnswers;
    }
}
