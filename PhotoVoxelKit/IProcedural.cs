using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoVoxelKit
{
    public delegate void Fill(Int3 position);

    public interface IProcedural
    {
        /// <summary>
        /// Seed set by the host - don't set manually!
        /// </summary>
        int Seed { get; set; }

        /// <summary>
        /// Sets voxel of given position
        /// </summary>        
        void SetVoxel(Int3 position, Color albedo, float metalness, float roughness, float emission);

        /// <summary>
        /// Removes voxel in given position
        /// </summary>        
        void RemoveVoxel(Int3 position);

        /// <summary>
        /// Fills space from min to max, calling fill function for each voxel (where you can customize color, etc.) 
        /// </summary> 
        void Box(Int3 min, Int3 max, Fill callback);

        /// <summary>
        /// Fills space from min to max within spherical shape, 
        /// calling fill function for each voxel (where you can customize color, etc.) 
        /// </summary>        
        void Sphere(Int3 min, Int3 max, Fill callback);

        /// <summary>
        /// Fills space like a line, calling fill for each line position.
        /// </summary>        
        void Line(Int3 start, Int3 end, Fill callback);

        /// <summary>
        /// Creates hue (x), saturation (y), value (z) based color
        /// </summary>        
        Color HSV(Vector3 hsvValue);

        /// <summary>
        /// Modifies source color by hsv change vector
        /// </summary>        
        Color HSV(Color source, Vector3 hsvChange);

        /// <summary>
        /// Creates sub-object that this object is parent for
        /// </summary>        
        T AddChild<T>(string name, int seed) where T : class, IProcedural, new();

        /// <summary>
        /// Moves this object by given translation vector
        /// </summary>        
        void Translate(Vector3 position);

        /// <summary>
        /// Rotates this object by given quaternion rotation
        /// </summary>        
        void Rotate(Quaternion rotation);

        /// <summary>
        /// Scales this object by given scale vector
        /// </summary>        
        void Scale(Vector3 scale);
    }
}
