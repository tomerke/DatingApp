using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.Asp

namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}