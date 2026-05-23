using UnityEngine;

public static class mapData
{
    public static int mapID = 0;

    public static bool exploded = false;
    public static Vector3 pos = Vector3.zero;
    public static int mapLength = 0;
    public static int smoothness = 0;
    public static Vector3[] vertices;
    public static Vector2[] uv;
    public static int[] triangles;
    public static Vector2[] points;
}
