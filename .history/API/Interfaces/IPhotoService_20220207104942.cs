using System.Threading.Tasks;
using CloadianayDotNet.Actions;


namespace API.Interfaces
{
    public interface IPhotoService
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}