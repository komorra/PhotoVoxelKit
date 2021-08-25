using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoVoxelKit.ProceduralSamples
{
    public class Cactus : Procedural
    {
        Random random;
        int size = 8;
        Int3 from;
        Int3 to;

        public override void Create()
        {
            random = new Random(Seed);

            var top = Int3.UnitY * random.Next(30, 50);
            top.X += random.Next(-10, 10);
            top.Y += random.Next(-10, 10);

            Arm2(Int3.Zero);
        }

        private void Flesh(Int3 coord)
        {                       
            int radius = 2 + size;
            var ext = new Int3(radius, radius, radius);

            this.from = coord;
            Sphere(coord - ext, coord + ext, Flesh2);
            if(random.NextDouble() < 0.05)
            {
                Spikes(coord);
            }    
            if(random.NextDouble() < 0.1 / (coord.Y + 1))
            {
                var top = coord + Int3.UnitY * random.Next(5, 15);
                top.X += random.Next(-10, 10);
                top.Y += random.Next(-10, 10);
                Arm2(coord);
            }            
        }

        private void Flesh2(Int3 coord)
        {
            var color = Color.LimeGreen;
            var ang = Math.Atan2(coord.Z - from.Z, coord.X - from.X);
            var vr = (float)Math.Sin(ang * 4.0f);

            color = HSV(color, new Vector3(0, 0, -coord.Y * 0.01f + vr * 0.2f));
            SetVoxel(coord, color);
        }

        private void Spikes(Int3 coord)
        {
            for (int i = 0; i < 10; i++)
            {
                var end = coord;
                end.X += random.Next(-6, 6);
                end.Y += random.Next(-6, 6);
                end.Z += random.Next(-6, 6);
                Line(coord, end, o=>SetVoxel(o, Color.Yellow));
            }
        }

        private void Arm2(Int3 from)
        {
            var ext = Int3.Zero;
            ext += Int3.UnitX * random.Next(-3, 3);
            ext += Int3.UnitZ * random.Next(-3, 3);

            var to = from + ext;
            var max = random.Next(8, 12);
            for (int i = 1; i < max; i++)
            {
                size = (int)(Math.Sin(Scale(i, 1, max - 1, 0, MathUtil.Pi)) * 4);
                
                Line(from, to, Flesh);
                from = to;
                to += ext;
                to += Int3.UnitY * i;
            }
        }

        public static float Scale(float x, float a, float b, float c, float d, bool clamp = false)
        {
            if (a == b)
            {
                return (c + d) / 2f;
            }
            var s = b - a == 0f ? x : (x - a) / (b - a);
            var r = s * (d - c) + c;
            if (clamp)
            {
                if (r > d)
                {
                    r = d;
                }
                if (r < c)
                {
                    r = c;
                }
            }
            return r;
        }
    }
}
