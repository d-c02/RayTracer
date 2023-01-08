using System;
//A custom Vector3 implementation, created to brush up on C# OOP and make creating the rest of the program easier.
public class Vec3
{
	private double[] xyz;
	public Vec3()
	{
		xyz = new double[3] { 0.0, 0.0, 0.0 };
	}

	public Vec3(double x, double y, double z)
	{
		xyz = new double[3] { x, y, z };
	}

	public double x()
	{
		return xyz[0];
	}

	public double y() 
	{ 
		return xyz[1]; 
	}

	public double z() 
	{ 
		return xyz[2];
	}

	public double R => x();
	public double G => y();
	public double B => z();

	public static Vec3 operator -(Vec3 a)
	{
		return new Vec3(a.x() * -1, a.y() * -1, a.z() * -1);

	}

	public double this[int i]
	{
		get => xyz[i];
	}

	public double Length()
	{
		return Math.Sqrt(Length_squared());
	}

	public double Length_squared()
	{
		return Math.Pow(xyz[0], 2) + Math.Pow(xyz[1], 2) + Math.Pow(xyz[2], 2);

    }
	//Utility functions
	public static Vec3 operator +(Vec3 a, Vec3 b)
	{
		return new Vec3(a.x() + b.x(), a.y() + b.y(), a.z() + b.z());
	}

	public static Vec3 operator -(Vec3 a, Vec3 b)
	{
        return new Vec3(a.x() - b.x(), a.y() - b.y(), a.z() - b.z());
    }

    public static Vec3 operator *(Vec3 a, Vec3 b)
    {
        return new Vec3(a.x() * b.x(), a.y() * b.y(), a.z() * b.z());
    }

	public static Vec3 operator /(Vec3 a, double t)
	{
		return new Vec3(a.x() / t, a.y() / t, a.z() / t);
	}

    public static Vec3 operator *(Vec3 a, double t)
    {
        return new Vec3(a.x() * t, a.y() * t, a.z() * t);
    }

    public static Vec3 operator *(double t, Vec3 a)
    {
        return new Vec3(a.x() * t, a.y() * t, a.z() * t);
    }

    public static Vec3 Cross(Vec3 a, Vec3 b)
	{
		return new Vec3(a.y() * b.z() - a.z() * b.y(), a.z() * b.x() - a.x() * b.z(), a.x() * b.y() - a.y() * b.x());
	}

	public static double Dot(Vec3 a, Vec3 b)
	{
		return (a.x() * b.x() + a.y() * b.y() + a.z() * b.z());
	}
	public static Vec3 UnitVector(Vec3 a)
	{
		return a / a.Length();
	}
    public override string ToString()
    {
		return $"{xyz[0]} {xyz[1]} {xyz[2]}";
    }
}

