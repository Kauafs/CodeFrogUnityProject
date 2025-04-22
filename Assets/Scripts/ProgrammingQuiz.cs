using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ProgrammingQuiz : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    public TextMeshProUGUI feedbackText;
    public Player player;
    public GameObject obstaclePrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI correctAnswersText;

    private List<GameObject> obstacles = new List<GameObject>();
    private int currentQuestionIndex = 0;
    private int score = 0;
    private int correctAnswers = 0;

    private string[][] questions = new string[][]
    {
        new string[] { "Como declarar uma variável inteira chamada score?", "int score;" },
        new string[] { "Qual comando imprime um texto na tela em C#?", "Console.WriteLine(\"Hello World\");" },
        new string[] { "Como declarar uma variável inteira chamada score?", "int score;" },
        new string[] { "Corrija o erro: if (x = 5)", "if (x == 5)" }
    };

    void Start()
    {
        foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
            obstacles.Add(obstacle);

        LoadNextQuestion();
        UpdateUI();
    }

    public void CheckAnswer()
    {
        if (answerInput.text.Trim().ToLower() == questions[currentQuestionIndex][1].ToLower())
        {
            feedbackText.text = "Correto! Você pode se mover!";
            player.UnlockMovement(5f);

            score += 10;
            correctAnswers++;
            RemoveObstacle();
            NextQuestion();
        }
        else
        {
            feedbackText.text = "Errado! Obstáculo criado!";
            score = Mathf.Max(score - 10, 0); // Reduzindo pontos ao errar, sem deixar negativos
            CreateExtraObstacle();
        }

        UpdateUI();
        answerInput.text = "";
    }


    void LoadNextQuestion()
    {
        if (currentQuestionIndex < questions.Length)
            questionText.text = questions[currentQuestionIndex][0];
        else
            feedbackText.text = "Você completou todas as perguntas!";
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        LoadNextQuestion();
    }

    void CreateExtraObstacle()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab, player.transform.position + new Vector3(2, 0, 0), Quaternion.identity);
        if (newObstacle != null) obstacles.Add(newObstacle);
    }

    void RemoveObstacle()
    {
        if (obstacles.Count > 0)
        {
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        correctAnswersText.text = "Respostas Corretas: " + correctAnswers;
    }
}
