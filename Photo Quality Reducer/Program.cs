using ImageProcessor;
using ImageProcessor.Imaging;
using System;
using System.IO;
using System.Linq;

namespace Photo_Quality_Reducer
{
    class Program
    {
        const string PhotoSource = "c://Photos";
        const string PhotoDestination = "c://Photos-Optimised";

        static void Main(string[] args)
        {
            // Create Destination folder if it doesn't exist
            Directory.CreateDirectory(PhotoDestination);

            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
            {
                var resizelayer = new ResizeLayer(new System.Drawing.Size(1500, 1500), ResizeMode.Min);

                string[] files = Directory.GetFiles(PhotoSource);

                int i = 1;

                foreach (var path in files)
                {
                    var filename = Path.GetFileName(path);

                    imageFactory.Load(Path.Combine(PhotoSource, filename))
                        .Resize(resizelayer)
                        .Quality(90)
                        .Save(Path.Combine(PhotoDestination, filename));

                    Console.WriteLine(i++);
                }
            }
        }
    }
}
