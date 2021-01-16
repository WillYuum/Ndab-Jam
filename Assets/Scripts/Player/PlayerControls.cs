using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float basePlayerSpeed = 3;
    private float currentPlayerSpeed = 2.0f;
    // Rigidbody2D rb;
    public MomentumManager momentum;


    void Start()
    {
        momentum = GameManager.instance.GetComponent<MomentumManager>();
    }

    void Update()
    {
        MakePlayerLookAtPointer();
        HandlePlayerMovement();
    }


    private void HandlePlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal") * currentPlayerSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * currentPlayerSpeed * Time.deltaTime;

        transform.position += new Vector3(horizontal, vertical, 0);
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
