using System.Threading.Tasks;
using Cloadianay

namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}