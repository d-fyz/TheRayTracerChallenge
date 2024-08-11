using System;

namespace Tuples;

public struct RTCTuple
{
    public float x;
    public float y;
    public float z;
    public float w;
    
    public RTCTuple() { }

    public RTCTuple(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public float Magnitude() => MathF.Sqrt(x * x + y * y + z * z);
    
    public float MagnitudeSqr() => x * x + y * y + z * z;

    public RTCTuple Normalize()
    {
        var m = Magnitude();
        return new RTCTuple(x / m, y / m, z / m, w);
    }
    
    public static RTCTuple operator +(RTCTuple a, RTCTuple b)
    {
        return new RTCTuple(
            a.x + b.x,
            a.y + b.y,
            a.z + b.z,
            a.w + b.w);
    }
    
    public static RTCTuple operator -(RTCTuple a, RTCTuple b)
    {
        return new RTCTuple(
            a.x - b.x,
            a.y - b.y,
            a.z - b.z,
            a.w - b.w);
    }
    
    public static RTCTuple operator -(RTCTuple a)
    {
        return new RTCTuple(-a.x, -a.y, -a.z, -a.w);
    }
    
    public static RTCTuple operator *(RTCTuple tuple, float mul)
    {
        return new RTCTuple(
            tuple.x * mul, 
            tuple.y * mul, 
            tuple.z * mul, 
            tuple.w * mul);
    }
    
    public static RTCTuple operator /(RTCTuple tuple, float div)
    {
        return new RTCTuple(
            tuple.x / div, 
            tuple.y / div, 
            tuple.z / div, 
            tuple.w / div);
    }

    public static RTCTuple Point(float x, float y, float z) => new RTCTuple(x, y, z, 1);
    public static RTCTuple Vector(float x, float y, float z) => new RTCTuple(x, y, z, 0);
    
    public static bool IsPoint(RTCTuple tuple) => tuple.w != 0;
    public static bool IsVector(RTCTuple tuple) => tuple.w == 0f;

    public static float Dot(RTCTuple a, RTCTuple b) => a.x * b.x + a.y * b.y + a.z * b.z;

    public static RTCTuple Cross(RTCTuple a, RTCTuple b) =>
        RTCTuple.Vector(
            a.y * b.z - a.z * b.y,
            a.z * b.x - a.x * b.z,
            a.x * b.y - a.y * b.x);
}