using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeInterpreter : MonoBehaviour
{
    public TMP_InputField inputField;
    public Player player;

    public void ProcessCommand()
    {
     
        string command = inputField.text.ToLower();
        if (!string.IsNullOrEmpty(command))
        {
            player.ExecuteCommand(command);
            inputField.text = ""; // Limpa o campo de entrada
        }
    }
}
