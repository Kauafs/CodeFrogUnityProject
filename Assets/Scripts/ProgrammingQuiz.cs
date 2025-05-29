using UnityEngine;
using TMPro;
using System.Collections;

public class ProgrammingQuiz : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    public TextMeshProUGUI feedbackText;
    public Player player;
    public GameObject porta; 
    public GameObject portaLabirinto;  
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI correctAnswersText;

    private int currentQuestionIndex = 0;
    private int score = 0;
    private int correctAnswers = 0;
    private bool bloqueado = false;

    private string[][] questions = new string[][]
    {
        new string[] { "Como declarar uma variável inteira chamada score?", "int score;" },
        new string[] { "Qual comando imprime um texto na tela em C#?", "Console.WriteLine(\"Hello World\");" },
        new string[] { "Corrija o erro: if (x = 5)", "if (x == 5)" },
        new string[] { "Qual palavra-chave cria uma função em C#?", "void" } 
    };

    void Start()
    {
        LoadNextQuestion();
        UpdateUI();
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); });

        if (porta != null) porta.SetActive(true); 
        if (portaLabirinto != null) portaLabirinto.SetActive(true); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !bloqueado)
        {
            if (answerInput.isFocused)
            {
                CheckAnswer();
                answerInput.text = "";
                answerInput.ActivateInputField();
            }
            else
            {
                answerInput.ActivateInputField();
            }
        }
    }

    public void CheckAnswer()
    {
        if (answerInput.text.Trim().ToLower() == questions[currentQuestionIndex][1].ToLower())
        {
            feedbackText.text = " Correto! Você pode se mover!";
            score += 10;
            correctAnswers++;

            if (currentQuestionIndex == 0 && porta != null)
            {
                porta.SetActive(false);  
                Debug.Log(" A porta sumiu! O jogador pode avançar.");
            }

            if (currentQuestionIndex == questions.Length - 1 && portaLabirinto != null)
            {
                LiberarLabirinto();  
            }

            bloqueado = true;
            answerInput.interactable = false;
            player.UnlockMovement(60f);

            StartCoroutine(DesbloquearInputField());
        }
        else
        {
            feedbackText.text = " Errado! Tente novamente!";
            score = Mathf.Max(score - 10, 0);
        }

        UpdateUI();
        answerInput.text = "";
    }

    IEnumerator DesbloquearInputField()
    {
        yield return new WaitForSeconds(60f);
        bloqueado = false;
        answerInput.interactable = true;
        NextQuestion();
    }

    void LoadNextQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex][0];
        }
        else
        {
            LiberarLabirinto(); 
        }
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        LoadNextQuestion();
    }

    void LiberarLabirinto()
    {
        feedbackText.text = " Você completou o desafio! A saída do labirinto está aberta!";
        if (portaLabirinto != null)
        {
            portaLabirinto.SetActive(false); 
        }
        Debug.Log(" A porta do labirinto foi liberada!");
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        correctAnswersText.text = "Respostas Corretas: " + correctAnswers;
    }
}
