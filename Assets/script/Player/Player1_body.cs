using UnityEngine;

public class Player1_body : MonoBehaviour
{
    [Header("move")]
    public float moveSpeed = 5f;

    private Rigidbody2D rigid;
    private float moveInput;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
        }
        else
        {
            moveInput = 0;
        }
    }

    void FixedUpdate()
    {
        rigid.linearVelocity = new Vector2(moveInput * moveSpeed, rigid.linearVelocity.y);
    }
}