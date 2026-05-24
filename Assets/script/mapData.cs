using UnityEngine;

public static class mapData
{
    // planet
    public static int mapID = 0;

    // explosion
    public static bool exploded = false;
    public static Vector3 pos = Vector3.zero;
    public static int mapLength = 0;
    public static int smoothness = 0;
    public static Vector3[] vertices;
    public static Vector2[] uv;
    public static int[] triangles;
    public static Vector2[] points;

    // score
    public static int leftScore = 0;
    public static int rightScore = 0;
    public static int round = 0;

    // turn
    public static int turn = 0;
    public static int missileTurn = 0;
}
