namespace RayUp.Tracer
{
  public class MultipleObjects : Tracer
  {
    public MultipleObjects(World world): base(world)
    {
    }

    public override Vector3 TraceRay(Ray ray)
    {
      ShadeRec sr = world.HitBareBonesObjects(ray);
      if (sr != null)
      {
        return sr.color;
      }
      return world.bgColor;
    }
  }
}
