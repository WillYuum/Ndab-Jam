using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public Text gameTimerText;
    [HideInInspector]public float startingTimer = 5f;
    [HideInInspector] public float currentTimer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        currentTimer = 180f;
        gameTimerText.text = "00:00";
    }

    void Update()
    {
        if (gameIsOn)
        {
            currentTimer -= Time.deltaTime;
            UpdateLevelTimer(currentTimer);
        }
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
    }


    public GameObject introBackground;
    [HideInInspector]public bool gameIsOn = false;
    public void StartGame()
    {
        introBackground.SetActive(false);
        AudioManager.instance.Play("Bgm");
        gameIsOn = true;
    }

    public void WinGame()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
