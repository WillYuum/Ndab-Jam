using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeStabilizer : MonoBehaviour
{
    [SerializeField] private GameObject[] nodeToEnable;
    [SerializeField] private GameObject[] nodeToDisable;


    private void Awake()
    {
        foreach (GameObject node in nodeToEnable)
        {
            node.SetActive(true);
        }

        foreach (GameObject node in nodeToDisable)
        {
            node.SetActive(false);
        }
    }
}
