using RayUp.Geometry;
using System.IO;
using System.Collections.Generic;

namespace RayUp
{
  public class World
  {
    private const string OUTPUT_FILENAME = "output.pnm";
    private const int NUM_SAMPLES = 25;
    private const int NUM_SETS = 100;
    public readonly Vector3 bgColor = Constants.BLACK;

    public ViewPlane viewPlane;
    public Tracer.Tracer tracer;
    public Camera.Camera camera;

    public Sphere sphere; // only used in single object tracing

    private List<GeometricObject> objects = new List<GeometricObject>();

    public void Build()
    {
      viewPlane = new ViewPlane();
      viewPlane.hres = 200;
      viewPlane.vres = 200;
      viewPlane.s = 1.0;
      viewPlane.sampler = new Sampler.Jittered(NUM_SETS, NUM_SAMPLES);
      viewPlane.numSamples = NUM_SAMPLES;

      tracer = new Tracer.MultipleObjects(this);
      camera = new Camera.Pinhole(new Vector3(300, 400, 500),
        new Vector3(0, 0, -50),
        400);

      Sphere sphere = new Sphere(new Vector3(0, 0, 0), 100);
      sphere.Color = Constants.RED;
      AddObject(sphere);

      Sphere sphere2 = new Sphere(new Vector3(0, 0, 100), 60);
      sphere2.Color = Constants.YELLOW;
      AddObject(sphere2);
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

    public StreamWriter OpenWindow()
    {
      return new StreamWriter(OUTPUT_FILENAME);
    }
  }
}
