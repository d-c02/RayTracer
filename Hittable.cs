using System;

struct hit_record
{
    public Vec3 p;
    public Vec3 normal;
    public double t;
    public bool facing_outwards;

    public void set_face_normal(Ray r, Vec3 outward_normal)
    {
        if (Vec3.Dot(r.direction(), outward_normal) > 0.0)
        {
            facing_outwards = false;
            normal = -outward_normal;
        }
        else
        {
            facing_outwards = true;
            normal = outward_normal;
        }
    }
}
abstract class Hittable
{
    public abstract bool hit(Ray r, double t_min, double t_max, ref hit_record record);
}
