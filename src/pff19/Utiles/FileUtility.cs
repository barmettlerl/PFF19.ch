
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace pff19.Utiles
{
    public class FileUtility
    {
        private readonly IHostingEnvironment _environment;

        public FileUtility(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void SaveImage(Stream imageStream, string type, string subfolder, string filename, Size maxImageSize)
        {
            var basePath = Path.Combine(_environment.WebRootPath, "assets", type);
            var imagePath = Path.Combine(basePath, subfolder, filename);
            Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
            
            using (Image<Rgba32> image = Image.Load(imageStream))
            {
                image.Mutate(x => x.Resize(new ResizeOptions { Mode = ResizeMode.Max, Size = maxImageSize }));
                image.Save(imagePath); // Automatic encoder selected based on extension.
            }
        }
    }
}
