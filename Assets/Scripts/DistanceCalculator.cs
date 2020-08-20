using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public float lat1, lat2, lon1, lon2;

    public uint CalculateDistance()
    {
        uint radius = 6371000;
        float Fi1, Fi2;
        float deltaFi, deltaLambda;

        Fi1 = lat1 * Mathf.Deg2Rad;
        Fi2 = lat2 * Mathf.Deg2Rad;
        deltaFi = (lat2 - lat1) * Mathf.Deg2Rad;
        deltaLambda = (lon2 - lon1) * Mathf.Deg2Rad;

        float a = Mathf.Sin(deltaFi / 2) * Mathf.Sin(deltaFi / 2)
            + Mathf.Cos(Fi1) * Mathf.Cos(Fi2)
            * Mathf.Sin(deltaLambda / 2) * Mathf.Sin(deltaLambda / 2);

        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        float distance = radius * c;

        return (uint) distance;
    }
}
