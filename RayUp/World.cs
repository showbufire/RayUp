using RayUp.Geometry;
using System.IO;

namespace RayUp
{
  public class World
  {
    private const string OUTPUT_FILENAME = "output.pnm";

    public ViewPlane vp = new ViewPlane();
    public Sphere sphere;
    private Tracer.Tracer tracer;
 
    public void Build()
    {
      vp.hres = 200;
      vp.vres = 200;
      vp.s = 1.0;

      sphere = new Sphere(new Vector3(), 85.0);
      tracer = new Tracer.SingleSphere(this);
    }

    public void RenderScene()
    {
      double zw = 100.0;
      Ray ray = new Ray(new Vector3(), new Vector3(0, 0, -1));

      using (StreamWriter outputFile = new StreamWriter(OUTPUT_FILENAME))
      {
        outputFile.WriteLine("P3");
        outputFile.WriteLine("{0} {1} {2}", vp.hres, vp.vres, 255);
        for (int r = 0; r < vp.vres; r++)
        {
          for (int c = 0; c < vp.hres; c++)
          {
            double x = vp.s * (c - 0.5 * (vp.hres - 1.0));
            double y = vp.s * (r - 0.5 * (vp.vres - 1.0));
            ray.orig = new Vector3(x, y, zw);
            Vector3 pixelColor = tracer.TraceRay(ray);
            outputFile.WriteLine("{0} {1} {2}", pixelColor.r, pixelColor.g, pixelColor.b);
          }
        }
      }
    }
  }
}
