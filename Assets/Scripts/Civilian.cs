using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{

    //public GameObject Player;

    float delay;
    float startingDelayTime = 3;

    private MomentumManager momentumBar;
    public float amountOfMomentumOnHit = 0.1f;
    public GameObject[] pointsToMove;

    [HideInInspector]
    public Rigidbody2D civRB;
    private void Start()
    {
        civRB = GetComponent<Rigidbody2D>();
        delay = startingDelayTime;
        momentumBar = GameManager.instance.GetComponent<MomentumManager>();
        pointsToMove = GameObject.FindGameObjectsWithTag("pointToMove");
    }

    public bool isHeldByPlayer = false;

    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            delay = startingDelayTime;
            MoveToAnotherPos();
        }

        if (canMove && isHeldByPlayer == false)
        {
            transform.position = Vector2.Lerp(transform.position, selectedPointToGoTo.position, 1 * Time.deltaTime);
            if (transform.position == selectedPointToGoTo.position)
            {
                canMove = false;
            }
        }
    }

    //string[] sfx = {"WomanScree"}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("House") && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isHoldingCiv == false)
        {
            Destroy(gameObject);
            momentumBar.IncreaseMomentum(amountOfMomentumOnHit);
            GameManager.instance.AddToiletPaper(5);
            AudioManager.instance.Play("Boom");
        }
        else
        {
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
    public bool canMove = false;
    Transform selectedPointToGoTo;
    //expected to be 2
    int amoutToSearchForNextPos = 0;
    public void MoveToAnotherPos()
    {
        List<GameObject> pointToGoTo = new List<GameObject>();
        for (int i = 0; i < pointsToMove.Length; i++)
        {
            GameObject selectedPoint = pointsToMove[i];
            float distance = Vector2.Distance(transform.position, selectedPoint.transform.position);
            Debug.Log(distance);
            if (distance < 2)
            {
                Debug.Log("adding a poin!!!!");
                amoutToSearchForNextPos += 1;
                pointToGoTo.Add(selectedPoint);
                if (amoutToSearchForNextPos >= 2)
                {
                    Debug.Log("moving!!!!!!");
                    amoutToSearchForNextPos = 0;
                    int randNum = Random.Range(0, pointToGoTo.Count);
                    selectedPointToGoTo = pointToGoTo[randNum].transform;
                    canMove = true;
                    break;
                }
            }
        }
    }
}
