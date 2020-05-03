using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [HideInInspector]public SpawnManager spawnManager;

    public Text gameTimerText;
    [HideInInspector]public float startingTimer = 5f;
    [HideInInspector] public float currentTimer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        spawnManager = GameManager.instance.GetComponent<SpawnManager>();
        currentTimer = 180f;
        gameTimerText.text = "00:00";
        WinScreen.SetActive(false);
        loseScreen.SetActive(false);
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

        if(minutes <= 1)
        {
            spawnManager.spawnDelay = 2f;

            if (seconds <= 30)
            {
                spawnManager.spawnDelay = 1.75f;
            }
        }

        if(seconds <= 30)
        {
            spawnManager.spawnDelay = 1.5f;
        }

        if(minutes <= 0)
        {
            if(seconds <= 0)
            {
                WinGame();
            }
        }
    }

    public GameObject ToiletPaperImage;
    [HideInInspector] public int toiletPapersCollected = 0;
    int amountOfPeopleNdab = 0;
    public Text toiletPaperAmountText;
    public void AddToiletPaper(int amount)
    {
        ToiletPaperImage.transform.DOShakeScale(20 * Time.deltaTime);
        toiletPapersCollected += amount;
        amountOfPeopleNdab += 1;
        toiletPaperAmountText.text = toiletPapersCollected.ToString("00");
    }


    public GameObject introBackground;
    [HideInInspector]public bool gameIsOn = false;
    public void StartGame()
    {
        WinScreen.SetActive(false);
        introBackground.SetActive(false);
        AudioManager.instance.Play("Bgm");
        gameIsOn = true;
        StartCoroutine(spawnManager.SpawnEnemies());
    }


    public GameObject WinScreen;
    public Text winText;
    public void WinGame()
    {
        WinScreen.SetActive(true);
        gameIsOn = false;
        winText.text = $"{amountOfPeopleNdab:00} people have been packed and ndabbed and got {toiletPapersCollected:00}";
        AudioManager.instance.Stop("Bgm");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        WinScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public GameObject loseScreen;
    public void LoseGame()
    {
        loseScreen.SetActive(true);
        gameIsOn = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
