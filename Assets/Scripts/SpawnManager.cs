using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform[] spawnPnts;
    public GameObject[] citizens; 
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public float spawnDelay = 4f;
    public IEnumerator SpawnEnemies()
    {
        Debug.Log("start spawning");
        while(GameManager.instance.gameIsOn)
        {
            Debug.Log("spawned civ");
            yield return new WaitForSeconds(spawnDelay);
            int index = Random.Range(0, spawnPnts.Length);
            Transform selectedPoint = spawnPnts[index];
            GameObject newCitizen = Instantiate(citizens[Random.Range(0, citizens.Length)]);
            newCitizen.transform.position = selectedPoint.position;
        }
    }
}
