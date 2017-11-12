namespace RayUp.Geometry
{
  public class Plane : GeometricObject
  {
    private Vector3 point;
    private Vector3 normal;

    public Plane(Vector3 p, Vector3 normal)
    {
      point = p;
      this.normal = normal;
    }

    public override ShadeRec Hit(Ray ray, ref double tmin)
    {
      double t = (point - ray.orig) * normal / (ray.dir * normal);

      if (t > Constants.EPSILON)
      {
        tmin = t;
        ShadeRec sr = new ShadeRec();
        sr.normal = normal;
        sr.localHitPoint = ray.PointAt(t);
        return sr;
      }
      return null;
    }

  }
}
