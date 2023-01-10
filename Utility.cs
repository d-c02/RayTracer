using System;

public class Utility
{
    public double d2r(double degrees)
    {
        return degrees * Math.PI / 180;
    }

    public double r2d(double radians)
    {
        return radians * 180 / Math.PI;
    }
}
