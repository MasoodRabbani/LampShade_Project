using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile form,string namefolder);
        void DeleteImagEdit(string path);
    }
}
