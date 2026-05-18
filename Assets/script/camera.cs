using Unity.Mathematics;
using UnityEngine;

public class camera : MonoBehaviour
{
    [Header("Player Transform")]
    public Transform player1;
    public Transform player2;

    [Header("Camera Setting")]
    public float scale = 0.6f;
    public float minimumPlayerDistance = 22f;
    public float minimumPlayerHeight = -4f;
    public float defaultOrthographicSize = 7f;
    public Vector3 cameraOffset = Vector3.zero;

    private Camera cam;
    private Transform trans;

    void Start()
    {
        cam = GetComponent<Camera>();
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        float x = (player1.position.x + player2.position.x) / 2;
        float y = 0;
        
        float playerDistance = math.abs(player1.position.x - player2.position.x);
        if(playerDistance >= minimumPlayerDistance)
        {
            cam.orthographicSize = defaultOrthographicSize + (playerDistance - minimumPlayerDistance) * scale;
            y = (playerDistance - minimumPlayerDistance) * scale;
        }

        float minimumHight = Mathf.Min(player1.position.y, player2.position.y);
        if(minimumHight <= minimumPlayerHeight)
        {
            y += minimumHight - minimumPlayerHeight;
        }

        trans.position = new Vector3(x, y, -10) + cameraOffset;
    }
}
