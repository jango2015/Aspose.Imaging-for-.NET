using System;
using System.IO;
using Aspose.Imaging.FileFormats.Tiff;

namespace Aspose.Imaging.Examples.CSharp.ModifyingAndConvertingImages
{
    public class ConcatTIFFImages
    {
        public static void Run()
        {
            // To get proper output please apply a valid Aspose.Imaging License. You can purchase full license or get 30 day temporary license from http:// Www.aspose.com/purchase/default.aspx.");
            // ExStart:ConcatTIFFImages
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ModifyingAndConvertingImages();

            // Create a copy of original image to avoid any alteration
            File.Copy(dataDir + "demo.tif", dataDir + "TestDemo.tif", true);

            // Create an instance of TiffImage and load the copied destination image
            using (TiffImage image = (TiffImage)Image.Load(dataDir + "TestDemo.tif"))
            {
                // Create an instance of TiffImage and load the source image
                using (TiffImage image1 = (TiffImage)Image.Load(dataDir + "sample.tif"))
                {
                    // Create an instance of TIffFrame and copy active frame of source image
                    TiffFrame frame = TiffFrame.CopyFrame(image1.ActiveFrame);
                    
                    // Add copied frame to destination image
                    image.AddFrame(frame);
                    
                    // save the image with changes.
                    image.Save(dataDir + "ConcatTIFFImages_out.tiff");
                }
            }
            // ExEnd:ConcatTIFFImages
            // Display Status.
            Console.WriteLine("Concatenation of TIF files done successfully.");
        }
    }
}