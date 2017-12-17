using System.IO;

namespace RayUp.Camera
{
  public class Pinhole : Camera
  {
    private double dist;

    public Pinhole(Vector3 eye, Vector3 lookat, double dist)
    {
      this.eye = eye;
      this.lookat = lookat;
      this.dist = dist;
      ComputeUVW();
    }

    public override void RenderScene(World world)
    {
      ViewPlane vp = world.viewPlane;
      using (StreamWriter outputFile = world.OpenWindow())
      {
        outputFile.WriteLine("P3");
        outputFile.WriteLine("{0} {1} {2}", vp.hres, vp.vres, 255);
        for (int r = 0; r < vp.vres; r++)
        {
          for (int c = 0; c < vp.hres; c++)
          {
            Vector3 pixelColor = Constants.BLACK;
            for (int j = 0; j < vp.numSamples; j++)
            {
              Vector2 sp = vp.sampler.SampleUnitSquare();
              double x = vp.s * (c - 0.5 * vp.hres + sp.x);
              double y = vp.s * (r - 0.5 * vp.vres + sp.y);
              Ray ray = new Ray(this.eye, RayDirection(x, y));
              pixelColor += world.tracer.TraceRay(ray);
            }
            pixelColor /= vp.numSamples;
            outputFile.WriteLine("{0} {1} {2}", pixelColor.r, pixelColor.g, pixelColor.b);
          }
        }
      }
    }

    private Vector3 RayDirection(double x, double y)
    {
      Vector3 dir = x * u + y * v - dist * w;
      return dir.Unit();
    }
  }
}
