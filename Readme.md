# Image Comparer

Simple tool to batch compare images. Used OpenCv (Emgu.CV) to compare images.

Use:

* Drag and drop folder to application, or pass path first argument
* Wait for the image folder to finish processing
* Tools check all files in folder and show result.

Library ImageComparerLibrary:
* BatchCompareProcessing<T>
    * BatchCompareProcessing(string[] files, ComparerProcessor<T> processor) - files list, compare processor    
    * CompareProcess() - start processing - return list of files  
* ComparerProcessor<T>
    * Compare(Image<T, byte> oneImage, Image<T, byte> twoImage) - return diff image 