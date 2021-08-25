using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoVoxelKit.ProceduralSamples
{
    public class Bush : Procedural
    {
        Random random;
        bool recursive = true;

        public int MaxSize { get; set; }

        public Bush()
        {
            MaxSize = 10;
        }

        public override void Create()
        {
            random = new Random(Seed);

            var ext = Int3.Zero;
            MaxSize = Math.Max(1, MaxSize);
            ext.X = random.Next(0, MaxSize);
            ext.Z = random.Next(0, MaxSize);
            ext.Y = random.Next(0, MaxSize);

            Sphere(-ext, ext, Foliage);
        }

        private void Foliage(Int3 position)
        {
            var color = Color.Green;
            color = HSV(color, random.NextVector3(-Vector3.One, Vector3.One) * 0.1f);
            if (position.Y >= 0)
            {
                SetVoxel(position, color);
            }
            if (random.NextDouble() < 0.01 && recursive)
            {
                recursive = false;
                Sphere(position - Int3.One * 5, position + Int3.One * 5, Foliage);
                recursive = true;
            }
        }
    }
}
