using _0_Framwork.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ServicesHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public void DeleteImagEdit(string path)
        {
            File.Delete(path);
        }

        public string Upload(IFormFile form,string namefolder)
        {
            if (form == null) return"";

            var pathdirectory = $"{webHostEnvironment.WebRootPath}/ProductPicture/{namefolder}";

            if (!Directory.Exists(pathdirectory))
            {
                Directory.CreateDirectory(pathdirectory);
            }
            var fullname = $"{DateTime.Now.ToFileName()}-{form.FileName}";
            var path = $"{pathdirectory}/{fullname}";
            
            using var output = System.IO.File.Create(path);
            form.CopyTo(output);
            return $"{namefolder}/{fullname}";
        }
    }
}
