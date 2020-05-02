using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public int playeSpeed = 10;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        Vector2 position = rb.position;
        position = position + move * playeSpeed * Time.deltaTime;
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
}
