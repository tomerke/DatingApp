using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.As

namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}