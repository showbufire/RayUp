namespace RayUp.Tracer
{
  public class SingleSphere : Tracer
  {
    public SingleSphere(World world): base(world)
    {
    }

    public override Vector3 TraceRay(Ray ray)
    {
      double t = 0;
      ShadeRec sr = world.sphere.Hit(ray, ref t);
      if (sr != null)
      {
        return Constants.RED;
      }
      return Constants.BLACK;
    }
  }
}
