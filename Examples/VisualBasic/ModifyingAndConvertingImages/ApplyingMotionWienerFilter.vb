﻿
Imports Aspose.Imaging.ImageFilters.FilterOptions
Imports Aspose.Imaging

'
'This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Imaging for .NET API reference 
'when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
'If you do not wish to use NuGet, you can manually download Aspose.Imaging for .NET API from http://www.aspose.com/downloads, 
'install it and then add its reference to this project. For any issues, questions or suggestions 
'please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
'


Namespace Aspose.Imaging.Examples.VisualBasic.ModifyingAndConvertingImages
    Class ApplyingMotionWienerFilter
        Public Shared Sub Run()
            ' To get proper output please apply a valid Aspose.Imaging License. You can purchase full license or get 30 day temporary license from http:// Www.aspose.com/purchase/default.aspx.");
            ' ExStart:ApplyingMotionWienerFilter
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_ModifyingAndConvertingImages()

            ' Load the image
            Using image__1 As Image = Image.Load(dataDir & Convert.ToString("asposelogo.gif"))
                ' caste the image into RasterImage
                Dim rasterImage As RasterImage = TryCast(image__1, RasterImage)
                If rasterImage Is Nothing Then
                    Return
                End If

                ' Create an instance of MotionWienerFilterOptions class and set the length, smooth value and angle.
                Dim options As New MotionWienerFilterOptions(50, 9, 90)
                options.Grayscale = True

                ' apply MedianFilterOptions filter to RasterImage object.
                rasterImage.Filter(image__1.Bounds, options)

                ' Save the resultant image
                image__1.Save(dataDir & Convert.ToString("ApplyingMotionWienerFilter_out.gif"))
            End Using
            ' ExEnd:ApplyingMotionWienerFilter
        End Sub
    End Class
End Namespace
