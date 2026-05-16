using Unity.Mathematics;
using UnityEngine;

public class Player2_head : MonoBehaviour
{
    [Header("rotate")]
    public float headDistance = 0.5f;
    public float angleSpeed = 5f;

    private Transform trans;
    private float angleInput;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            angleInput = -1;
        }

        else if (Input.GetKey(KeyCode.K))
        {
            angleInput = 1;
        }
        else
        {
            angleInput = 0;
        }
    }

    void FixedUpdate()
    {
        trans.eulerAngles = new Vector3(0, 0, trans.eulerAngles.z + angleInput * angleSpeed);
        trans.localPosition = new Vector3(math.cos(transform.eulerAngles.z * math.PI / 180), math.sin(transform.eulerAngles.z * math.PI / 180), 0) * headDistance;
    }
}
