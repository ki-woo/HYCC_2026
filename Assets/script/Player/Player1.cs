using UnityEngine;

public class Player1 : MonoBehaviour
{
    [Header("move")]
    public float moveSpeed = 5f;

    [Header("rotate")]
    public float angle = 0f;
    public float angleSpeed = 90f;

    [Header("Missile")]
    public GameObject missile;

    private Transform trans;
    private Rigidbody2D rigid;
    private float moveInput;


    void Start()
    {
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(mapData.turn == 0)
        {
            // move input
            moveInput = 0;

            if (Input.GetKey(KeyCode.A))
                moveInput += -1;

            if (Input.GetKey(KeyCode.D))
                moveInput += 1;

            // angle
            if (Input.GetKey(KeyCode.W))
                angle += Time.deltaTime * angleSpeed;;

            if (Input.GetKey(KeyCode.S))
                angle -= Time.deltaTime * angleSpeed;;

            // shoot
            if (Input.GetKeyDown(KeyCode.E) && mapData.missileTurn == 0)
            {
                Instantiate(missile, trans.position, Quaternion.Euler(0, 0, angle));
                mapData.missileTurn = 1;
            }
        }
    }

    void FixedUpdate()
    {
        rigid.linearVelocity = new Vector2(moveInput * moveSpeed, rigid.linearVelocity.y);
    }
}