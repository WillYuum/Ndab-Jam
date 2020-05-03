using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomentumManager : MonoBehaviour
{

    public Slider momentumBar;
    public float momentumBaseLoss = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float delay = 5.0f;
    // Update is called once per frame
    void Update()
    {
        HandleDecreasingMomentum();
    }

    public void HandleDecreasingMomentum()
    {
        //check if player is holding someone
        DecreaseAmount(momentumBaseLoss);
    }

    public void IncreaseMomentum(float amount)
    {
        momentumBar.value += amount;
    }

    private void DecreaseAmount(float amount)
    {
        momentumBar.value -= amount * Time.deltaTime;
    }
}
