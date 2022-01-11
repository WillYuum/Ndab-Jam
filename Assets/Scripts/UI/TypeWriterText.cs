using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypeWriterText : MonoBehaviour
{
    [SerializeField] private bool showTextOnLoad = false;

    [SerializeField] private float delay = .1f;
    private string fullText;
    private string currentText = "";

    void Start()
    {
        if (showTextOnLoad)
        {
            StartShowText();
        }
    }

    public void StartShowText()
    {
        StartCoroutine(ShowText());
    }


    IEnumerator ShowText()
    {
        TextMeshProUGUI tmpro = GetComponent<TextMeshProUGUI>();
        fullText = tmpro.text;
        tmpro.text = "";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            tmpro.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
