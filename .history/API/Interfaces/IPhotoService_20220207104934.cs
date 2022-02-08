using System.Threading.Tasks;
using CloadianayDotNet

namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}