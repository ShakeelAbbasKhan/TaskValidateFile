using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TaskValidateFile.Models
{
    public class ValidateFile : ValidationAttribute
    {
        public string? ErrorMessage { get; set; }
        public decimal FileSize { get; set; } 

        public string ValidateFileCount(IFormFileCollection files, int maxFileCount)
        {
            if (files == null || files.Count == 0)
            {
                ErrorMessage = "Please select a file.";
                return ErrorMessage;

            }

            if (files.Count > maxFileCount)
            {
                ErrorMessage = "You can upload a maximum of " + maxFileCount + " files.";
                return ErrorMessage;
            }

            return null; // No errors
        }
        public string UploadUserFile(IFormFile file)
        {
            try
            {

                var supportedTypes = new[] { "txt", "doc", "docx", "pdf", "xls", "xlsx" };
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    ErrorMessage = "File Extension Is InValid - Only Upload WORD/PDF/EXCEL/TXT File";
                    return ErrorMessage;
                }
                else if (file.Length > (FileSize * 1024))
                {
                    ErrorMessage = "File size Should Be UpTo " + FileSize + "KB";
                    return ErrorMessage;
                }
                else
                {
                    ErrorMessage = "File Is Successfully Uploaded";
                    return ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Upload Container Should Not Be Empty or Contact Admin";
                return ErrorMessage;
            }
        }


    }
}
