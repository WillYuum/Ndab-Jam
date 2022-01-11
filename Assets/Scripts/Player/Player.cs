﻿using UnityEngine;
using Utils.GenericSingletons;

public class Player : MonoBehaviourSingleton<Player>
{


    public GameObject cameraPos;

    public PlayerControls playerControls { get; private set; }

    [HideInInspector] public float currentHealth;

    public GameObject holdingPosition;

    private MomentumManager momentumBar;
    public float amountOfMomentumOnHold = 0.05f;
    public float amountOfMomentumOnThrow = 0.09f;

    void Awake()
    {
        playerControls = gameObject.GetComponent<PlayerControls>();
    }

    // Start is called before the first frame update
    void Start()
    {
        momentumBar = GameManager.instance.GetComponent<MomentumManager>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if (closeToCiv || isHoldingCiv)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //grab civilian
                if (isHoldingCiv == false)
                {
                    GrabCivilian();

                }
                else
                {
                    Debug.Log("Throwing Civ");
                    ThrowCivilian();
                }
            }
        }
    }

    [HideInInspector] public bool isHoldingCiv = false;
    [HideInInspector] public GameObject currentholdingCiv;
    public Sprite holdingImage;
    public Sprite normalImage;
    public void GrabCivilian()
    {
        if (closeToCiv = false || currentCloseCiv == null) return;
        currentholdingCiv = currentCloseCiv;

        Civilian civComp = currentholdingCiv.GetComponent<Civilian>();

        civComp.civRB.bodyType = RigidbodyType2D.Kinematic;
        civComp.isHeldByPlayer = true;

        currentholdingCiv.transform.position = holdingPosition.transform.position;
        currentholdingCiv.transform.SetParent(holdingPosition.transform);

        momentumBar.IncreaseMomentum(amountOfMomentumOnHold);
        AudioManager.instance.Play("Whoosh");
        GetComponent<SpriteRenderer>().sprite = holdingImage;
        isHoldingCiv = true;
        closeToCiv = false;
    }

    public float throwForce = 40.0f;
    public void ThrowCivilian()
    {
        isHoldingCiv = false;
        currentholdingCiv.transform.parent = null;

        Civilian civComp = currentCloseCiv.GetComponent<Civilian>();
        civComp.civRB.bodyType = RigidbodyType2D.Dynamic;
        currentholdingCiv.GetComponent<Rigidbody2D>().AddForce(transform.up * throwForce);

        currentholdingCiv = null;
        GetComponent<SpriteRenderer>().sprite = normalImage;
        GameManager.instance.spawnManager.DecreasePoeple();
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
