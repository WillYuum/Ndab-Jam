using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float startingHealth = 100f;
    [HideInInspector]public float currentHealth;

    public GameObject holdingPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (closeToCiv)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //grab civilian
                GrabCivilian();
            }
        }
    }

    public void GrabCivilian()
    {
        currentCloseCiv.transform.position = holdingPosition.transform.position;
        currentCloseCiv.transform.parent = holdingPosition.transform;
    }


    [HideInInspector] public bool closeToCiv = false;
    [HideInInspector] public GameObject currentCloseCiv;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Civilian"))
        {
            closeToCiv = true;
            currentCloseCiv = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
