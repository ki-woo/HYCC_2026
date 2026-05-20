using Unity.Mathematics;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float power = 15f;
    private Transform trans;
    private Rigidbody2D rigid;

    private void Start()
    {
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();

        float angle = trans.rotation.eulerAngles.z * math.PI / 180f;
        rigid.linearVelocity = new Vector2(math.cos(angle), math.sin(angle)) * power;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
