using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Application
{
    public class FileExtentionLimitationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] validextentation;

        public FileExtentionLimitationAttribute(string[] validextentation)
        {
            this.validextentation = validextentation;
        }
        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;

            var fileextention = Path.GetExtension(file.FileName);
            return validextentation.Contains(fileextention);
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            //context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-fileExtentionLimitation", ErrorMessage);
        }
    }
}
