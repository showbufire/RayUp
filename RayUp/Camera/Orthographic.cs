using System.IO;

namespace RayUp.Camera
{
  public class Orthographic : Camera
  {
    private const double DIST = 100;

    public override void RenderScene(World world)
    {
      ViewPlane viewPlane = world.viewPlane;
      using (StreamWriter outputFile = world.OpenWindow())
      {
        outputFile.WriteLine("P3");
        outputFile.WriteLine("{0} {1} {2}", viewPlane.hres, viewPlane.vres, 255);
        for (int r = viewPlane.vres - 1; r >= 0; r--)
        {
          for (int c = viewPlane.hres - 1; c >= 0; c--)
          {
            Vector3 pixelColor = new Vector3();
            for (int k = 0; k < viewPlane.numSamples; k++)
            {
              Vector2 sp = viewPlane.sampler.SampleUnitSquare();
              double x = viewPlane.s * (c - 0.5 * viewPlane.hres + sp.x);
              double y = viewPlane.s * (r - 0.5 * viewPlane.vres + sp.y);
              Ray ray = new Ray(new Vector3(x, y, DIST),
                new Vector3(0, 0, -1));
              pixelColor += world.tracer.TraceRay(ray);
            }
            pixelColor /= viewPlane.numSamples;
            outputFile.WriteLine("{0} {1} {2}", pixelColor.r, pixelColor.g, pixelColor.b);
          }
        }
      }
    }
  }
}
