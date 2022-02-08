using API.Interfaces;

namespace API.Services
{
    public class PhotoService : IPhotoService
    {
      public  Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
      {
          
      }
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}