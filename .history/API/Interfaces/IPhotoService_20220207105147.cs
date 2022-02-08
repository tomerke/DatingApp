using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft

namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}