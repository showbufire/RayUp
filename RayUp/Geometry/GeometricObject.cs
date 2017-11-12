namespace RayUp.Geometry
{
  public abstract class GeometricObject
  {
    public abstract ShadeRec Hit(Ray ray, ref double tmin);

    public Vector3 Color
    {
      get; set;
    }
  }
}
