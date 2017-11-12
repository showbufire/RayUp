using RayUp.Geometry;
using System.IO;
using System.Collections.Generic;

namespace RayUp
{
  public class World
  {
    private const string OUTPUT_FILENAME = "output.pnm";

    public ViewPlane vp = new ViewPlane();
    public Sphere sphere;
    public Vector3 bgColor = Constants.BLACK;

    private Tracer.Tracer tracer;
    private List<GeometricObject> objects = new List<GeometricObject>();

    public void Build()
    {
      vp.hres = 200;
      vp.vres = 200;
      vp.s = 1.0;

      tracer = new Tracer.MultipleObjects(this);

      Sphere sphere = new Sphere(new Vector3(0, -25, 0), 80);
      sphere.Color = Constants.RED;
      AddObject(sphere);

      Sphere sphere2 = new Sphere(new Vector3(0, 30, 0), 60);
      sphere2.Color = Constants.YELLOW;
      AddObject(sphere2);

      Plane plane = new Plane(new Vector3(0, 0, 0), new Vector3(0, 1, 1));
      plane.Color = 0.3 * Constants.GREEN;
      AddObject(plane);
    }

    private void AddObject(GeometricObject obj)
    {
      objects.Add(obj);
    }

    public ShadeRec HitBareBonesObjects(Ray ray)
    {
      double t = 0;
      double tmin = double.MaxValue;
      ShadeRec ret = null;

      for (int j = 0; j < objects.Count; j++)
      {
        ShadeRec sr = objects[j].Hit(ray, ref t);
        if (sr != null && t < tmin)
        {
          tmin = t;
          ret = sr;
          sr.color = objects[j].Color;
        }
      }
      return ret;
    }

    public void RenderScene()
    {
      double zw = 100.0;
      Ray ray = new Ray(new Vector3(), new Vector3(0, 0, -1));

      using (StreamWriter outputFile = new StreamWriter(OUTPUT_FILENAME))
      {
        outputFile.WriteLine("P3");
        outputFile.WriteLine("{0} {1} {2}", vp.hres, vp.vres, 255);
        for (int r = vp.vres - 1; r >= 0; r--)
        {
          for (int c = vp.hres - 1; c >= 0; c--)
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
