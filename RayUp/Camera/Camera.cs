namespace RayUp.Camera
{
  public abstract class Camera
  {
    private static readonly Vector3 up = new Vector3(0, 1, 0);

    protected Vector3 eye;
    protected Vector3 lookat;
    protected Vector3 u, v, w;

    public abstract void RenderScene(World world);

    public void ComputeUVW()
    {
      w = (eye - lookat).Unit();
      u = up ^ w;
      u.Normalize();
      v = w ^ u;
    }
  }
}
