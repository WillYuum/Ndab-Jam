using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{

    //public GameObject Player;

    private MomentumManager momentumBar;
    public float amountOfMomentumOnHit = 0.1f;

    private void Start()
    {
        momentumBar = GameManager.instance.GetComponent<MomentumManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("House") && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isHoldingCiv == false)
        {
            Destroy(gameObject);
            momentumBar.IncreaseMomentum(amountOfMomentumOnHit);
        }
        else
        {
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
}
