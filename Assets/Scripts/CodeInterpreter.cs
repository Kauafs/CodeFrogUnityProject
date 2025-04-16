using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Adiciona suporte para UI

public class CodeInterpreter : MonoBehaviour
{
    public TMP_InputField inputField; // Campo onde o jogador digita
    public TextMeshProUGUI feedbackText; // Texto para exibir mensagens
    public Button submitButton; // Botão para enviar comandos
    public Player player; // Referência ao personagem do jogo

    void Start()
    {
        // Adiciona a função ao botão de envio
        submitButton.onClick.AddListener(ProcessCommand);
    }

    public void ProcessCommand()
    {
        string command = inputField.text.Trim().ToLower();

        if (!string.IsNullOrEmpty(command))
        {
            if (IsValidCommand(command))
            {
                player.ExecuteCommand(command); // Envia o comando para o Player
                feedbackText.text = "Executando: " + command;
            }
            else
            {
                feedbackText.text = "Comando inválido! Tente novamente.";
            }

            inputField.text = ""; // Limpa o campo de entrada após o envio
        }
    }

    private bool IsValidCommand(string command)
    {
        // Lista de comandos válidos para o jogo
        string[] validCommands = { "move left", "move right", "jump", "attack" };
        return System.Array.Exists(validCommands, element => element == command);
    }
}
