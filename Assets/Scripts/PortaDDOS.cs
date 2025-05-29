using UnityEngine;

public class DDoSAtivadoPorItem : MonoBehaviour
{
    public GameObject objetoQueda; 
    public float alturaSpawn = 5.0f; 
    public float velocidadeQueda = 3f; 
    private Transform jogador; 

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void AtivarDDoS() 
    {
        Debug.Log(" O sapo pegou um item! Iniciando ataque DDoS!");

        Vector3 spawnPos = new Vector3(
            jogador.position.x, 
            alturaSpawn,
            jogador.position.z
        );

        GameObject objeto = Instantiate(objetoQueda, spawnPos, Quaternion.identity);
        Rigidbody rb = objeto.GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = objeto.AddComponent<Rigidbody>();
        }

        rb.useGravity = true;
        rb.velocity = new Vector3(0, -velocidadeQueda, 0); 
        rb.drag = 1f; 
    }
}
