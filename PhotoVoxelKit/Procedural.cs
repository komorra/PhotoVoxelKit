using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoVoxelKit
{
    public abstract class Procedural : IProcedural
    { 
        public int Seed { get; set; }

        public T AddChild<T>(string name, int seed) where T : class, IProcedural, new()
        {
            return default(T);
        }

        public void Box(Int3 min, Int3 max, Fill callback) { }

        public Color HSV(Vector3 hsvValue)
        {
            return default(Color);
        }

        public Color HSV(Color source, Vector3 hsvChange)
        {
            return default(Color);
        }

        public void Line(Int3 start, Int3 end, Fill callback) { }

        public void RemoveVoxel(Int3 position) { }

        public void Rotate(Quaternion rotation) { }

        public void Scale(Vector3 scale) { }

        public void SetVoxel(Int3 position, Color albedo, float metalness = 0f, float roughness = 0f, float emission = 0f) { }

        public void Sphere(Int3 min, Int3 max, Fill callback) { }

        public void Translate(Vector3 position) { }

        public abstract void Create();
    }
}
