using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public Text gameTimerText;
    public float startingTimer = 1200;
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
        //currentTimer = startingTimer;
        //StartCoundownTimer();
    }

    void Update()
    {
        //UpdateTimer();
    }


    public GameObject introBackground;
    public void StartGame()
    {
        introBackground.SetActive(false);
        AudioManager.instance.Play("Bgm");
        //StartCoundownTimer();
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
