namespace RayUp
{
    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3()
        {
        }

        public Vector3(float x, float y, float z = 0f)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);

        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

        public static float operator *(Vector3 a, Vector3 b) => a.x * b.x + a.y * b.y + a.z * b.z;

        public static Vector3 operator *(Vector3 a, float c) => new Vector3(a.x * c, a.y * c, a.z * c);

        public static Vector3 operator *(float c, Vector3 a) => new Vector3(a.x * c, a.y * c, a.z * c);

        public static Vector3 operator /(Vector3 a, float c) => new Vector3(a.x / c, a.y / c, a.z / c);

        public float Length() => (float)System.Math.Sqrt(SquaredLength());

        public float SquaredLength() => x * x + y * y + z * z;
    }
}
