using System.Threading.Tasks;
using CloadinaryDotNet.Actions;


namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}