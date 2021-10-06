using _01_Farmework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ServciceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnviroment = webHostEnvironment;
        }
        public string Upload(IFormFile File, String path)
        {
            if (File == null)
                return " ";
            var DirectoryPath= _webHostEnviroment.WebRootPath + "//ProductPicture//" + path;
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            var filename = $"{DateTime.Now.ToFileName()}-{File.FileName}";
            var filepath = $"{DirectoryPath}//{filename}";
            using (var output = System.IO.File.Create(filepath))
            {
                File.CopyTo(output);
            }

            return $"{path}//{filename}";
        }
    }
}
