using System;

public class color
{
	public static void write_color(StreamWriter outputfile, Vec3 pixel_color)
	{
		outputfile.WriteLine(pixel_color.x() * 255.999 + " " + pixel_color.y() * 255.999 + " " + pixel_color.z() * 255.999);
	}
}
