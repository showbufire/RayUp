using System;

namespace RayUp.Sampler
{
  public class Jittered : Sampler
  {
    public Jittered(int numSets, int numSamples): base(numSets, numSamples)
    {
    }

    protected override void GenerateSamples()
    {
      Random rand = new Random();
      for (int p = 0; p < numSets; p++)
      {
        for (int j = 0; j < n; j++)
        {
          for (int k = 0; k < n; k++)
          {
            Vector2 sp = new Vector2((k + rand.NextDouble()) / n, (j + rand.NextDouble()) / n);
            samples.Add(sp);
          }
        }
      }
    }
  }
}
