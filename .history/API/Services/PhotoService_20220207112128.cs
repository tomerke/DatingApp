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
          var uploadResult 
      }
       public Task<DeletionResult> DeletePhotoAsync(string publicId)
       {

       }
    }
}