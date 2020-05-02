using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public GameObject cameraPos;

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
        cameraPos.transform.position = new Vector3(transform.position.x,transform.position.y, -10);
        if (closeToCiv && isHoldingCiv == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //grab civilian
                GrabCivilian();
            }
        }

        if (isHoldingCiv)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Throwing Civ");
                ThrowCivilian();
            }
        }
    }

    [HideInInspector] public bool isHoldingCiv = false;
    [HideInInspector] public GameObject currentholdingCiv;
    public void GrabCivilian()
    {
        if (closeToCiv = false || currentCloseCiv == null) return;
        currentCloseCiv.transform.position = holdingPosition.transform.position;
        currentCloseCiv.transform.SetParent(holdingPosition.transform);
        currentholdingCiv = currentCloseCiv;
        isHoldingCiv = true;
        closeToCiv = false;
    }

    public float throwForce = 40.0f;
    public void ThrowCivilian()
    {
        isHoldingCiv = false;
        currentholdingCiv.transform.parent = null;
        currentholdingCiv.AddComponent<Rigidbody2D>();
        currentholdingCiv.GetComponent<Rigidbody2D>().AddForce(transform.up * throwForce);
        currentholdingCiv = null;
    }


    [HideInInspector] private bool closeToCiv = false;
    [HideInInspector] public GameObject currentCloseCiv;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Civilian"))
        {
            Debug.Log("close to civ");
            closeToCiv = true;
            currentCloseCiv = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        closeToCiv = false;
    }
}
