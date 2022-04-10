using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string folder, string oldFolder)
        {
            Delete(Path.Combine(folder, oldFolder));
            return Upload(file, folder);
        }

        public string Upload(IFormFile file, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + "." + file.ContentType.Split("/")[1];
            string fullPath = Path.Combine(folder, fileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return fileName;
            }
        }
    }
}
