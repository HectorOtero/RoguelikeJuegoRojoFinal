using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;
    public Joystick Joystickmovement;
    float movex, movey;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 lastVector;

    
    public PlayerScriptable playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastVector = new Vector2(1,0f);
    }
    private void Update()
    {
        InputManager();
        move();
    }

    void InputManager()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        movex = Joystickmovement.Direction.x;
        movey = Joystickmovement.Direction.y;

        moveDir = new Vector2(movex, movey).normalized;

        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastVector = new Vector2(lastHorizontalVector, 0f);
        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastVector = new Vector2(0f, lastVerticalVector);
        }

        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    void move()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        if (Joystickmovement.Direction.x > 0 || Joystickmovement.Direction.x < 0)
        {
            rb.linearVelocity = new Vector2(moveDir.x * playerData.MoveSpeed, moveDir.y * playerData.MoveSpeed);
        }
        else if (Joystickmovement.Direction.y > 0 || Joystickmovement.Direction.y < 0)
        {
            rb.linearVelocity = new Vector2(moveDir.x * playerData.MoveSpeed, moveDir.y * playerData.MoveSpeed);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
