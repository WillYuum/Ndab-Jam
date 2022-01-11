using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleUpAndDown : MonoBehaviour
{
    [Header("Scale properties")]
    [Range(0, 1)] [SerializeField] private float maxScale = 1;
    [Range(0, 1)] [SerializeField] private float minScale = 0;
    [SerializeField] private float scaleDuration = 1;



    [Header("Settings")]
    [SerializeField] private bool scaleOnStart = false;
    [SerializeField] private bool loop = false;
    [SerializeField] private Ease easeType;


    private Vector3 defaultScale;

    void Start()
    {
        defaultScale = transform.localScale;
        if (scaleOnStart)
        {
            StartScale();
        }
    }


    public void StartScale()
    {
        ScaleUp();
    }

    private void ScaleUp()
    {
        if (loop == false) return;

        transform
        .DOScale(defaultScale + (defaultScale * maxScale), scaleDuration)
        .SetEase(easeType)
        .OnComplete(ScaleDown);
    }

    private void ScaleDown()
    {
        if (loop == false) return;

        transform
        .DOScale(defaultScale + (defaultScale * minScale), scaleDuration)
        .SetEase(easeType)
        .OnComplete(ScaleUp);
    }

}
