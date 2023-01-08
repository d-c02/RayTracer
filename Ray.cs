using System;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

public class Ray
{
    Vec3 orig;
    Vec3 dir;
    public Ray(Vec3 origin, Vec3 direction)
	{
        orig = origin;
        dir = direction;
	}
    public Vec3 origin()
    {
        return orig;
    }

    public Vec3 direction()
    {
        return dir;
    }

    public Vec3 at(double t)
    {
        return orig + t * dir;
    }
}
