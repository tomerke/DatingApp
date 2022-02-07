using API.Interfaces;

namespace API.Services
{
    public class PhotoService: IPhotoService
    {
 Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
          Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}