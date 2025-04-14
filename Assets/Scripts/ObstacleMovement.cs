using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidade do movimento
    public float range = 3f; // Dist�ncia m�xima de movimento
    private Vector3 startPosition;
    public bool isPaused = false; // Indica se o movimento est� pausado

    void Start()
    {
        startPosition = transform.position; // Posi��o inicial do obst�culo
    }

    void Update()
    {
        // Movimento oscilat�rio (vai e volta)
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time * speed) * range, 0, 0);
    }
}
