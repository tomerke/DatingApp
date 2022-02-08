namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
    }
}