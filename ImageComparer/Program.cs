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
            string basePath = args[0];
            string[] arr = Directory.GetFiles(basePath, "*.*", SearchOption.AllDirectories);
            BatchCompareProcessing <Bgra> batchCompare = new(arr, new ComparerProcessor<Bgra>());
            var comparer = batchCompare.CompareProcess();
            TextWriter writer = File.CreateText("Comare.log");
            foreach(var item in comparer) {
                Console.WriteLine(string.Join(" ", item.Select(i => i.Replace(basePath, ""))));
                writer.WriteLine(string.Join(" ", item.Select(i=>i.Replace(basePath, ""))));
            }
            writer.Close();
        }
    }
}