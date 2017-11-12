using System;

namespace RayUp.Geometry
{
  public class Sphere : GeometricObject
  {
    private double radius;
    private Vector3 center;

    public Sphere(Vector3 center, double radius)
    {
      this.center = center;
      this.radius = radius;
    }

    public override ShadeRec Hit(Ray ray, ref double tmin)
    {
      double t;
      Vector3 temp = ray.orig - center;
      double a = ray.dir * ray.dir;
      double b = 2.0 * temp * ray.dir;
      double c = temp * temp - radius * radius;
      double disc = b * b - 4.0 * a * c;

      if (disc < 0)
      {
        return null;
      }
      double e = Math.Sqrt(disc);
      double denom = 2.0 * a;
      t = (-b - e) / denom;
      if (t > Constants.EPSILON)
      {
        tmin = t;
        ShadeRec sr = new ShadeRec();
        sr.normal = (temp + t * ray.dir) / radius;
        sr.localHitPoint = ray.PointAt(t);
        return sr;
      }
      t = (-b + e) / denom;
      if (t > Constants.EPSILON)
      {
        tmin = t;
        ShadeRec sr = new ShadeRec();
        sr.normal = (temp + t * ray.dir) / radius;
        sr.localHitPoint = ray.PointAt(t);
        return sr;
      }
      return null;
    }
  }
}
