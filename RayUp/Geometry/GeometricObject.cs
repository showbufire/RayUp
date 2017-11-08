namespace RayUp.Geometry
{
  public abstract class GeometricObject
  {
    public abstract ShadeRec Hit(Ray ray, ref double tmin);
  }
}
