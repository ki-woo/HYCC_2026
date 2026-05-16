using Unity.Mathematics;
using UnityEngine;

public class camera : MonoBehaviour
{
    [Header("Player Transform")]
    public Transform player1;
    public Transform player2;

    [Header("Camera Setting")]
    public float scale;
    public float minimumPlayerRange;
    public float defaultOrthographicSize = 5f;

    private Camera cam;
    private Transform trans;

    void Start()
    {
        cam = GetComponent<Camera>();
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        // trans.position = new Vector3((player1.position.x + player2.position.x) / 2, 0, trans.position.z);
        
        float maxRange = Mathf.Max(math.abs(player1.position.x), math.abs(player2.position.x));

        if(maxRange >= minimumPlayerRange)
        {
            cam.orthographicSize = defaultOrthographicSize + (maxRange - minimumPlayerRange) * scale;
            trans.position = new Vector3(0, (maxRange - minimumPlayerRange) * scale, -10);
        }
    }
}
