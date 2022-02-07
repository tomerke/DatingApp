using API.Interfaces;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;
using Microsoft.Extenstions.Options;
using API.Helpers;

namespace API.Services
{
    public class PhotoService : IPhotoService
    {
       private readonly Cloudinary _cloudinary;
        public PhotoService(IPtions<CloudinarySettings> config)
        {
            var acc = new Account(
              config.Value.CloadName,
              config.Value.ApiKey,
              config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }
      public  Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
      {
          var uploadResult = new ImageUploadResult();
          if(file.Length > 0)
          {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Tranformantion().Heigth(500).Width(500).Crop("fill").Graviry("face")
                };
          }
      }
       public Task<DeletionResult> DeletePhotoAsync(string publicId)
       {

       }
    }
}