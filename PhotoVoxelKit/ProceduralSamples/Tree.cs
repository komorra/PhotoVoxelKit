using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoVoxelKit.ProceduralSamples
{
    public class Tree : Procedural
    {
        Random random;

        int currentRadius = 0;

        public Tree()
        {
            random = new Random(Seed);
        }

        public override void Create()
        {
            Trunk(Int3.Zero, Int3.UnitY * random.Next(10, 50), 4);
        }

        private void Trunk(Int3 a, Int3 b, int radius)
        {
            if (radius > 0)
            {
                var ext = Int3.One * radius;

                currentRadius = radius;
                Line(a, b, o => Sphere(o - ext, o + ext, Bark));                
            }
            else
            {
                var s = random.Next(6, 10);
                Sphere(a - Int3.One * s, a + Int3.One * s, Foliage);
            }
        }

        private void Foliage(Int3 position)
        {
            var color = Color.Green;
            color = HSV(color, random.NextVector3(-Vector3.One, Vector3.One) * 0.07f);
            SetVoxel(position, color);
        }

        private void Bark(Int3 position)
        {
            var color = Color.SaddleBrown;
            color = HSV(color, random.NextVector3(-Vector3.One, Vector3.One) * 0.03f);
            SetVoxel(position, color);

            if(random.NextDouble() < 0.0001 / currentRadius * position.Y)
            {
                var tilt = Int3.Zero;
                tilt.X += random.Next(-20,20);
                tilt.Z += random.Next(-20, 20);
                tilt.Y += random.Next(-5, 20);
                var t = currentRadius;
                Trunk(position, position + tilt, currentRadius-1);
                currentRadius = t;
            }
        }
    }
}
