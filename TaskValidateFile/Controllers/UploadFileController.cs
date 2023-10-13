using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskValidateFile.Models;
using TaskValidateFile.Utility;

namespace TaskValidateFile.Controllers
{
    public class UploadFileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FileUpload(IFormFileCollection files) 
        {
            ValidateFile validator = new ValidateFile();
            string countError = validator.ValidateFileCount(files, 3);
            if (countError != null)
            {
                ViewBag.ResultErrorMessage = countError;
                return View();
            }
            foreach (var file in files)
            {
                validator.FileSize = 550;
                string resultMessage = validator.UploadUserFile(file);

                if (resultMessage != null)
                {
                    ViewBag.ResultErrorMessage = resultMessage;
                }
            }

            return View();
        }
    }
}