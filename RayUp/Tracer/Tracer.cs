namespace RayUp.Tracer
{
  public abstract class Tracer
  {
    protected World world;

    public Tracer(World world)
    {
      this.world = world;
    }

    public abstract Vector3 TraceRay(Ray ray);
  }
}
