﻿using System;
using System.Diagnostics;

namespace RayUp
{
  class RayUp
  {
    static void Main(string[] args)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      World w = new World();
      w.Build();
      w.camera.RenderScene(w);
      stopwatch.Stop();
      Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds);
    }
  }
}
