using System.Threading.Tasks;
using Cloa

namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}