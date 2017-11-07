namespace RayUp
{
    public class Ray
    {
        public Vector3 orig;
        public Vector3 dir;

        public Ray()
        {
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            orig = origin;
            dir = direction;
        }
    }
}
