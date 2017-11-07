namespace RayUp
{
    public class Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3()
        {
        }

        public Vector3(float x, float y, float z = 0f)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static float operator *(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        public static Vector3 operator *(Vector3 a, float c) => new Vector3(a.X * c, a.Y * c, a.Z * c);

        public static Vector3 operator *(float c, Vector3 a) => new Vector3(a.X * c, a.Y * c, a.Z * c);

        public static Vector3 operator /(Vector3 a, float c) => new Vector3(a.X / c, a.Y / c, a.Z / c);

        public float Length() => (float)System.Math.Sqrt(SquaredLength());

        public float SquaredLength() => X * X + Y * Y + Z * Z;
    }
}
