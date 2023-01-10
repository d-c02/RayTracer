// See https://aka.ms/new-console-template for more information
public class Program
{
    static Vec3 ray_color(Ray r, Hittable_List world)
    {
        hit_record record = new hit_record();
        if (world.hit(r, 0, double.PositiveInfinity, ref record))
        {
            return 0.5 * (record.normal + new Vec3(1, 1, 1));
        }
        Vec3 unit_direction = Vec3.UnitVector(r.direction());
        var t = 0.5 * (unit_direction.y() + 1.0);
        return (1.0 - t) * (new Vec3(1.0, 1.0, 1.0)) + t * (new Vec3(0.5, 0.7, 1.0));
    }

    static double hit_sphere(Vec3 center, double radius, Ray r)
    {
        Vec3 offset = r.origin() - center;
        var a = r.direction().Length_squared();
        var half_b = Vec3.Dot(r.direction(), offset);
        var c = offset.Length_squared() - (radius * radius);
        var discriminant = (half_b * half_b) - a * c;
        if (discriminant >= 0)
        {
            return (-half_b - Math.Sqrt(discriminant)) / a;
        }
        else
        {
            return -1;
        }
    }
    static void Render(int w, double aspect_ratio)
    {
        int h = (int)Math.Round(w / aspect_ratio);
        //Camera configs
        var viewport_height = 2.0;
        var viewport_width = aspect_ratio * viewport_height;
        var focal_length = 1.0;
        var origin = new Vec3();
        var horizontal = new Vec3(viewport_width, 0, 0);
        var vertical = new Vec3(0, viewport_height, 0);
        var lower_left_corner = origin - horizontal / 2 - vertical / 2 - (new Vec3(0, 0, focal_length));

        //world
        Hittable_List world = new Hittable_List();
        world.add(new Sphere(new Vec3(0, 0, -1), 0.5));
        world.add(new Sphere(new Vec3(0, -100.5, -1), 100));

        string fileName = "out.ppm";
        string curDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine("Outputted to: " + curDirectory);
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(curDirectory, fileName)))
        {
            outputFile.WriteLine("P3");
            outputFile.WriteLine(w + " " + h);
            outputFile.WriteLine("255");
            for (int j = h - 1; j >= 0; --j)
            {
                for (int i = 0; i < w; ++i)
                {
                    var u = ((double)i) / (w - 1);
                    var v = ((double) j) / (h - 1);
                    Ray r = new Ray(origin, lower_left_corner + u * horizontal + v*vertical - origin);
                    Vec3 pixel_color = ray_color(r, world);
                    color.write_color(outputFile, pixel_color);
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        Program.Render(400, (16.0 / 9.0));
    }
}