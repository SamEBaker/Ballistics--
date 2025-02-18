using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSolutions
{
    public Nullable<Vector3> Calc(Vector3 start, Vector3 end, float muzzleV, Vector3 gravity)
    {
        Nullable<float> ttt = GetTimeToTarget(start, end, muzzleV, gravity);
        if (!ttt.HasValue)
        {
            return null;
        }
        Vector3 delta = end - start;
        Vector3 n1 = delta * 2;
        Vector3 n2 = gravity * (ttt.Value * ttt.Value);
        float d = 2 * muzzleV * ttt.Value;
        Vector3 solution = (n1 - n2) / d;
        return solution;
    }
    public Nullable<float> GetTimeToTarget(Vector3 start, Vector3 end, float muzzleV, Vector3 gravity)
    {
        Vector3 delta = start - end;
        float a = gravity.magnitude * gravity.magnitude;
        float b = -4 * (Vector3.Dot(gravity, delta) + muzzleV * muzzleV);
        float c = 4 * delta.magnitude * delta.magnitude;
        float d = (b * b) - (4 * a * c);
        if(d < 0)
        {
            return null;
        }
        float time0 = Mathf.Sqrt((-b + Mathf.Sqrt(d)) / (2 * a));
        float time1 = Mathf.Sqrt((-b - Mathf.Sqrt(d)) / (2 * a));
        Nullable<float> ttt;
        if(time0 < 0)
        {
            if(time1 < 0)
            {
                return null;
            }
            else
            {
                ttt = time1;
            }
        }
        else if(time1 < 0)
        {
            ttt = time0;
        }
        else
        {
            ttt = Mathf.Min(time0, time1);
        }

        Debug.Log(ttt);
        return ttt;
    }
}
