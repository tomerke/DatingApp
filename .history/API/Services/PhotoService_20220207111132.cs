using API.Interfaces;

namespace API.Services
{
    public class PhotoService : IPhotoService
    {
      public  Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
      {

      }
       public Task<DeletionResult> DeletePhotoAsync(string publicId)
       {
           
       }
    }
}