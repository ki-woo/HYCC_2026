using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class mapGenerator : MonoBehaviour
{
    [Header("Map Setting")]
    public float mapDepth = 10;
    public Material material;

    [Header("Noise Setting")]
    public int mapLength = 250;
    public int octaveInterval1 = 25;
    public int octaveInterval2 = 5;
    public float octaveScale1 = 25;
    public float octaveScale2 = 5;
    public float maxGradient = 1;
    public int smoothness = 10;

    private Rigidbody2D rigid;
    private Mesh mesh;
    private PolygonCollider2D col;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        col = GetComponent<PolygonCollider2D>();
        CreateMesh(mapGen());

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material = material;
    }

    private List<float> mapGen()
    {
        // 총 길이 250 (-125 ~ 125), 각 칸 당 smoothness
        List<float> noise1 = monoNoise(octaveInterval1); // 간격 25 10번
        List<float> noise2 = monoNoise(octaveInterval2); // 간격 5 50번

        List<float> noise = new List<float>();
        for(int i = 0; i <= mapLength * smoothness; i++)
        {
            noise.Add(noise1[i] * octaveScale1 + noise2[i] * octaveScale2);
        }

        return noise;
    }

    private List<float> monoNoise(int octaveInterval)
    {
        int pointCount = mapLength / octaveInterval + 2;

        // generate point
        List<float> noisePoint = new List<float>();
        for(int i = 0; i < pointCount; i++)
        {
            noisePoint.Add(Random.Range(-maxGradient, maxGradient));
        }

        // interpolation
        List<float> monoNoise = new List<float>();
        float interval = octaveInterval * smoothness;

        for(int i = 0; i < pointCount - 1; i++)
        {
            float A = noisePoint[i] + noisePoint[i+1];
            float B = noisePoint[i] * -2 - noisePoint[i+1];
            float C = noisePoint[i];
            
            for(int j = 0; j < interval; j++)
            {
                float t = 1 / interval * j;
                monoNoise.Add(A * t * t * t + B * t * t + C * t);
            }
        }
        monoNoise.Add(0f);

        return monoNoise;
    }

    private void CreateMesh(List<float> noise)
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();
        List<Vector2> points = new List<Vector2>();

        for(int i = 0; i < noise.Count; i++)
        {
            float x = (float)i / smoothness - mapLength / 2;

            // 2i
            vertices.Add(new Vector3(x, noise[i], 0));
            vertices.Add(new Vector3(x, -mapDepth, 0));

            // 2i
            uv.Add(new Vector2(x, noise[i]));
            uv.Add(new Vector2(x, -mapDepth));

            // i
            points.Add(new Vector2(x, noise[i]));
        }

        points.Add(new Vector2(mapLength / 2, -mapDepth));
        points.Add(new Vector2(-mapLength / 2, -mapDepth));

        for(int i = 0; i < noise.Count - 1; i++)
        {
            triangles.AddRange(new int[] {i * 2, i * 2 + 2, i * 2 + 1, i * 2 + 2, i * 2 + 3, i * 2 + 1});
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();
        col.points = points.ToArray();

        mesh.RecalculateNormals();
    }
}
