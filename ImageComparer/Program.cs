using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ImageComparerLibrary;
using ImageComparerLibrary.Extentions;
using ImageComparerLibrary.Processors;
using System.Security.Cryptography;

namespace ImageComparer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 0)
            {
                Console.WriteLine("Directory path not set!");
                return;
            }
            string[] arr = Directory.GetFiles(args[0]);
            BatchCompareProcessing <Bgra> batchCompare = new(arr, new ComparerProcessor<Bgra>());
            var comparer = batchCompare.CompareProcess();
            foreach(var item in comparer) {
                Console.WriteLine(string.Join(" ", item.Select(i=>i)));
            }
        }
    }
}