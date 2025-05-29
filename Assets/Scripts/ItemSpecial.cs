using UnityEngine;

public class SpecialItem : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log(" Item especial coletado! Limpando v�rus...");
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

        Debug.Log(" Todos os v�rus foram removidos!");
    }
}
