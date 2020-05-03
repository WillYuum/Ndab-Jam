using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timer : MonoBehaviour
{

    public Text gameTimerText;
    public float startingTimer = 1200;
    [HideInInspector] public float currentTimer;
    float totalTime = 120f; //2 minutes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        totalTime -= Time.deltaTime;
        UpdateLevelTimer(totalTime);
    }


    void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);


        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        gameTimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        Debug.Log("nfokho ya ayre");
    }
}
