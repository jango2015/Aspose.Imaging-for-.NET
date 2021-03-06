using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

namespace Aspose.Imaging.Examples.CSharp.ModifyingAndConvertingImages
{
    public class ConcatenateTiffImagesHavingSeveralFrames
    {
        public static void Run()
        {
            // To get proper output please apply a valid Aspose.Imaging License. You can purchase full license or get 30 day temporary license from http:// Www.aspose.com/purchase/default.aspx.");
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ModifyingAndConvertingImages();

            List<string> files = new List<string>(new string[] { dataDir + "TestDemo.tiff", dataDir + "sample.tiff" });
            TiffOptions createOptions = new TiffOptions(TiffExpectedFormat.Default);
            createOptions.BitsPerSample = new ushort[] { 1 };
            createOptions.Orientation = TiffOrientations.TopLeft;
            createOptions.Photometric = TiffPhotometrics.MinIsBlack;
            createOptions.Compression = TiffCompressions.CcittFax3;
            createOptions.FillOrder = TiffFillOrders.Lsb2Msb;

            //Create a new image by passing the TiffOptions and size of first frame
            //we will remove the first frame at the end, cause it will be empty
            TiffImage output = null;
            try
            {
                List<TiffImage> images = new List<TiffImage>();
                try
                {
                    foreach (var file in files)
                    {
                        //Create an instance of TiffImage and load the source image
                        TiffImage input = (TiffImage)Image.Load(file);
                        images.Add(input); // Do not dispose before data is fetched. Data is fetched on 'Save' later.
                        foreach (var frame in input.Frames)
                        {
                            if (output == null)
                            {
                                // create a new tiff image with first frame defined.
                                output = new TiffImage(TiffFrame.CopyFrame(frame));
                            }
                            else
                            {
                                // Add copied frame to destination image
                                output.AddFrame(TiffFrame.CopyFrame(frame));
                            }
                        }
                    }

                    if (output != null)
                    {
                        // save the result
                        output.Save(dataDir + "ConcatenateTiffImagesHavingSeveralFrames_out.tif", createOptions);
                    }
                }
                finally
                {
                    foreach (TiffImage image in images)
                    {
                        image.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}