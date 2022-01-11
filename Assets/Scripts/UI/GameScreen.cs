using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private Transform TP_CounterUI;

    [SerializeField] private Text TP_Counter_Text;

    void Start()
    {
        GameManager.instance.OnCollectTP += UpdateTP;
    }



    private void UpdateTP(int tp)
    {
        TP_Counter_Text.text = tp.ToString();

        TP_CounterUI.DOComplete();
        TP_CounterUI.DOShakeScale(0.5f, 1.5f);
    }
}
