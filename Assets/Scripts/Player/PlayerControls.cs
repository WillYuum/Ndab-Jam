using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float basePlayerSpeed = 3;
    public float currentPlayerSpeed;
    Rigidbody2D rb;
    public MomentumManager momentum;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        momentum = GameManager.instance.GetComponent<MomentumManager>();
    }

    void Update()
    {
        MakePlayerLookAtPointer();
        HandlePlayerMovement();
    }


    private void HandlePlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        currentPlayerSpeed = HandlePlayerSpeedChangeOnMomentum();
        Debug.Log(currentPlayerSpeed);
        Vector2 position = rb.position;
        position = position + move * currentPlayerSpeed * Time.deltaTime;
        rb.MovePosition(position);
    }


    void MakePlayerLookAtPointer()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector2 direction = new Vector2(mousePos.x, mousePos.y) - new Vector2(playerPos.x, playerPos.y);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }

    public float HandlePlayerSpeedChangeOnMomentum()
    {
        float momentumValue = momentum.momentumBar.value * 10;
        float currentSpeed = basePlayerSpeed + momentumValue;
        return currentSpeed;
    }
}
