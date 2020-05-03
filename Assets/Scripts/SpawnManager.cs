using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    public Transform[] spawnPnts;
    public GameObject[] citizens;

    [HideInInspector] public int peopleOutSide;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public Text peopleOuttext;
    public void IncreasePoeple()
    {
        peopleOutSide += 1;
        peopleOuttext.text = peopleOutSide.ToString("00");

        if(peopleOutSide >= 25)
        {
            GameManager.instance.LoseGame();
        }
    }

    public void DecreasePoeple()
    {
        peopleOutSide -= 1;
        peopleOuttext.text = peopleOutSide.ToString("00");
    }

    public float spawnDelay = 2.5f;
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
            IncreasePoeple();
        }
    }
}
