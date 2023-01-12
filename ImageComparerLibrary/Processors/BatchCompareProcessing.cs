using Emgu.CV;
using ImageComparerLibrary.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComparerLibrary.Processors
{
    public class BatchCompareProcessing<T> where T: struct, IColor
    {
        protected string[] files;
        protected ComparerProcessor<T> processor;
        protected HashSet<HashSet<string>> comparedList = new();
        private object lockObj = new();

        public BatchCompareProcessing(string[] files, ComparerProcessor<T> processor)
        {
            this.files = files;
            this.processor = processor;
        }

        protected virtual void AddPair(string one, string two)
        {
            lock(lockObj)
            {
                var set = comparedList.Where(c => c.Contains(one) || c.Contains(two)).FirstOrDefault();
                if (set == null)
                {
                    set = new HashSet<string>();
                    comparedList.Add(set);
                }
                set.Add(one);
                set.Add(two);
            }
        }

        public virtual HashSet<HashSet<string>> CompareProcess()
        {
            Parallel.For(0, files.Length, BaseFileProcess);
            return comparedList;
        }

        protected virtual void BaseFileProcess(int i, ParallelLoopState pls)
        {
            Image<T, byte> imageOne = new(files[i]);
            Parallel.For(i + 1, files.Length, (r) =>
            {
                Image<T, byte> imageTwo = new(files[r]);
                try
                {
                    var diffImage = processor.Compare(imageOne, imageTwo);
                    if (diffImage != null)
                    {
                        if(diffImage.IsZero())
                            AddPair(files[i], files[r]);
                    }
                }
                catch
                {
                    
                }
            });
        }
    }
}
