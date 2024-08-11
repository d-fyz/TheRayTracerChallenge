using System;

namespace Tuples;

public static class MathUtils
{
    public static bool Approximately(float a, float b)
    {
        return Math.Abs(b - a) < 1E-5;
    }
}