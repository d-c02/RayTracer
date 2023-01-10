using System;

class Sphere : Hittable
{
	public Vec3 center;
	public double radius;
	public Sphere()
	{

	}

	public Sphere(Vec3 c, double r)
	{
		center = c;
		radius = r;
	}

	public override bool hit(Ray r, double t_min, double t_max, ref hit_record record)
    {
        Vec3 offset = r.origin() - center;
        var a = r.direction().Length_squared();
        var half_b = Vec3.Dot(r.direction(), offset);
        var c = offset.Length_squared() - (radius * radius);
        var discriminant = (half_b * half_b) - a * c;

		if (discriminant < 0)
		{
			return false;
		}

		var discriminant_root = Math.Sqrt(discriminant);
        var root = -half_b - discriminant_root;
		if (root < t_min || root > t_max)
		{
			root = -half_b + discriminant_root;
			return !(root < t_min || root > t_max);
		}
		record.t = root;
		record.p = r.at(root);
		Vec3 outward_normal = (record.p - center) / radius;
		record.set_face_normal(r, outward_normal);

		return true;
    }
}
