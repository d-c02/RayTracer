using System;

class Hittable_List : Hittable
{
	List<Hittable> objects = new List<Hittable>();
	public Hittable_List()
	{
	}

	public void clear()
	{
		objects.Clear();
	}

	public void add(Hittable obj)
	{
		objects.Add(obj);
	}

    public override bool hit(Ray r, double t_min, double t_max, ref hit_record record)
	{
		hit_record temporary_record = new hit_record();
		bool hit_anything = false;
		var closest_so_far = t_max;

		for(int i = 0; i < objects.Count; i++)
		{
			if (objects[i].hit(r, t_min, closest_so_far, ref temporary_record))
			{
				hit_anything = true;
				closest_so_far = temporary_record.t;
				record = temporary_record;
			}
		}
        return hit_anything;
	}
}
