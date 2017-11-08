namespace RayUp
{
  public class Vector3
  {
    public double x;
    public double y;
    public double z;

    public Vector3()
    {
    }

    public Vector3(double x, double y, double z = 0f)
    {
      this.x = x;
      this.y = y;
      this.z = z;
    }

    public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);

    public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

    public static double operator *(Vector3 a, Vector3 b) => a.x * b.x + a.y * b.y + a.z * b.z;

    public static Vector3 operator *(Vector3 a, double c) => new Vector3(a.x * c, a.y * c, a.z * c);

    public static Vector3 operator *(double c, Vector3 a) => new Vector3(a.x * c, a.y * c, a.z * c);

    public static Vector3 operator /(Vector3 a, double c) => new Vector3(a.x / c, a.y / c, a.z / c);

    public double Length() => System.Math.Sqrt(SquaredLength());

    public double SquaredLength() => x * x + y * y + z * z;
  }
}
