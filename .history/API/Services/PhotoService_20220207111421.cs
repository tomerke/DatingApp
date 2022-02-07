using API.Interfaces;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;

namespace API.Services
{
    public class PhotoService : IPhotoService
    {
       private readonly Cloudinary _cloudinary;
        public PhotoService(IPtion)
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