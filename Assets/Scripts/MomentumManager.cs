using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomentumManager : MonoBehaviour
{

    public Slider momentumBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float momentumTimer = 0;

    public float delay = 5.0f;
    // Update is called once per frame
    void Update()
    {
        momentumTimer += 1 * Time.deltaTime;
        if(momentumTimer >= delay)
        {
            momentumTimer = 0;
            HandleDecreasingMomentum();
        }
    }

    public void HandleDecreasingMomentum()
    {
        //check if player is holding someone
        DecreaseAmount(0.05f);
    }

    public void IncreaseMomentum(float amount)
    {
        momentumBar.value += amount;
    }

    public void DecreaseAmount(float amout)
    {

    }
}
