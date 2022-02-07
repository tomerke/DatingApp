using System.Threading.Tasks;
using CloadinayDotNet.Actions;


namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}