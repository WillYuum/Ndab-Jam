using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;

public class HUD : MonoBehaviourSingleton<HUD>
{
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject introScreen;

    public void ToggleGameScreen(bool isActive)
    {
        ToggleScreen(gameScreen, isActive);
    }
    public void ToggleWinScreen(bool isActive)
    {
        ToggleScreen(winScreen, isActive);
    }

    public void ToggleLoseScreen(bool isActive)
    {
        ToggleScreen(loseScreen, isActive);
    }

    public void ToggleIntroScreen(bool isActive)
    {
        ToggleScreen(introScreen, isActive);
    }



    private void ToggleScreen(GameObject screen, bool isActive)
    {
        screen.SetActive(isActive);
    }
}
