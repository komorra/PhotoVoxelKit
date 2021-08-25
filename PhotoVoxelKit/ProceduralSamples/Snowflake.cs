using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace PhotoVoxelKit.ProceduralSamples
{
    public class Snowflake : Procedural
    {        
        public int MinArmCount { get; set; }
        public int MaxArmCount { get; set; }

        public Snowflake()
        {
            MinArmCount = 4;
            MaxArmCount = 8;
        }

        public class SnowflakeArm : Procedural
        {
            Random random;
            public override void Create()
            {
                random = new Random(Seed);

                var length = random.Next(10, 20);
                Line(Int3.Zero, Int3.UnitZ * length, IceCristal);
            }

            void IceCristal(Int3 position)
            {
                SetVoxel(position, Color.White, 0.5f);
                position.X *= -1;
                SetVoxel(position, Color.White, 0.5f);
                
                if(random.NextDouble() < 0.07)
                {
                    var from = position;
                    position.X += random.Next(-10, 10);
                    position.Z += random.Next(-10, 10);

                    Line(from, position, IceCristal);
                }
            }
        }

        public override void Create()
        {
            var random = new Random(Seed);
            var armSeed = random.Next();

            var arms = random.Next(MinArmCount, MaxArmCount + 1);

            for (int i = 0; i < arms; i++)
            {
                var angle = i * 360f / arms;
                var arm = AddChild<SnowflakeArm>("arm" + i, armSeed);
                arm.Translate(new Vector3(-0.5f, 0, 0));
                arm.Rotate(Quaternion.RotationAxis(Vector3.Up, MathUtil.DegreesToRadians(angle)));
            }
        }
    }
}
