namespace RayUp
{
  class RayUp
  {
    static void Main(string[] args)
    {
      World w = new World();
      w.Build();
      w.RenderScene();
    }
  }
}
