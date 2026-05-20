using Unity.Mathematics;
using UnityEngine;

public class Player2_head : MonoBehaviour
{
    public float headDistance = 0.5f;

    private Transform trans;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float angle = transform.parent.GetComponent<Player2>().angle;
        trans.eulerAngles = new Vector3(0, 0, angle);
        trans.localPosition = new Vector3(math.cos(angle * math.PI / 180f), math.sin(angle * math.PI / 180f), 0) * headDistance;
    }
}
