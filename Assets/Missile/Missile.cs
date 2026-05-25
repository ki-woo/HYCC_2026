using Unity.Mathematics;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float explosionRadius = 1;
    private float power = 15f;
    private float[] density = new float[3] {0.02f, 1.2f, 0.2f};
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
        if(other.gameObject.layer == LayerMask.NameToLayer("Player2"))
            mapData.leftScore += 1;

        if(other.gameObject.layer == LayerMask.NameToLayer("Player1"))
            mapData.rightScore += 1;
        
        mapData.turn += 1;
        mapData.turn %= 2;
        mapData.round += 1;

        ReformGround();
        Destroy(gameObject);
    }

    private void Update()
    {
        if(trans.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 drag = -1f / 2f * 0.47f * math.PI * 0.25f * density[mapData.mapID] * rigid.linearVelocity.magnitude * rigid.linearVelocity;
        rigid.AddForce(drag);
    }

    private void ReformGround()
    {
        int origin = (int)(trans.position.x - mapData.pos.x + mapData.mapLength / 2) * mapData.smoothness;
        int min = (int)(trans.position.x - mapData.pos.x + mapData.mapLength / 2 - explosionRadius) * mapData.smoothness;
        int max = (int)(trans.position.x - mapData.pos.x + mapData.mapLength / 2 + explosionRadius) * mapData.smoothness;

        min = min >= 0 ? min : 0;
        max = max <= mapData.mapLength * mapData.smoothness ? max : mapData.mapLength * mapData.smoothness;

        for(int i = min; i <= max; i++)
        {
            float dx = (float)(origin - i) / mapData.smoothness;
            float dy = trans.position.y - mapData.vertices[i * 2].y - mapData.pos.y;

            if(dx * dx + dy * dy < explosionRadius * explosionRadius)
            {
                float dvY = math.sqrt(explosionRadius * explosionRadius - dx * dx) - math.abs(dy);

                mapData.vertices[i * 2] -= Vector3.up * dvY;
                mapData.uv[i * 2] -= Vector2.up * dvY;
                mapData.points[i] -= Vector2.up * dvY;
            }
        }

        mapData.exploded = true;
    }
}
