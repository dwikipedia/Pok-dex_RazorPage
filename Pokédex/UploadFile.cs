using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Pokédex
{
    public static class UploadFile
    {
        private static IWebHostEnvironment _hosting;

        public static bool IsInitialized { get; private set; }

        public static void Initialize(IWebHostEnvironment hosting)
        {
            if (IsInitialized)
                throw new InvalidOperationException("Object already initialized");

            _hosting = hosting;
            IsInitialized = true;
        }

        public static string SaveAndGetFileName(IFormFile file)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Object is not initialized");

            string folder = Path.Combine(_hosting.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(folder, uniqueFileName);
            file.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }
    }
}
