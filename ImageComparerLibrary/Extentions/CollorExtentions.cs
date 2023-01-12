using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComparerLibrary.Extentions
{
    public static class ExtentionZeroCheck
    {
        public static bool IsZero(this IColor color)
        {
            if (!color.MCvScalar.Equals(new MCvScalar(0,0,0,0)))
                return false;
            return true;
        }

        public static bool IsZero<T>(this Image<T, byte> image) where T: struct, IColor
        {
            return image.GetSum().IsZero();
        }
    }
}
