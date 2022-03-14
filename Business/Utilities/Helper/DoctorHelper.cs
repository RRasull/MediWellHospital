using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Business.Utilities.Helper
{
    public static class DoctorHelper
    {
        public static bool CheckContent(this IFormFile file, string content)
        {
            return file.ContentType.Contains(content);
        }

        public static bool CheckLength(this IFormFile file, int size)
        {
            return file.Length / 1024 < size;
        }

        public static async Task<string> SaveFileAsync(this IFormFile file, string root, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            string resultPath = Path.Combine(root, folder, fileName);

            using (FileStream stream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public static void RemoveFileAsync(this IFormFile file, string root, string folder, string fileName)
        {
            var oldPath = Path.Combine(root, folder, fileName);


            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

        }
    }
}
