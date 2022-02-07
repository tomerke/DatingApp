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
            
        }
      public  Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
      {

      }
       public Task<DeletionResult> DeletePhotoAsync(string publicId)
       {

       }
    }
}