using System;
using System.Collections.Generic;

namespace RayUp.Sampler
{
  public abstract class Sampler
  {
    protected int numSamples;
    protected int numSets;
    protected List<Vector2> samples = new List<Vector2>();
    protected int n;

    private int count = 0;
    private int jump = 0;
    private Random rand;

    public Sampler(int numSets, int numSamples)
    {
      this.numSets = numSets;
      this.numSamples = numSamples;
      n = (int)Math.Round(Math.Sqrt(numSamples));

      GenerateSamples();
    }

    protected abstract void GenerateSamples();

    public Vector2 SampleUnitSquare()
    {
      rand = new Random();
      if (count == 0)
      {
        jump = rand.Next() % numSets;
      }
      Vector2 ret = samples[jump + count];
      count += 1;
      if (count == numSamples)
      {
        count = 0;
      }
      return ret;
    }
  }
}
