
using Microsoft.AspNetCore.Http;
using System;

namespace _01_Farmework.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile File,String path);
    }
}
