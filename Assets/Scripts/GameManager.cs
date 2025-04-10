using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject perigoPrefab;
    public int maxPerigoToSpawn = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPerigo());
    }
    private IEnumerator SpawnPerigo()
    {
        var perigoTospawn = Random.Range(1, maxPerigoToSpawn);
        for (int i = 0; i < perigoTospawn; i++)
        {
            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 2f);
            var perigo = Instantiate(perigoPrefab, new Vector3(x, 11, 0), Quaternion.identity);
            perigo.GetComponent<Rigidbody>().drag = drag;
        }
        yield return new WaitForSeconds(1f);
        yield return SpawnPerigo();
    }
}
