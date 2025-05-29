using UnityEngine;

public class SpecialItem : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log(" Item especial coletado! Limpando vírus...");
            RemoveAllViruses(); 
            Destroy(gameObject); 
        }
    }

    void RemoveAllViruses()
    {
        GameObject[] viruses = GameObject.FindGameObjectsWithTag("Virus"); 
        foreach (GameObject virus in viruses)
        {
            Destroy(virus); 
        }

        Debug.Log(" Todos os vírus foram removidos!");
    }
}
