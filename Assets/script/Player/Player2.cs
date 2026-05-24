using UnityEngine;

public class Player2 : MonoBehaviour
{
    [Header("move")]
    public float moveSpeed = 5f;

    [Header("rotate")]
    public float angle = 180f;
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
        if(mapData.turn == 1)
        {
            // move input
            moveInput = 0;

            if (Input.GetKey(KeyCode.J))
                moveInput += -1;

            if (Input.GetKey(KeyCode.L))
                moveInput += 1;

            // angle
            if (Input.GetKey(KeyCode.I))
                angle -= Time.deltaTime * angleSpeed;;

            if (Input.GetKey(KeyCode.K))
                angle += Time.deltaTime * angleSpeed;;

            // shoot
            if (Input.GetKeyDown(KeyCode.O) && mapData.missileTurn == 1)
            {
                Instantiate(missile, trans.position, Quaternion.Euler(0, 0, angle));
                mapData.missileTurn = 0;
            }
        }
    }

    void FixedUpdate()
    {
        rigid.linearVelocity = new Vector2(moveInput * moveSpeed, rigid.linearVelocity.y);
    }
}