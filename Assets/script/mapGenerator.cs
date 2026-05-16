using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class mapGenerator
{
    [Header("Map Setting")]
    public float maxGradient = 1;
    public int smoothness = 10;


    private List<float> mapGen()
    {
        // 총 길이 250 (-125 ~ 125), 각 칸 당 smoothness
        List<float> noise1 = monoNoise(11); // 간격 25 10번
        List<float> noise2 = monoNoise(51); // 간격 5 50번

        List<float> noise = new List<float>();
        for(int i = 0; i <= 250 * smoothness; i++)
        {
            noise.Append(noise1[i] + noise2[i]);
        }

        return noise;
    }

    private List<float> monoNoise(int pointCount)
    {
        // generate point
        List<float> noisePoint = new List<float>();
        for(int i = 1; i <= pointCount; i++)
        {
            noisePoint.Append(Random.Range(-maxGradient, maxGradient));
        }

        // interpolation
        int noiseCount = noisePoint.Count;

        List<float> monoNoise = new List<float>();
        float interval = 250 / (noiseCount - 1) * smoothness;

        for(int i = 0; i < noiseCount - 1; i++)
        {
            float A = noisePoint[i] + noisePoint[i+1];
            float B = noisePoint[i] * -2 - noisePoint[i+1];
            float C = noisePoint[i];
            
            for(int j = 0; j < interval; j++)
            {
                float t = 1 / interval * j;
                monoNoise.Append(A * t * t * t + B * t * t + C * t);
            }
        }
        monoNoise.Append(noisePoint[noiseCount -1]);

        return monoNoise;
    }
}
