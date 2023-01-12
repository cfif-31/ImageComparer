using Emgu.CV;
using ImageComparerLibrary.Extentions;

namespace ImageComparerLibrary.Processors
{
    public class ComparerProcessor<T> where T: struct, IColor
    {
        public virtual Image<T, byte>? Compare(Image<T, byte> oneImage, Image<T, byte> twoImage)
        {
            if (oneImage.Width != twoImage.Width || oneImage.Height != twoImage.Height)
                return null;
            Image<T, byte> diffImage = new(oneImage.Width, oneImage.Height);
            CvInvoke.AbsDiff(oneImage, twoImage, diffImage);

            return diffImage;
        }
    }
}