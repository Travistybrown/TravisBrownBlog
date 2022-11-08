using System.Drawing.Text;
using TravisBrownBlog.Services.Interfaces;

namespace TravisBrownBlog.Services
{
    public class ImageService : IImageService
    {
        private readonly string defaultBlogPostImageSrc = "/img/defaultblogthumb.png";
        private readonly string defaultCategoryImageSrc = "/img/defaultcategorynoimage.jpg";
        private readonly string defaultUserImageSrc = "/img/defaultblogthumb.png";




        public string ConvertByteArrayToFile(byte[] fileData, string extension, int defaultImage)
        {
            if (fileData == null || fileData.Length == 0)
            {
                switch (defaultImage)
                {
                    case 1: return defaultUserImageSrc;
                    case 2: return defaultBlogPostImageSrc;
                    case 3: return defaultCategoryImageSrc;
                }
            }

            try
            {
                string imageBase64Data = Convert.ToBase64String(fileData!);
                string imageSrcString = string.Format($"data:{extension};base64,{imageBase64Data}");

                return imageSrcString;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            try
            {
                using MemoryStream memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                byte[] byteFile = memoryStream.ToArray();
                memoryStream.Close();

                return byteFile;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

