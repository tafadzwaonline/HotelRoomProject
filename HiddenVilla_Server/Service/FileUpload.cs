using HiddenVilla_Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;


namespace HiddenVilla_Server.Service
{
    public class FileUpload : IFileUpload
        {
            private readonly IWebHostEnvironment _webHostEnvironment;

            public FileUpload(IWebHostEnvironment webHostEnvironment)
            {
                _webHostEnvironment = webHostEnvironment;
            }

            public async Task<string> UploadFile(IBrowserFile file)
            {
                try
                {

                    var extension = Path.GetExtension(file.Name);
                    var fileName = Guid.NewGuid() + extension;
                    var folderdirectory = $"{_webHostEnvironment.WebRootPath}\\images";
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                

                    var memoryStream = new MemoryStream();
                    await file.OpenReadStream().CopyToAsync(memoryStream);
                    if (!Directory.Exists(folderdirectory))
                    {
                        Directory.CreateDirectory(folderdirectory);
                    }

                    await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                       memoryStream.WriteTo(fs);
                    }
                    var fullpath = $"images/{fileName}";

                    return fullpath;

                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }

            public bool DeleteFile(string fileName)
            {
                try
                {
                    var path = $"{_webHostEnvironment.WebRootPath}\\images\\{fileName}";
                    //var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        return true;
                    }

                    return false;

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                
            }
    }
}

