using API.Interfaces;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace API.Services
{
    public class PhotoService : IPhotoService
    {
       
        public PhotoService()
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